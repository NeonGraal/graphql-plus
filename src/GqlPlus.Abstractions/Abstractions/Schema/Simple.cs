﻿namespace GqlPlus.Abstractions.Schema;

public interface IGqlpSimple<TItem>
  : IGqlpSimple
  where TItem : IGqlpError
{
  IEnumerable<TItem> Items { get; }
}

public interface IGqlpValued<TItem>
  : IGqlpSimple<TItem>
  where TItem : IGqlpError
{
  bool HasValue(string value);
}

public interface IGqlpDomain
  : IGqlpType<string>
{
  DomainKind DomainKind { get; }
}

public interface IGqlpDomain<TItem>
  : IGqlpDomain, IGqlpSimple<TItem>
  where TItem : IGqlpDomainItem
{ }

public interface IGqlpDomainItem
  : IGqlpError, IGqlpDescribed
{
  bool Excludes { get; }
}

public enum DomainKind
{
  Boolean,
  Enum,
  Number,
  String,
}

public interface IGqlpDomainTrueFalse
  : IGqlpDomainItem
{
  bool IsTrue { get; }
}

public interface IGqlpDomainLabel
  : IGqlpDomainItem
{
  string EnumType { get; }
  string EnumItem { get; }

  void SetEnumType(string enumType);
}

public interface IGqlpDomainRange
  : IGqlpDomainItem
{
  decimal? Lower { get; }
  decimal? Upper { get; }
}

public interface IGqlpDomainRegex
  : IGqlpDomainItem
{
  string Pattern { get; }
}

public interface IGqlpEnum
  : IGqlpValued<IGqlpEnumLabel>
{ }

public interface IGqlpEnumLabel
  : IGqlpAliased
{ }

public interface IGqlpUnion
  : IGqlpValued<IGqlpUnionMember>
{ }

public interface IGqlpUnionMember
  : IGqlpNamed
{ }
