namespace GqlPlus.Abstractions.Schema;

public interface IGqlpObject
  : IGqlpType<IGqlpObjBase>
{
  IEnumerable<IGqlpTypeParam> TypeParams { get; }
  IEnumerable<IGqlpObjField> Fields { get; }
  IEnumerable<IGqlpObjAlternate> Alternates { get; }
}

public interface IGqlpObject<TBase>
  : IGqlpObject
  where TBase : IGqlpObjBase
{
  TBase? ObjParent { get; }
}

public interface IGqlpObject<TBase, TField, TAlt>
  : IGqlpObject<TBase>
  , IEquatable<IGqlpObject<TBase, TField, TAlt>>
  where TBase : IGqlpObjBase
  where TField : IGqlpObjField
  where TAlt : IGqlpObjAlternate
{
  IEnumerable<TField> ObjFields { get; }
  IEnumerable<TAlt> ObjAlternates { get; }
}

public interface IGqlpObjType
  : IGqlpNamed
  , IEquatable<IGqlpObjType>
{
  string Label { get; }
  string FullType { get; }
  bool IsTypeParam { get; }
}

public interface IGqlpObjectEnum
  : IGqlpError
{
  IGqlpObjType EnumType { get; }
  string? EnumLabel { get; }

  void SetEnumType(string enumType);
}

public interface IGqlpObjArg
  : IGqlpObjType
  , IGqlpObjectEnum
  , IEquatable<IGqlpObjArg>
{ }

public interface IGqlpObjBase
  : IGqlpObjType
  , IEquatable<IGqlpObjBase>
{
  IEnumerable<IGqlpObjArg> Args { get; }

  void SetName(string name);
}

public interface IGqlpObjBase<TArg>
  : IGqlpObjBase
  , IEquatable<IGqlpObjBase<TArg>>
  where TArg : IGqlpObjArg
{
  IEnumerable<TArg> BaseArgs { get; }
}

public interface IGqlpObjField
  : IGqlpAliased
  , IGqlpObjectEnum
  , IGqlpModifiers
{
  IGqlpObjBase Type { get; }
  string ModifiedType { get; }
}

public interface IGqlpObjField<TBase>
  : IGqlpObjField
  , IEquatable<IGqlpObjField<TBase>>
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
  , IEquatable<IGqlpObjAlternate<TArg>>
  where TArg : IGqlpObjArg
{ }

public interface IGqlpTypeParam
  : IGqlpNamed
{
  string Constraint { get; }
}

public interface IGqlpDualObject
  : IGqlpObject<IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate>
{ }

public interface IGqlpDualBase
  : IGqlpObjBase<IGqlpObjArg>
{ }

public interface IGqlpDualField
  : IGqlpObjField<IGqlpDualBase>
{ }

public interface IGqlpDualAlternate
  : IGqlpObjAlternate<IGqlpObjArg>
  , IGqlpDualBase
{ }

public interface IGqlpToDual<T>
  where T : IGqlpObjType
{
  T ToDual { get; }
}

public interface IGqlpInputObject
  : IGqlpObject<IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate>
{ }

public interface IGqlpInputBase
  : IGqlpObjBase<IGqlpObjArg>
  , IGqlpToDual<IGqlpDualBase>
{ }

public interface IGqlpInputField
  : IGqlpObjField<IGqlpInputBase>
  , IEquatable<IGqlpInputField>
{
  IGqlpConstant? DefaultValue { get; }
}

public interface IGqlpInputAlternate
  : IGqlpObjAlternate<IGqlpObjArg>
  , IGqlpInputBase
  , IGqlpToDual<IGqlpDualAlternate>
{ }

public interface IGqlpOutputObject
  : IGqlpObject<IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate>
{ }

public interface IGqlpOutputBase
  : IGqlpObjBase<IGqlpObjArg>
  , IGqlpToDual<IGqlpDualBase>
{ }

public interface IGqlpOutputField
  : IGqlpObjField<IGqlpOutputBase>
  , IEquatable<IGqlpOutputField>
{
  IEnumerable<IGqlpInputParam> Params { get; }
}

public interface IGqlpOutputAlternate
  : IGqlpObjAlternate<IGqlpObjArg>
  , IGqlpOutputBase
  , IGqlpToDual<IGqlpDualAlternate>
{ }

public interface IGqlpInputParam
  : IGqlpDescribed
  , IGqlpModifiers
  , IEquatable<IGqlpInputParam>
{
  IGqlpInputBase Type { get; }
  IGqlpConstant? DefaultValue { get; }
}
