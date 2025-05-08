namespace GqlPlus.Abstractions.Schema;

public interface IGqlpSimple<TItem>
  : IGqlpSimple
  , IEquatable<IGqlpSimple<TItem>>
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
  , IEquatable<IGqlpDomain>
{
  DomainKind DomainKind { get; }
}

public interface IGqlpDomain<TItem>
  : IGqlpDomain
  , IGqlpSimple<TItem>
  , IEquatable<IGqlpDomain<TItem>>
  where TItem : IGqlpDomainItem
{ }

public interface IGqlpDomainItem
  : IGqlpError
  , IGqlpDescribed
  , IEquatable<IGqlpDomainItem>
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
  , IEquatable<IGqlpDomainLabel>
{
  string EnumType { get; }
  string EnumItem { get; }

  void SetEnumType(string enumType);
}

public interface IGqlpDomainRange
  : IGqlpDomainItem
  , IEquatable<IGqlpDomainRange>
{
  decimal? Lower { get; }
  decimal? Upper { get; }
}

public interface IGqlpDomainRegex
  : IGqlpDomainItem
  , IEquatable<IGqlpDomainRegex>
{
  string Pattern { get; }
}

public interface IGqlpEnum
  : IGqlpValued<IGqlpEnumLabel>
{ }

public interface IGqlpEnumLabel
  : IGqlpAliased
  , IEquatable<IGqlpEnumLabel>
{ }

public interface IGqlpUnion
  : IGqlpValued<IGqlpUnionMember>
{ }

public interface IGqlpUnionMember
  : IGqlpNamed
  , IEquatable<IGqlpUnionMember>
{ }
