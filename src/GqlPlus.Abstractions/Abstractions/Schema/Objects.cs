namespace GqlPlus.Abstractions.Schema;

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
