namespace GqlPlus.Abstractions.Schema;

public interface IGqlpObject
  : IGqlpType
{
  IEnumerable<IGqlpTypeParameter> TypeParameters { get; }
}

public interface IGqlpObject<TField, TBase>
  : IGqlpType<TBase>, IGqlpObject
  where TBase : IGqlpObjectBase<TBase>
  where TField : IGqlpObjectField<TBase>
{
  IEnumerable<IGqlpTypeParameter> TypeParameters { get; }
  IEnumerable<TField> Fields { get; }
  IEnumerable<IGqlpAlternate<TBase>> Alternates { get; }
}

public interface IGqlpObjectRef
  : IGqlpDescribed
{
  string? TypeName { get; }
  IGqlpDualBase? Dual { get; }
}

public interface IGqlpObjectBase<TBase>
  : IGqlpAbbreviated
  , IGqlpDescribed
  , IEquatable<TBase>
{
  bool IsTypeParameter { get; }
  IEnumerable<TBase> TypeArguments { get; }
}

public interface IGqlpObjectField<TBase>
  : IGqlpAliased
  , IGqlpModifiers
  , IEquatable<IGqlpObjectField<TBase>>
  where TBase : IGqlpObjectBase<TBase>
{
  TBase Type { get; }
}

public interface IGqlpTypeParameter
  : IGqlpDescribed, IGqlpNamed
{ }

public interface IGqlpAlternate<TBase>
  : IGqlpError, IGqlpDescribed, IGqlpModifiers
  where TBase : IGqlpObjectBase<TBase>
{
  TBase Type { get; }
  IEnumerable<IGqlpModifier> Collections { get; } // Optional is invalid
}

public interface IGqlpDualObject
  : IGqlpObject<IGqlpDualField, IGqlpDualBase>
{ }

public interface IGqlpDualBase
  : IGqlpObjectBase<IGqlpDualBase>
{
  string Dual { get; }
}

public interface IGqlpDualField
  : IGqlpObjectField<IGqlpDualBase>
{ }

public interface IGqlpToDual
{
  IGqlpDualBase ToDual { get; }
}

public interface IGqlpInputObject
  : IGqlpObject<IGqlpInputField, IGqlpInputBase>
{ }

public interface IGqlpInputBase
  : IGqlpObjectBase<IGqlpInputBase>
  , IGqlpToDual
{
  string Input { get; }
}

public interface IGqlpInputField
  : IGqlpObjectField<IGqlpInputBase>
{
  IGqlpConstant? DefaultValue { get; }
}

public interface IGqlpOutputObject
  : IGqlpObject<IGqlpOutputField, IGqlpOutputBase>
{ }

public interface IGqlpOutputBase
  : IGqlpObjectBase<IGqlpOutputBase>
  , IGqlpToDual
{
  string Output { get; }
  string? EnumValue { get; }
}

public interface IGqlpOutputField
  : IGqlpObjectField<IGqlpOutputBase>
{
  IEnumerable<IGqlpInputParameter> Parameters { get; }
}

public interface IGqlpInputParameter
  : IGqlpDescribed, IGqlpModifiers
{
  IGqlpInputBase Type { get; }
  IGqlpConstant? DefaultValue { get; }
}
