//HintName: test_Base_Impl.gen.cs
// Generated from Base.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Base;

public class test_ObjectKind
  : GqlpDomainEnum
  , Itest_ObjectKind
{
}

public class test_TypeObject<TKind,TField>
  : test_ChildType<TKind, Itest_ObjBase>
  , Itest_TypeObject<TKind,TField>
{
  public ICollection<Itest_ObjTypeParam> TypeParams { get; set; }
  public ICollection<TField> Fields { get; set; }
  public ICollection<Itest_ObjAlternate> Alternates { get; set; }
  public ICollection<Itest_ObjectFor<TField>> AllFields { get; set; }
  public ICollection<Itest_ObjectFor<Itest_ObjAlternate>> AllAlternates { get; set; }
  public Itest_TypeObjectObject<TKind,TField> As_TypeObject { get; set; }
}

public class test_ObjTypeParam
  : test_Named
  , Itest_ObjTypeParam
{
  public Itest_TypeRef<Itest_TypeKind> Constraint { get; set; }
  public Itest_ObjTypeParamObject As_ObjTypeParam { get; set; }
}

public class test_ObjBase
  : test_Named
  , Itest_ObjBase
{
  public ICollection<Itest_ObjTypeArg> TypeArgs { get; set; }
  public Itest_TypeParam As_TypeParam { get; set; }
  public Itest_ObjBaseObject As_ObjBase { get; set; }
}

public class test_ObjTypeArg
  : test_TypeRef<Itest_TypeKind>
  , Itest_ObjTypeArg
{
  public Itest_Name? Label { get; set; }
  public Itest_TypeParam As_TypeParam { get; set; }
  public Itest_ObjTypeArgObject As_ObjTypeArg { get; set; }
}

public class test_TypeParam
  : test_Described
  , Itest_TypeParam
{
  public Itest_Name TypeParam { get; set; }
  public Itest_TypeParamObject As_TypeParam { get; set; }
}

public class test_ObjAlternate
  : Itest_ObjAlternate
{
  public Itest_ObjBase Type { get; set; }
  public ICollection<Itest_Collections> Collections { get; set; }
  public Itest_ObjAlternateEnum As_ObjAlternateEnum { get; set; }
  public Itest_ObjAlternateObject As_ObjAlternate { get; set; }
}

public class test_ObjAlternateEnum
  : test_TypeRef<Itest_TypeKind>
  , Itest_ObjAlternateEnum
{
  public Itest_Name Label { get; set; }
  public Itest_ObjAlternateEnumObject As_ObjAlternateEnum { get; set; }
}

public class test_ObjectFor<TFor>
  : Itest_ObjectFor<TFor>
{
  public Itest_Name ObjectType { get; set; }
  public TFor AsParent { get; set; }
  public Itest_ObjectForObject<TFor> As_ObjectFor { get; set; }
}

public class test_ObjField<TType>
  : test_Aliased
  , Itest_ObjField<TType>
{
  public TType Type { get; set; }
  public Itest_ObjFieldObject<TType> As_ObjField { get; set; }
}

public class test_ObjFieldType
  : test_ObjBase
  , Itest_ObjFieldType
{
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
  public Itest_ObjFieldEnum As_ObjFieldEnum { get; set; }
  public Itest_ObjFieldTypeObject As_ObjFieldType { get; set; }
}

public class test_ObjFieldEnum
  : test_TypeRef<Itest_TypeKind>
  , Itest_ObjFieldEnum
{
  public Itest_Name Label { get; set; }
  public Itest_ObjFieldEnumObject As_ObjFieldEnum { get; set; }
}

public class test_ForParam<TType>
  : Itest_ForParam<TType>
{
  public Itest_ObjAlternate As_ObjAlternate { get; set; }
  public Itest_ObjField<TType> As_ObjField { get; set; }
  public Itest_ForParamObject<TType> As_ForParam { get; set; }
}
