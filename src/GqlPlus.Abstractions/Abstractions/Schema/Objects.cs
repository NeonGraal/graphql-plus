namespace GqlPlus.Abstractions.Schema;

public interface IGqlpObject
  : IGqlpType<IGqlpObjBase>
{
  IEnumerable<IGqlpTypeParam> TypeParams { get; }
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

public interface IGqlpObjType
  : IGqlpNamed
{
  string Label { get; }
  string FullType { get; }
  bool IsTypeParam { get; }
}

public interface IGqlpObjArg
  : IGqlpObjType
  , IEquatable<IGqlpObjArg>
{ }

public interface IGqlpObjBase
  : IGqlpObjType
  , IEquatable<IGqlpObjBase>
{
  IEnumerable<IGqlpObjArg> Args { get; }
}

public interface IGqlpObjBase<TArg>
  : IGqlpObjBase
  where TArg : IGqlpObjArg
{
  IEnumerable<TArg> BaseArgs { get; }
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
  , IGqlpObjBase
  , IGqlpModifiers
{ }

public interface IGqlpObjAlternate<TArg>
  : IGqlpObjAlternate
  , IGqlpObjBase<TArg>
  where TArg : IGqlpObjArg
{ }

public interface IGqlpTypeParam
  : IGqlpNamed
{ }

public interface IGqlpDualObject
  : IGqlpObject<IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate>
{ }

public interface IGqlpDualNamed
  : IGqlpNamed
{
  string Dual { get; }
}

public interface IGqlpDualArg
  : IGqlpObjArg
  , IGqlpDualNamed
{ }

public interface IGqlpDualBase
  : IGqlpObjBase<IGqlpDualArg>
  , IGqlpDualNamed
{ }

public interface IGqlpDualField
  : IGqlpObjField<IGqlpDualBase>
{ }

public interface IGqlpDualAlternate
  : IGqlpObjAlternate
  , IGqlpObjBase<IGqlpDualArg>
  , IGqlpDualNamed
{ }

public interface IGqlpToDual<T>
  where T : IGqlpObjType
{
  T ToDual { get; }
}

public interface IGqlpInputObject
  : IGqlpObject<IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate>
{ }

public interface IGqlpInputNamed
  : IGqlpNamed
{
  string Input { get; }
}

public interface IGqlpInputArg
  : IGqlpObjArg
  , IGqlpInputNamed
  , IGqlpToDual<IGqlpDualArg>
{ }

public interface IGqlpInputBase
  : IGqlpObjBase<IGqlpInputArg>
  , IGqlpInputNamed
  , IGqlpToDual<IGqlpDualBase>
{ }

public interface IGqlpInputField
  : IGqlpObjField<IGqlpInputBase>
{
  IGqlpConstant? DefaultValue { get; }
}

public interface IGqlpInputAlternate
  : IGqlpObjAlternate
  , IGqlpObjBase<IGqlpInputArg>
  , IGqlpInputNamed
  , IGqlpToDual<IGqlpDualAlternate>
{ }

public interface IGqlpOutputObject
  : IGqlpObject<IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate>
{ }

public interface IGqlpOutputNamed
  : IGqlpNamed
{
  string Output { get; }
}

public interface IGqlpOutputEnum
  : IGqlpError
{
  IGqlpObjType EnumType { get; }
  string? EnumLabel { get; }

  void SetEnumType(string enumType);
}

public interface IGqlpOutputArg
  : IGqlpObjArg
  , IGqlpOutputNamed
  , IGqlpOutputEnum
  , IGqlpToDual<IGqlpDualArg>
{ }

public interface IGqlpOutputBase
  : IGqlpObjBase<IGqlpOutputArg>
  , IGqlpOutputNamed
  , IGqlpToDual<IGqlpDualBase>
{ }

public interface IGqlpOutputField
  : IGqlpObjField<IGqlpOutputBase>
  , IGqlpOutputEnum
{
  IEnumerable<IGqlpInputParam> Params { get; }
}

public interface IGqlpOutputAlternate
  : IGqlpObjAlternate, IGqlpObjBase<IGqlpOutputArg>
  , IGqlpOutputNamed
  , IGqlpToDual<IGqlpDualAlternate>
{ }

public interface IGqlpInputParam
  : IGqlpDescribed
  , IGqlpModifiers
{
  IGqlpInputBase Type { get; }
  IGqlpConstant? DefaultValue { get; }
}
