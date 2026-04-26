using System.Collections.Immutable;

namespace GqlPlus.Ast;

public interface IAstError
{
  IMessages MakeError(string message);
}

public interface IAstAbbreviated
  : IAstError
  , IEquatable<IAstAbbreviated>
{
  ITokenAt At { get; }
  IEnumerable<string?> GetFields();
}

public interface IAstEnumValue
  : IAstAbbreviated
  , IEquatable<IAstEnumValue?>
  , IComparable<IAstEnumValue?>
{
  string EnumType { get; }
  string EnumLabel { get; }
  string EnumValue { get; }
}

public interface IAstFieldKey
  : IAstAbbreviated
  , IEquatable<IAstFieldKey?>
  , IComparable<IAstFieldKey?>
{
  decimal? Number { get; }
  string? Text { get; }
  IAstEnumValue? EnumValue { get; }
}

public interface IAstModifier
  : IAstError
  , IEquatable<IAstModifier>
{
  ModifierKind ModifierKind { get; }
  string Key { get; }
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

public interface IAstModifiers
  : IAstAbbreviated
{
  IEnumerable<IAstModifier> Modifiers { get; }
}

public interface IAstConstant
  : IAstValue<IAstConstant>
  , IEquatable<IAstConstant>
{
  IAstFieldKey? Value { get; }
}

public interface IAstValue<TValue>
  : IAstAbbreviated
  , IEquatable<IAstValue<TValue>>
{
  IEnumerable<TValue> Values { get; }
  IAstFields<TValue> Fields { get; }
}

public interface IAstFields<TValue>
  : IImmutableDictionary<IAstFieldKey, TValue>
  , IEquatable<IAstFields<TValue>>
{ }
