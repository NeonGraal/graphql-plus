namespace GqlPlus.Abstractions.Schema;

public interface IAstObject
  : IAstType<IAstObjBase>
{
  IEnumerable<IAstTypeParam> TypeParams { get; }
  IEnumerable<IAstObjField> Fields { get; }
  IEnumerable<IAstAlternate> Alternates { get; }
}

public interface IAstObject<TField>
  : IAstObject
  , IEquatable<IAstObject<TField>>
  where TField : IAstObjField
{
  IEnumerable<TField> ObjFields { get; }
}

public interface IAstObjType
  : IAstNamed
  , IEquatable<IAstObjType>
{
  bool IsTypeParam { get; }

  string TypeName { get; }
  string FullType { get; }
}

public interface IAstObjEnum
  : IAstAbbreviated
{
  string EnumTypeName { get; }
  IAstEnumValue? EnumValue { get; }

  void SetEnumType(string enumType);
}

public interface IAstTypeArg
  : IAstObjType
  , IAstObjEnum
  , IEquatable<IAstTypeArg>
{ }

public interface IAstObjBase
  : IAstObjType
  , IEquatable<IAstObjBase>
{
  IEnumerable<IAstTypeArg> Args { get; }

  void SetName(string name);
}

public interface IAstObjFieldType
  : IAstError
  , IAstModifiers
  , IAstObjEnum
{
  IAstObjBase Type { get; }
  string ModifiedType { get; }
}

public interface IAstObjField
  : IAstAliased
  , IAstObjFieldType
{ }

public interface IAstAlternate
  : IAstObjBase
  , IAstModifiers
  , IAstObjEnum
{ }

public interface IAstTypeParam
  : IAstNamed
{
  string Constraint { get; }
}

public interface IAstDualField
  : IAstObjField
{ }

public interface IAstInputFieldType
  : IAstObjFieldType
{
  IAstConstant? DefaultValue { get; }
}

public interface IAstInputField
  : IAstObjField
  , IAstInputFieldType
  , IEquatable<IAstInputField>
{ }

public interface IAstOutputField
  : IAstObjField
  , IEquatable<IAstOutputField>
{
  IAstInputParam? Parameter { get; }
}

public interface IAstInputParam
  : IAstDescribed
  , IAstInputFieldType
  , IEquatable<IAstInputParam>
{ }
