namespace GqlPlus.Abstractions.Schema;

public interface IGqlpObject
  : IGqlpType<IGqlpObjBase>
{
  IEnumerable<IGqlpTypeParameter> TypeParameters { get; }
  IEnumerable<IGqlpObjField> Fields { get; }
  IEnumerable<IGqlpObjAlternate> Alternates { get; }
}

public interface IGqlpObject<TBase, TField, TAlt>
  : IGqlpObject
  where TBase : IGqlpObjBase
  where TField : IGqlpObjField
  where TAlt : IGqlpObjAlternate
{
  TBase? ObjParent { get; }
  IEnumerable<TField> ObjFields { get; }
  IEnumerable<TAlt> ObjAlternates { get; }
}

public interface IGqlpObjBase
  : IGqlpAbbreviated
  , IGqlpDescribed
  , IEquatable<IGqlpObjBase>
{
  string Label { get; }
  string TypeName { get; }
  string FullType { get; }

  bool IsTypeParameter { get; }
  IEnumerable<IGqlpObjBase> Arguments { get; }
}

public interface IGqlpObjBase<TBase>
  : IGqlpObjBase
  where TBase : IGqlpObjBase
{
  IEnumerable<TBase> BaseArguments { get; }
}

public interface IGqlpObjField
  : IGqlpAliased
  , IGqlpModifiers
{
  IGqlpObjBase Type { get; }
  string ModifiedType { get; }
}

public interface IGqlpObjField<TBase>
  : IGqlpObjField
  where TBase : IGqlpObjBase
{
  TBase BaseType { get; }
}

public interface IGqlpObjAlternate
  : IGqlpError
  , IGqlpDescribed
  , IGqlpModifiers
{
  IGqlpObjBase Type { get; }
}

public interface IGqlpObjAlternate<TBase>
  : IGqlpObjAlternate
  where TBase : IGqlpObjBase
{
  TBase BaseType { get; }
}

public interface IGqlpTypeParameter
  : IGqlpDescribed, IGqlpNamed
{ }

public interface IGqlpDualObject
  : IGqlpObject<IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate>
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
  : IGqlpObject<IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate>
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
  : IGqlpObject<IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate>
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
