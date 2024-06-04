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
  IEnumerable<TField> Fields { get; }
  IEnumerable<IGqlpAlternate<TBase>> Alternates { get; }
}

public interface IGqlpObjectBase<TBase>
  : IGqlpAbbreviated
  , IGqlpDescribed
{
  string Label { get; }
  string TypeName { get; }
  string FullType { get; }

  bool IsTypeParameter { get; }
  IEnumerable<TBase> TypeArguments { get; }
}

public interface IGqlpObjectField<TBase>
  : IGqlpAliased
  , IGqlpModifiers
  where TBase : IGqlpObjectBase<TBase>
{
  TBase Type { get; }
  string ModifiedType { get; }
}

public interface IGqlpTypeParameter
  : IGqlpDescribed, IGqlpNamed
{ }

public interface IGqlpAlternate<TBase>
  : IGqlpError
  , IGqlpDescribed
  , IGqlpModifiers
  where TBase : IGqlpObjectBase<TBase>
{
  TBase Type { get; }
}

public interface IGqlpDualObject
  : IGqlpObject<IGqlpDualField, IGqlpDualBase>
{ }

public interface IGqlpDualBase
  : IGqlpObjectBase<IGqlpDualBase>
  , IEquatable<IGqlpDualBase>
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
  , IEquatable<IGqlpInputBase>
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
  , IEquatable<IGqlpOutputBase>
  , IGqlpToDual
{
  string Output { get; }
  string? EnumValue { get; }

  void SetEnumType(string enumType);
}

public interface IGqlpOutputField
  : IGqlpObjectField<IGqlpOutputBase>
{
  IEnumerable<IGqlpInputParameter> Parameters { get; }
}

public interface IGqlpInputParameter
  : IGqlpError, IGqlpDescribed, IGqlpModifiers
{
  IGqlpInputBase Type { get; }
  IGqlpConstant? DefaultValue { get; }
}
