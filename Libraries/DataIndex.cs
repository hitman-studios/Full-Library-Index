using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace Libraries;

[WIP]
[DataInfo(typeof(DataIndex<>),"Libraries","Dan Budd")]
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
      TryGetValue(key, out @value);
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
  public bool TryGetValue(string name, out TValue? tv)
  {
    int index = _keys.IndexOf(name);
    bool output = index > -1;
    tv = output ? entries[index].Value : default(TValue);
    return output;
  }
  [WIP]
  public DataEntry<TValue>? FindByName(string name)
  {
    return entries.Find(pair => pair.HasKey(name));
  }
  public DataEntry<TValue> Find(Predicate<DataEntry<TValue>> condition) => entries.Find(condition);
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
      if(TryGetValue(key, out val) && val != null) return (TValue)val;
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
public sealed class DataEntry<TValue> : IComparable<DataEntry<TValue>>, IEquatable<DataEntry<TValue>>
{
  public bool IsReadOnly { get; }
  public string Key { get; }
  public TValue? Value { get; set; }
  public void SetValue(TValue @value)
  {
     // if(IsReadOnly) throw new 
  }
  public DataEntry(string k, [Optional]TValue v, [Optional]bool readOnly)
  {
    Key = k;
    Value = v;
    IsReadOnly = readOnly;
  }
  public int CompareTo(DataEntry<TValue>? other) => other == null ? 1 : Key.CompareTo(other.Key);
  public bool Equals(DataEntry<TValue>? other) => other != null && Key.Equals(other.Key) && Value != null && Value.Equals(other.Value);
  public override bool Equals(object? obj) => obj != null && obj is DataEntry<TValue> other ? this.Equals(other) : false;
  public override string ToString() => $"({Key},{Value})";
  public override int GetHashCode() => HashCode.Combine<string,TValue>(Key,Value);
  public bool HasKey(string k) => Key.Equals(k);
}
public class UnknownKeyException : Exception
{
  public UnknownKeyException(string key) : base($"Key {key} unkown") {}
  public UnknownKeyException(string key, Exception inner) : base($"Key {key} unkown") {}
  public UnknownKeyException(Exception inner) : base("Key unknown", inner) {}
  public UnknownKeyException() : base("Key unknown") {}
}
public class ReadOnlyException : Exception
{
  public ReadOnlyException(string message) : base(message) {}
  public ReadOnlyException(Exception inner) : base("Value is ReadOnly",inner) {}
  public ReadOnlyException() : base("Value is ReadOnly") {}
}