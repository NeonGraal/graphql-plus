//HintName: test_Base_Intf.gen.cs
// Generated from Base.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Base;

public interface Itest_ObjectKind
  : IDomainEnum
{
}

public interface Itest_TypeObject<Tkind,Tfield>
  : Itest_ChildType
{
  public test_TypeObject _TypeObject { get; set; }
}

public interface Itest_TypeObjectField<Tkind,Tfield>
  : Itest_ChildTypeField
{
  public ICollection<test_ObjTypeParam> typeParams { get; set; }
  public ICollection<Tfield> fields { get; set; }
  public ICollection<test_ObjAlternate> alternates { get; set; }
  public ICollection<test_ObjectFor<Tfield>> allFields { get; set; }
  public ICollection<test_ObjectFor<test_ObjAlternate>> allAlternates { get; set; }
}

public interface Itest_ObjTypeParam
  : Itest_Named
{
  public test_ObjTypeParam _ObjTypeParam { get; set; }
}

public interface Itest_ObjTypeParamField
  : Itest_NamedField
{
  public test_TypeRef<test_TypeKind> constraint { get; set; }
}

public interface Itest_ObjBase
  : Itest_Named
{
  public test_TypeParam As_TypeParam { get; set; }
  public test_ObjBase _ObjBase { get; set; }
}

public interface Itest_ObjBaseField
  : Itest_NamedField
{
  public ICollection<test_ObjTypeArg> typeArgs { get; set; }
}

public interface Itest_ObjTypeArg
  : Itest_TypeRef
{
  public test_TypeParam As_TypeParam { get; set; }
  public test_ObjTypeArg _ObjTypeArg { get; set; }
}

public interface Itest_ObjTypeArgField
  : Itest_TypeRefField
{
  public test_Name? label { get; set; }
}

public interface Itest_TypeParam
  : Itest_Described
{
  public test_TypeParam _TypeParam { get; set; }
}

public interface Itest_TypeParamField
  : Itest_DescribedField
{
  public test_Name typeParam { get; set; }
}

public interface Itest_ObjAlternate
{
  public test_ObjAlternateEnum As_ObjAlternateEnum { get; set; }
  public test_ObjAlternate _ObjAlternate { get; set; }
}

public interface Itest_ObjAlternateField
{
  public test_ObjBase type { get; set; }
  public ICollection<test_Collections> collections { get; set; }
}

public interface Itest_ObjAlternateEnum
  : Itest_TypeRef
{
  public test_ObjAlternateEnum _ObjAlternateEnum { get; set; }
}

public interface Itest_ObjAlternateEnumField
  : Itest_TypeRefField
{
  public test_Name label { get; set; }
}

public interface Itest_ObjectFor<Tfor>
  : Itestfor
{
  public test_ObjectFor _ObjectFor { get; set; }
}

public interface Itest_ObjectForField<Tfor>
  : ItestforField
{
  public test_Name object { get; set; }
}

public interface Itest_ObjField<Ttype>
  : Itest_Aliased
{
  public test_ObjField _ObjField { get; set; }
}

public interface Itest_ObjFieldField<Ttype>
  : Itest_AliasedField
{
  public Ttype type { get; set; }
}

public interface Itest_ObjFieldType
  : Itest_ObjBase
{
  public test_ObjFieldEnum As_ObjFieldEnum { get; set; }
  public test_ObjFieldType _ObjFieldType { get; set; }
}

public interface Itest_ObjFieldTypeField
  : Itest_ObjBaseField
{
  public ICollection<test_Modifiers> modifiers { get; set; }
}

public interface Itest_ObjFieldEnum
  : Itest_TypeRef
{
  public test_ObjFieldEnum _ObjFieldEnum { get; set; }
}

public interface Itest_ObjFieldEnumField
  : Itest_TypeRefField
{
  public test_Name label { get; set; }
}

public interface Itest_ForParam<Ttype>
{
  public test_ObjAlternate As_ObjAlternate { get; set; }
  public test_ObjField<Ttype> As_ObjField { get; set; }
  public test_ForParam _ForParam { get; set; }
}

public interface Itest_ForParamField<Ttype>
{
}
