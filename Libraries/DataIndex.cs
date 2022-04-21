using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
namespace Libraries;
/**
<summary></summary>
<remarks>




</remarks>
*/
[WIP]
[DataInfo("DataIndex","Libraries","Dan Budd")]
[Syntax("DataIndex","Libraries","Holds information but doesn't hold the values as readonly values.","Dan Budd")]
public class DataIndex<TValue> : IEnumerable
{
  private List<string> _keys;
  private List<DataEntry<TValue>> entries;
  public DataIndex(params (string key, TValue value_)[] pairs)
  {
    _keys = new List<string>();
    entries = new List<DataEntry<TValue>>();
    foreach(var pair in pairs)
    {
      if(_keys.Contains(pair.key)) continue;
      else
      {
        _keys.Add(pair.key);
        entries.Add(pair.ToDataEntry());
      }
    }
  }
  public int Count => entries.Count;
  public bool Remove(string key)
  {
    if(!ContainsKey(key)) return false;
    else
    {
      _keys.Remove(key);
      return entries.Remove(Find(pair => pair.HasKey(key)));
    }
  }
  public bool TryRemove(string key, out TValue? @value)
  {
      TryGetByName(key, out @value);
      return entries.Remove(Find(pair => pair.HasKey(key)));
  }
  public void Set(string key, TValue val)
  {
    if(!_keys.Contains(key))
    {
      _keys.Add(key);
      entries.Add(new DataEntry<TValue>(key,val));
    }
    else
    {
      int index = _keys.IndexOf(key);
      entries[index].Value = val;
    }
  }
  public bool TryGetByName(string name, out TValue? tv)
  {
    int index = _keys.IndexOf(name);
    bool output = index > -1;
    tv = output ? entries[index].Value : default(TValue);
    return output;
  }
  public bool TryGetValue(Predicate<DataEntry<TValue>> condition, out TValue? tv)
  {
    DataEntry<TValue>? entry = entries.Find(p => condition(p));
    tv = entry != null ? ((DataEntry<TValue>)entry).Value  : default(TValue);
    return entry != null;
  }
  [WIP]
  public DataEntry<TValue>? FindByName(string name)
  {
    return entries.Find(pair => pair.HasKey(name));
  }
  public DataEntry<TValue> Find(Predicate<DataEntry<TValue>> condition)
  {
    DataEntry<TValue>? entry = entries.Find(condition);
    if(entry != null) return (DataEntry<TValue>)entry;
    else throw new KeyUnavailableException($"condition.ToString()");
  }
  public List<DataEntry<TValue>> FindAll(Predicate<DataEntry<TValue>> condition) => entries.FindAll(condition);
  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)this.GetEnumerator();
  public IEnumerator<DataEntry<TValue>> GetEnumerator()
  {
    foreach(var entry in entries)
    {
      yield return entry;
    }
  }
  public TValue this[string key]
  {
    get
    {
      TValue? val;
      if(TryGetByName(key, out val) && val != null) return (TValue)val;
      else throw new UnknownKeyException(key);
    }
    set
    {
      Set(key,value);
    }
  }
  public DataEntry<TValue>[] Entries => entries.ToArray();
  public TValue?[] Values => entries.ToArray().Pull(pair => pair.Value);
  public string[] Keys => _keys.ToArray();
  public bool ContainsKey(string key)
  {
    return _keys.Contains(key);
  }
  public bool ContainsValue(TValue v) => Values.Contains(v);
  // public bool
}
/**
<summary>The content inside a DataIndex.</summary>
<typeparam name="TValue">The type of value that is stored.</typeparam>
*/
[Syntax("DataEntry<TValue>","Libraries","The content inside a DataIndex.","Dan Budd")]
[DataInfo("DataEntry<TValue>","Libraries","Dan Budd","class")]
public sealed class DataEntry<TValue> : IComparable<DataEntry<TValue>>, IEquatable<DataEntry<TValue>>
{
  ///<summary>Determines whether or not the entry can be modified</summary>
  public bool IsReadOnly { get; }
  ///<summary>The key of the entry</summary>
  public string Key { get; }
  ///
  /**
  <summary>The value of the entry. Might be able to be modified.</summary>
  <remarks>
  If <see cref="DataEntry{T}.IsReadOnly"/>, the value cannot be modified.
  </remarks>
  */
  public TValue Value { get; set; }
  public void SetValue(TValue @value)
  {
     // if(IsReadOnly) throw new 
  }
  /**
  <summary>The value of the entry. Might be able to be modified.</summary>
  <param name="key">The new key of the entry. Cannot be modified.</param>
  <param name="value">Is Optional. The new value of the entry. Can be modified if <see cref="DataEntry{T}.IsReadOnly"/></param>
  <param name="readOnly">Is Optional. Sets the value for <see cref="DataEntry{T}.IsReadOnly"/></param>
  <remarks>
  //
  </remarks>
  */
  public DataEntry(string key, [Optional]TValue @value, [Optional]bool readOnly)
  {
    Key = key;
    Value = @value;
    IsReadOnly = readOnly;
  }
  public int CompareTo(DataEntry<TValue>? other) => other == null ? 1 : Key.CompareTo(other.Key);
  public bool Equals(DataEntry<TValue>? other) => other != null && Key.Equals(other.Key) && Value != null && Value.Equals(other.Value);
  public override bool Equals(object? obj) => obj != null && obj is DataEntry<TValue> other ? this.Equals(other) : false;
  public override string ToString() => $"({Key},{Value})";
  public override int GetHashCode() => HashCode.Combine<string,TValue?>(Key,Value);
  ///<summary>This allows to find a DataEntry within a <see cref="DataIndex{TValue}"/> by name.</summary>
  ///<param name="key">The name that is matched to the element.</param>
  ///<returns>Whether or not the name matches the Key of the element.</returns>
  public bool HasKey(string key) => Key.Equals(key);
}
public class UnknownKeyException : Exception
{
  public UnknownKeyException(string key) : base($"Key {key} unkown") {}
  public UnknownKeyException(string key, Exception inner) : base($"Key {key} unkown") {}
  public UnknownKeyException(Exception inner) : base("Key unknown", inner) {}
  public UnknownKeyException() : base("Key unknown") {}
}
public class KeyUnavailableException: Exception
{
  public KeyUnavailableException() : base() {}
  public KeyUnavailableException(string message) : base(message) {}
  public KeyUnavailableException(string message, Exception inner) : base(message,inner) {}

}
public class ReadOnlyException : Exception
{
  public ReadOnlyException(string message) : base(message) {}
  public ReadOnlyException(Exception inner) : base("Value is ReadOnly",inner) {}
  public ReadOnlyException() : base("Value is ReadOnly") {}
}