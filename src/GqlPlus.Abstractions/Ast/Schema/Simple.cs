namespace GqlPlus.Abstractions.Schema;

public interface IAstSimple<TItem>
  : IAstSimple
  , IEquatable<IAstSimple<TItem>>
  where TItem : IAstError
{
  IEnumerable<TItem> Items { get; }
}

public interface IGqlpValued<TItem>
  : IAstSimple<TItem>
  where TItem : IAstError
{
  bool HasValue(string value);
}

public interface IGqlpDomain
  : IAstSimple
  , IEquatable<IGqlpDomain>
{
  DomainKind DomainKind { get; }
}

public interface IGqlpDomain<TItem>
  : IGqlpDomain
  , IAstSimple<TItem>
  , IEquatable<IGqlpDomain<TItem>>
  where TItem : IGqlpDomainItem
{ }

public interface IGqlpDomainItem
  : IAstDescribed
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

public static class GqlpDomainLabelConstants
{
  public const string All = "*";
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
  : IAstAliased
{ }

public interface IGqlpUnion
  : IGqlpValued<IGqlpUnionMember>
{ }

public interface IGqlpUnionMember
  : IAstNamed
{ }
