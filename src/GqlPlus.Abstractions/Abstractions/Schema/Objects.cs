namespace GqlPlus.Abstractions.Schema;

public interface IGqlpObject
  : IGqlpType
{
  IEnumerable<IGqlpTypeParameter> TypeParameters { get; }
}

public interface IGqlpObject<TField, TAlt, TBase>
  : IGqlpType<TBase>, IGqlpObject
  where TBase : IGqlpObjBase<TBase>
  where TField : IGqlpObjField<TBase>
  where TAlt : IGqlpObjAlternate<TBase>
{
  IEnumerable<TField> Fields { get; }
  IEnumerable<TAlt> Alternates { get; }
}

public interface IGqlpObjBase<TBase>
  : IGqlpAbbreviated
  , IGqlpDescribed
  , IEquatable<TBase>
{
  string Label { get; }
  string TypeName { get; }
  string FullType { get; }

  bool IsTypeParameter { get; }
  IEnumerable<TBase> TypeArguments { get; }
}

public interface IGqlpObjField<TBase>
  : IGqlpAliased
  , IGqlpModifiers
  where TBase : IGqlpObjBase<TBase>
{
  TBase Type { get; }
  string ModifiedType { get; }
}

public interface IGqlpTypeParameter
  : IGqlpDescribed, IGqlpNamed
{ }

public interface IGqlpObjAlternate<TBase>
  : IGqlpError
  , IGqlpDescribed
  , IGqlpModifiers
  where TBase : IGqlpObjBase<TBase>
{
  TBase Type { get; }
}

public interface IGqlpDualObject
  : IGqlpObject<IGqlpDualField, IGqlpDualAlternate, IGqlpDualBase>
{ }

public interface IGqlpDualBase
  : IGqlpObjBase<IGqlpDualBase>
{
  string Dual { get; }
}

public interface IGqlpDualField
  : IGqlpObjField<IGqlpDualBase>
{ }

public interface IGqlpDualAlternate
  : IGqlpObjAlternate<IGqlpDualBase>
{ }

public interface IGqlpToDual
{
  IGqlpDualBase ToDual { get; }
}

public interface IGqlpInputObject
  : IGqlpObject<IGqlpInputField, IGqlpInputAlternate, IGqlpInputBase>
{ }

public interface IGqlpInputBase
  : IGqlpObjBase<IGqlpInputBase>
  , IGqlpToDual
{
  string Input { get; }
}

public interface IGqlpInputField
  : IGqlpObjField<IGqlpInputBase>
{
  IGqlpConstant? DefaultValue { get; }
}

public interface IGqlpInputAlternate
  : IGqlpObjAlternate<IGqlpInputBase>
{ }

public interface IGqlpOutputObject
  : IGqlpObject<IGqlpOutputField, IGqlpOutputAlternate, IGqlpOutputBase>
{ }

public interface IGqlpOutputBase
  : IGqlpObjBase<IGqlpOutputBase>
  , IGqlpToDual
{
  string Output { get; }
  string? EnumMember { get; }

  void SetEnumType(string enumType);
}

public interface IGqlpOutputField
  : IGqlpObjField<IGqlpOutputBase>
{
  IEnumerable<IGqlpInputParameter> Parameters { get; }
}

public interface IGqlpOutputAlternate
  : IGqlpObjAlternate<IGqlpOutputBase>
{ }

public interface IGqlpInputParameter
  : IGqlpError, IGqlpDescribed, IGqlpModifiers
{
  IGqlpInputBase Type { get; }
  IGqlpConstant? DefaultValue { get; }
}
