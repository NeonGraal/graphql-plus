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

public interface Itest_TypeObjectObject<Tkind,Tfield>
  : Itest_ChildTypeObject
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

public interface Itest_ObjTypeParamObject
  : Itest_NamedObject
{
  public test_TypeRef<test_TypeKind> constraint { get; set; }
}

public interface Itest_ObjBase
  : Itest_Named
{
  public test_TypeParam As_TypeParam { get; set; }
  public test_ObjBase _ObjBase { get; set; }
}

public interface Itest_ObjBaseObject
  : Itest_NamedObject
{
  public ICollection<test_ObjTypeArg> typeArgs { get; set; }
}

public interface Itest_ObjTypeArg
  : Itest_TypeRef
{
  public test_TypeParam As_TypeParam { get; set; }
  public test_ObjTypeArg _ObjTypeArg { get; set; }
}

public interface Itest_ObjTypeArgObject
  : Itest_TypeRefObject
{
  public test_Name? label { get; set; }
}

public interface Itest_TypeParam
  : Itest_Described
{
  public test_TypeParam _TypeParam { get; set; }
}

public interface Itest_TypeParamObject
  : Itest_DescribedObject
{
  public test_Name typeParam { get; set; }
}

public interface Itest_ObjAlternate
{
  public test_ObjAlternateEnum As_ObjAlternateEnum { get; set; }
  public test_ObjAlternate _ObjAlternate { get; set; }
}

public interface Itest_ObjAlternateObject
{
  public test_ObjBase type { get; set; }
  public ICollection<test_Collections> collections { get; set; }
}

public interface Itest_ObjAlternateEnum
  : Itest_TypeRef
{
  public test_ObjAlternateEnum _ObjAlternateEnum { get; set; }
}

public interface Itest_ObjAlternateEnumObject
  : Itest_TypeRefObject
{
  public test_Name label { get; set; }
}

public interface Itest_ObjectFor<Tfor>
  : Itestfor
{
  public test_ObjectFor _ObjectFor { get; set; }
}

public interface Itest_ObjectForObject<Tfor>
  : ItestforObject
{
  public test_Name object { get; set; }
}

public interface Itest_ObjField<Ttype>
  : Itest_Aliased
{
  public test_ObjField _ObjField { get; set; }
}

public interface Itest_ObjFieldObject<Ttype>
  : Itest_AliasedObject
{
  public Ttype type { get; set; }
}

public interface Itest_ObjFieldType
  : Itest_ObjBase
{
  public test_ObjFieldEnum As_ObjFieldEnum { get; set; }
  public test_ObjFieldType _ObjFieldType { get; set; }
}

public interface Itest_ObjFieldTypeObject
  : Itest_ObjBaseObject
{
  public ICollection<test_Modifiers> modifiers { get; set; }
}

public interface Itest_ObjFieldEnum
  : Itest_TypeRef
{
  public test_ObjFieldEnum _ObjFieldEnum { get; set; }
}

public interface Itest_ObjFieldEnumObject
  : Itest_TypeRefObject
{
  public test_Name label { get; set; }
}

public interface Itest_ForParam<Ttype>
{
  public test_ObjAlternate As_ObjAlternate { get; set; }
  public test_ObjField<Ttype> As_ObjField { get; set; }
  public test_ForParam _ForParam { get; set; }
}

public interface Itest_ForParamObject<Ttype>
{
}
