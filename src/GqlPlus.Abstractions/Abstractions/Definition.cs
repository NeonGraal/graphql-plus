using System.Collections.Immutable;

namespace GqlPlus.Abstractions;

public interface IGqlpError
{
  ITokenMessages MakeError(string message);
}

public interface IGqlpAbbreviated
  : IGqlpError
{
  ITokenAt At { get; }
  string Abbr { get; }
  IEnumerable<string?> GetFields();
}

public interface IGqlpNamed
  : IGqlpAbbreviated
{
  string Name { get; }
}

public interface IGqlpFieldKey
  : IGqlpAbbreviated
  , IEquatable<IGqlpFieldKey>
  , IComparable<IGqlpFieldKey>
{
  decimal? Number { get; }
  string? Text { get; }
  string? EnumLabel { get; }
  string? EnumType { get; }
  string? EnumValue { get; }
}

public interface IGqlpModifier
  : IGqlpError
{
  ModifierKind ModifierKind { get; }
  string? Key { get; }
  bool IsOptional { get; }
}

public enum ModifierKind
{
  Opt,
  Optional = Opt,
  List,
  Dict,
  Dictionary = Dict,
  Param,
  TypeParam = Param,
}

public interface IGqlpModifiers
{
  IEnumerable<IGqlpModifier> Modifiers { get; }
}

public interface IGqlpConstant
  : IGqlpValue<IGqlpConstant>
  , IEquatable<IGqlpConstant>
{
  IGqlpFieldKey? Value { get; }
}

public interface IGqlpValue<TValue>
  : IGqlpAbbreviated
  , IEquatable<IGqlpValue<TValue>>
{
  IEnumerable<TValue> Values { get; }
  IGqlpFields<TValue> Fields { get; }
}

public interface IGqlpFields<TValue>
  : IImmutableDictionary<IGqlpFieldKey, TValue>
  , IEquatable<IGqlpFields<TValue>>
{ }
