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

public interface IGqlpObjType
  : IAstNamed
  , IEquatable<IGqlpObjType>
{
  bool IsTypeParam { get; }

  string TypeName { get; }
  string FullType { get; }
}

public interface IGqlpObjEnum
  : IAstAbbreviated
{
  string EnumTypeName { get; }
  IAstEnumValue? EnumValue { get; }

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
  : IAstError
  , IAstModifiers
  , IGqlpObjEnum
{
  IGqlpObjBase Type { get; }
  string ModifiedType { get; }
}

public interface IGqlpObjField
  : IAstAliased
  , IGqlpObjFieldType
{ }

public interface IGqlpAlternate
  : IGqlpObjBase
  , IAstModifiers
  , IGqlpObjEnum
{ }

public interface IGqlpTypeParam
  : IAstNamed
{
  string Constraint { get; }
}

public interface IGqlpDualField
  : IGqlpObjField
{ }

public interface IGqlpInputFieldType
  : IGqlpObjFieldType
{
  IAstConstant? DefaultValue { get; }
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
  IGqlpInputParam? Parameter { get; }
}

public interface IGqlpInputParam
  : IAstDescribed
  , IGqlpInputFieldType
  , IEquatable<IGqlpInputParam>
{ }
