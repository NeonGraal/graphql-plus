namespace GqlPlus.Abstractions.Schema;

public interface IGqlpSimple<TItem>
  : IGqlpType<string>
  where TItem : IGqlpError
{
  IEnumerable<TItem> Items { get; }
}

public interface IGqlpDomain
  : IGqlpType<string>
{
  DomainKind DomainKind { get; }
}

public interface IGqlpDomain<TItem>
  : IGqlpDomain, IGqlpSimple<TItem>
  where TItem : IGqlpDomainItem
{
}

public interface IGqlpDomainItem
  : IGqlpError
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

public interface IGqlpTrueFalse
  : IGqlpDomainItem
{
  bool IsTrue { get; }
}

public interface IGqlpMember
  : IGqlpDomainItem
{
  string EnumType { get; }
  string EnumItem { get; }
}

public interface IGqlpRange
  : IGqlpDomainItem
{
  decimal? Min { get; }
  decimal? Max { get; }
}

public interface IGqlpRegex
  : IGqlpDomainItem
{
  string Pattern { get; }
}

public interface IGqlpEnum
  : IGqlpSimple<IGqlpEnumItem>
{ }

public interface IGqlpEnumItem
  : IGqlpAliased
{ }

public interface IGqlpUnion
  : IGqlpSimple<IGqlpUnionItem>
{ }

public interface IGqlpUnionItem
  : IGqlpNamed, IGqlpDescribed
{ }
