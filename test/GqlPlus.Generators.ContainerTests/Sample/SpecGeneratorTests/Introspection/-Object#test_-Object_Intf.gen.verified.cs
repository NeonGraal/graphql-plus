//HintName: test_-Object_Intf.gen.cs
// Generated from -Object.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Object;

public interface Itest_ObjectKind
  : IDomainEnum
{
}

public interface Itest_TypeObject<Tkind,Tfield>
  : Itest_ChildType
{
  public Itest_TypeObjectObject As_TypeObject { get; set; }
}

public interface Itest_TypeObjectObject<Tkind,Tfield>
  : Itest_ChildTypeObject
{
  public ICollection<Itest_ObjTypeParam> TypeParams { get; set; }
  public ICollection<Tfield> Fields { get; set; }
  public ICollection<Itest_ObjAlternate> Alternates { get; set; }
  public ICollection<Itest_ObjectFor<Tfield>> AllFields { get; set; }
  public ICollection<Itest_ObjectFor<Itest_ObjAlternate>> AllAlternates { get; set; }
}

public interface Itest_ObjTypeParam
  : Itest_Named
{
  public Itest_ObjTypeParamObject As_ObjTypeParam { get; set; }
}

public interface Itest_ObjTypeParamObject
  : Itest_NamedObject
{
  public Itest_TypeRef<Itest_TypeKind> Constraint { get; set; }
}

public interface Itest_ObjBase
  : Itest_Named
{
  public Itest_TypeParam As_TypeParam { get; set; }
  public Itest_ObjBaseObject As_ObjBase { get; set; }
}

public interface Itest_ObjBaseObject
  : Itest_NamedObject
{
  public ICollection<Itest_ObjTypeArg> TypeArgs { get; set; }
}

public interface Itest_ObjTypeArg
  : Itest_TypeRef
{
  public Itest_TypeParam As_TypeParam { get; set; }
  public Itest_ObjTypeArgObject As_ObjTypeArg { get; set; }
}

public interface Itest_ObjTypeArgObject
  : Itest_TypeRefObject
{
  public Itest_Name? Label { get; set; }
}

public interface Itest_TypeParam
  : Itest_Described
{
  public Itest_TypeParamObject As_TypeParam { get; set; }
}

public interface Itest_TypeParamObject
  : Itest_DescribedObject
{
  public Itest_Name TypeParam { get; set; }
}

public interface Itest_ObjAlternate
{
  public Itest_ObjAlternateEnum As_ObjAlternateEnum { get; set; }
  public Itest_ObjAlternateObject As_ObjAlternate { get; set; }
}

public interface Itest_ObjAlternateObject
{
  public Itest_ObjBase Type { get; set; }
  public ICollection<Itest_Collections> Collections { get; set; }
}

public interface Itest_ObjAlternateEnum
  : Itest_TypeRef
{
  public Itest_ObjAlternateEnumObject As_ObjAlternateEnum { get; set; }
}

public interface Itest_ObjAlternateEnumObject
  : Itest_TypeRefObject
{
  public Itest_Name Label { get; set; }
}

public interface Itest_ObjectFor<Tfor>
  : Itestfor
{
  public Itest_ObjectForObject As_ObjectFor { get; set; }
}

public interface Itest_ObjectForObject<Tfor>
  : ItestforObject
{
  public Itest_Name Object { get; set; }
}

public interface Itest_ObjField<Ttype>
  : Itest_Aliased
{
  public Itest_ObjFieldObject As_ObjField { get; set; }
}

public interface Itest_ObjFieldObject<Ttype>
  : Itest_AliasedObject
{
  public Ttype Type { get; set; }
}

public interface Itest_ObjFieldType
  : Itest_ObjBase
{
  public Itest_ObjFieldEnum As_ObjFieldEnum { get; set; }
  public Itest_ObjFieldTypeObject As_ObjFieldType { get; set; }
}

public interface Itest_ObjFieldTypeObject
  : Itest_ObjBaseObject
{
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
}

public interface Itest_ObjFieldEnum
  : Itest_TypeRef
{
  public Itest_ObjFieldEnumObject As_ObjFieldEnum { get; set; }
}

public interface Itest_ObjFieldEnumObject
  : Itest_TypeRefObject
{
  public Itest_Name Label { get; set; }
}

public interface Itest_ForParam<Ttype>
{
  public Itest_ObjAlternate As_ObjAlternate { get; set; }
  public Itest_ObjField<Ttype> As_ObjField { get; set; }
  public Itest_ForParamObject As_ForParam { get; set; }
}

public interface Itest_ForParamObject<Ttype>
{
}

public interface Itest_DualField
  : Itest_ObjField
{
  public Itest_DualFieldObject As_DualField { get; set; }
}

public interface Itest_DualFieldObject
  : Itest_ObjFieldObject
{
}

public interface Itest_InputField
  : Itest_ObjField
{
  public Itest_InputFieldObject As_InputField { get; set; }
}

public interface Itest_InputFieldObject
  : Itest_ObjFieldObject
{
}

public interface Itest_InputFieldType
  : Itest_ObjFieldType
{
  public Itest_InputFieldTypeObject As_InputFieldType { get; set; }
}

public interface Itest_InputFieldTypeObject
  : Itest_ObjFieldTypeObject
{
  public Itest_Value? Default { get; set; }
}

public interface Itest_InputParam
  : Itest_InputFieldType
{
  public Itest_InputParamObject As_InputParam { get; set; }
}

public interface Itest_InputParamObject
  : Itest_InputFieldTypeObject
{
}

public interface Itest_OutputField
  : Itest_ObjField
{
  public Itest_OutputFieldObject As_OutputField { get; set; }
}

public interface Itest_OutputFieldObject
  : Itest_ObjFieldObject
{
}

public interface Itest_OutputFieldType
  : Itest_ObjFieldType
{
  public Itest_OutputFieldTypeObject As_OutputFieldType { get; set; }
}

public interface Itest_OutputFieldTypeObject
  : Itest_ObjFieldTypeObject
{
  public ICollection<Itest_InputParam> Parameters { get; set; }
}
