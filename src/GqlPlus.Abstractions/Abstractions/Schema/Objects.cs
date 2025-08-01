﻿namespace GqlPlus.Abstractions.Schema;

public interface IGqlpObject
  : IGqlpType<IGqlpObjBase>
{
  IEnumerable<IGqlpTypeParam> TypeParams { get; }
  IEnumerable<IGqlpObjField> Fields { get; }
  IEnumerable<IGqlpObjAlternate> Alternates { get; }
}

public interface IGqlpObject<TBase, TField, TAlt>
  : IGqlpObject
  , IEquatable<IGqlpObject<TBase, TField, TAlt>>
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
  , IEquatable<IGqlpObjType>
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
  , IEquatable<IGqlpObjBase<TArg>>
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

public interface IGqlpDualArg
  : IGqlpObjArg
{ }

public interface IGqlpDualBase
  : IGqlpObjBase<IGqlpDualArg>
{ }

public interface IGqlpDualField
  : IGqlpObjField<IGqlpDualBase>
{ }

public interface IGqlpDualAlternate
  : IGqlpObjAlternate
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

public interface IGqlpInputArg
  : IGqlpObjArg
  , IGqlpToDual<IGqlpDualArg>
{ }

public interface IGqlpInputBase
  : IGqlpObjBase<IGqlpInputArg>
  , IGqlpToDual<IGqlpDualBase>
{ }

public interface IGqlpInputField
  : IGqlpObjField<IGqlpInputBase>
  , IEquatable<IGqlpInputField>
{
  IGqlpConstant? DefaultValue { get; }
}

public interface IGqlpInputAlternate
  : IGqlpObjAlternate
  , IGqlpInputBase
  , IGqlpToDual<IGqlpDualAlternate>
{ }

public interface IGqlpOutputObject
  : IGqlpObject<IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate>
{ }

public interface IGqlpOutputEnum
  : IGqlpError
{
  IGqlpObjType EnumType { get; }
  string? EnumLabel { get; }

  void SetEnumType(string enumType);
}

public interface IGqlpOutputArg
  : IGqlpObjArg
  , IGqlpOutputEnum
  , IGqlpToDual<IGqlpDualArg>
{ }

public interface IGqlpOutputBase
  : IGqlpObjBase<IGqlpOutputArg>
  , IGqlpToDual<IGqlpDualBase>
{ }

public interface IGqlpOutputField
  : IGqlpObjField<IGqlpOutputBase>
  , IGqlpOutputEnum
  , IEquatable<IGqlpOutputField>
{
  IEnumerable<IGqlpInputParam> Params { get; }
}

public interface IGqlpOutputAlternate
  : IGqlpObjAlternate
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
