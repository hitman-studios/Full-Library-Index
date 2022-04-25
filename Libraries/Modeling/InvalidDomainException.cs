namespace Libraries.Modeling;
using Libraries;
using System.Runtime.InteropServices;
using System;
/**
<summary>The exception that is raised by an IEquation or EquationModel descendant when invoked.</summary>
<exception>InvalidDomainException</exception>
*/
public class InvalidDomainException : Exception
{
  ///<summary>The invalid domain value.</summary>
  public Number domain { get; }
/**
<summary>Creates an Exception with the domain value for try and catching</summary>
<param name="domainError">the invalid domain that caused the error</param>
*/
  public InvalidDomainException(Number domainError) : base($"{domainError} is not in the domain of the given function.") { domain = domainError;}
/**
<summary>Creates an Exception with the domain value for try and catching</summary>
<param name="domainError">the invalid domain that caused the error</param>
<param name="inner">The inner exception that would cause this exception to happen in the first place.</param>
*/
  public InvalidDomainException(Number domainError, Exception inner) : base($"{domainError} is not in the domain of the given function.", inner) { domain = domainError;}
}