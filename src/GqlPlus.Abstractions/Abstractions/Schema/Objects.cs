namespace GqlPlus.Abstractions.Schema;

public interface IGqlpObject
  : IGqlpType<IGqlpObjBase>
{
  IEnumerable<IGqlpTypeParam> TypeParams { get; }
  IEnumerable<IGqlpObjField> Fields { get; }
  IEnumerable<IGqlpAlternate> Alternates { get; }
}

public interface IGqlpObject<TField>
  : IGqlpObject
  , IEquatable<IGqlpObject<TField>>
  where TField : IGqlpObjField
{
  IEnumerable<TField> ObjFields { get; }
}

public interface IGqlpFieldKind<TField>
  where TField : IGqlpObjField
{
  TypeKind FieldKind { get; }
}

public interface IGqlpObjType
  : IGqlpNamed
  , IEquatable<IGqlpObjType>
{
  bool IsTypeParam { get; }

  string TypeName { get; }
  string FullType { get; }
}

public interface IGqlpObjEnum
  : IGqlpError
{
  string EnumTypeName { get; }
  IGqlpEnumValue? EnumValue { get; }

  void SetEnumType(string enumType);
}

public interface IGqlpTypeArg
  : IGqlpObjType
  , IGqlpObjEnum
  , IEquatable<IGqlpTypeArg>
{ }

public interface IGqlpObjBase
  : IGqlpObjType
  , IEquatable<IGqlpObjBase>
{
  IEnumerable<IGqlpTypeArg> Args { get; }

  void SetName(string name);
}

public interface IGqlpObjFieldType
  : IGqlpError
  , IGqlpModifiers
  , IGqlpObjEnum
{
  IGqlpObjBase Type { get; }
  string ModifiedType { get; }
}

public interface IGqlpObjField
  : IGqlpAliased
  , IGqlpObjFieldType
{ }

public interface IGqlpAlternate
  : IGqlpObjBase
  , IGqlpModifiers
  , IGqlpObjEnum
{ }

public interface IGqlpTypeParam
  : IGqlpNamed
{
  string Constraint { get; }
}

public interface IGqlpDualField
  : IGqlpObjField
{ }

public interface IGqlpInputFieldType
  : IGqlpObjFieldType
{
  IGqlpConstant? DefaultValue { get; }
}

public interface IGqlpInputField
  : IGqlpObjField
  , IGqlpInputFieldType
  , IEquatable<IGqlpInputField>
{ }

public interface IGqlpOutputField
  : IGqlpObjField
  , IEquatable<IGqlpOutputField>
{
  IEnumerable<IGqlpInputParam> Params { get; }
}

public interface IGqlpInputParam
  : IGqlpDescribed
  , IGqlpInputFieldType
  , IEquatable<IGqlpInputParam>
{ }
