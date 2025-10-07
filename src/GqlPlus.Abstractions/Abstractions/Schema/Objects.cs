﻿namespace GqlPlus.Abstractions.Schema;

public interface IGqlpObject
  : IGqlpType<IGqlpObjBase>
{
  IEnumerable<IGqlpTypeParam> TypeParams { get; }
  IEnumerable<IGqlpObjField> Fields { get; }
  IEnumerable<IGqlpObjAlt> Alternates { get; }
}

public interface IGqlpObject<TField>
  : IGqlpObject
  , IEquatable<IGqlpObject<TField>>
  where TField : IGqlpObjField
{
  IEnumerable<TField> ObjFields { get; }
}

public interface IGqlpObjType
  : IGqlpNamed
  , IEquatable<IGqlpObjType>
{
  bool IsTypeParam { get; }

  string TypeName { get; }
  string FullType { get; }
}

public interface IGqlpObjectEnum
  : IGqlpError
{
  string EnumTypeName { get; }
  IGqlpEnumValue? EnumValue { get; }

  void SetEnumType(string enumType);
}

public interface IGqlpObjTypeArg
  : IGqlpObjType
  , IGqlpObjectEnum
  , IEquatable<IGqlpObjTypeArg>
{ }

public interface IGqlpObjBase
  : IGqlpObjType
  , IEquatable<IGqlpObjBase>
{
  IEnumerable<IGqlpObjTypeArg> Args { get; }

  void SetName(string name);
}

public interface IGqlpObjField
  : IGqlpAliased
  , IGqlpObjectEnum
  , IGqlpModifiers
{
  IGqlpObjBase Type { get; }
  string ModifiedType { get; }
}

public interface IGqlpObjAlt
  : IGqlpError
  , IGqlpObjBase
  , IGqlpModifiers
  , IGqlpObjectEnum
{ }

public interface IGqlpTypeParam
  : IGqlpNamed
{
  string Constraint { get; }
}

public interface IGqlpDualObject
  : IGqlpObject<IGqlpDualField>
{ }

public interface IGqlpDualField
  : IGqlpObjField
{ }

public interface IGqlpInputObject
  : IGqlpObject<IGqlpInputField>
{ }

public interface IGqlpInputField
  : IGqlpObjField
  , IEquatable<IGqlpInputField>
{
  IGqlpConstant? DefaultValue { get; }
}

public interface IGqlpOutputObject
  : IGqlpObject<IGqlpOutputField>
{ }

public interface IGqlpOutputField
  : IGqlpObjField
  , IEquatable<IGqlpOutputField>
{
  IEnumerable<IGqlpInputParam> Params { get; }
}

public interface IGqlpInputParam
  : IGqlpDescribed
  , IGqlpModifiers
  , IEquatable<IGqlpInputParam>
{
  IGqlpObjBase Type { get; }
  IGqlpConstant? DefaultValue { get; }
}
