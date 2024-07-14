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
  : IGqlpAbbreviated
  , IGqlpDescribed
{
  string Label { get; }
  string TypeName { get; }
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

public interface IGqlpObjBase<TBase>
  : IGqlpObjBase
  where TBase : IGqlpObjArg
{
  IEnumerable<TBase> BaseArgs { get; }
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

public interface IGqlpTypeParam
  : IGqlpDescribed, IGqlpNamed
{ }

public interface IGqlpDualObject
  : IGqlpObject<IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate>
{ }

public interface IGqlpDualArg
  : IGqlpObjArg
{
  string Dual { get; }
}

public interface IGqlpDualBase
  : IGqlpObjBase<IGqlpDualArg>
{
  string Dual { get; }
}

public interface IGqlpDualField
  : IGqlpObjField<IGqlpDualBase>
{ }

public interface IGqlpDualAlternate
  : IGqlpObjAlternate<IGqlpDualBase>
{ }

public interface IGqlpToDual<T>
  where T : IGqlpObjType
{
  T ToDual { get; }
}

public interface IGqlpInputObject
  : IGqlpObject<IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate>
{ }

public interface IGqlpInputArg
  : IGqlpObjArg
  , IGqlpToDual<IGqlpDualArg>
{
  string Input { get; }
}

public interface IGqlpInputBase
  : IGqlpObjBase<IGqlpInputArg>
  , IGqlpToDual<IGqlpDualBase>
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

public interface IGqlpOutputEnum
  : IGqlpError
{
  string EnumType { get; }
  string? EnumMember { get; }

  void SetEnumType(string enumType);
}

public interface IGqlpOutputArg
  : IGqlpObjArg
  , IGqlpOutputEnum
  , IGqlpToDual<IGqlpDualArg>
{
  string Output { get; }
}

public interface IGqlpOutputBase
  : IGqlpObjBase<IGqlpOutputArg>
  , IGqlpOutputEnum
  , IGqlpToDual<IGqlpDualBase>
{
  string Output { get; }
}

public interface IGqlpOutputField
  : IGqlpObjField<IGqlpOutputBase>
{
  IEnumerable<IGqlpInputParam> Params { get; }
}

public interface IGqlpOutputAlternate
  : IGqlpObjAlternate<IGqlpOutputBase>
{ }

public interface IGqlpInputParam
  : IGqlpError, IGqlpDescribed, IGqlpModifiers
{
  IGqlpInputBase Type { get; }
  IGqlpConstant? DefaultValue { get; }
}
