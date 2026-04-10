namespace GqlPlus.Abstractions.Schema;

public interface IAstSimple<TItem>
  : IAstSimple
  , IEquatable<IAstSimple<TItem>>
  where TItem : IAstError
{
  IEnumerable<TItem> Items { get; }
}

public interface IAstValued<TItem>
  : IAstSimple<TItem>
  where TItem : IAstError
{
  bool HasValue(string value);
}

public interface IAstDomain
  : IAstSimple
  , IEquatable<IAstDomain>
{
  DomainKind DomainKind { get; }
}

public interface IAstDomain<TItem>
  : IAstDomain
  , IAstSimple<TItem>
  , IEquatable<IAstDomain<TItem>>
  where TItem : IAstDomainItem
{ }

public interface IAstDomainItem
  : IAstDescribed
  , IEquatable<IAstDomainItem>
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

public interface IAstDomainTrueFalse
  : IAstDomainItem
{
  bool IsTrue { get; }
}

public interface IAstDomainLabel
  : IAstDomainItem
  , IEquatable<IAstDomainLabel>
{
  string EnumType { get; }
  string EnumItem { get; }

  void SetEnumType(string enumType);
}

public static class GqlpDomainLabelConstants
{
  public const string All = "*";
}

public interface IAstDomainRange
  : IAstDomainItem
  , IEquatable<IAstDomainRange>
{
  decimal? Lower { get; }
  decimal? Upper { get; }
}

public interface IAstDomainRegex
  : IAstDomainItem
  , IEquatable<IAstDomainRegex>
{
  string Pattern { get; }
}

public interface IAstEnum
  : IAstValued<IAstEnumLabel>
{ }

public interface IAstEnumLabel
  : IAstAliased
{ }

public interface IAstUnion
  : IAstValued<IAstUnionMember>
{ }

public interface IAstUnionMember
  : IAstNamed
{ }
