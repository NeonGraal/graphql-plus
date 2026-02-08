//HintName: test_Base_Impl.gen.cs
// Generated from Base.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Base;

public class test_ObjectKind
  : DomainEnum
  , Itest_ObjectKind
{
}

public class test_TypeObject<Tkind,Tfield>
  : test_ChildType
  , Itest_TypeObject<Tkind,Tfield>
{
  public ICollection<Itest_ObjTypeParam> TypeParams { get; set; }
  public ICollection<Tfield> Fields { get; set; }
  public ICollection<Itest_ObjAlternate> Alternates { get; set; }
  public ICollection<Itest_ObjectFor<Tfield>> AllFields { get; set; }
  public ICollection<Itest_ObjectFor<Itest_ObjAlternate>> AllAlternates { get; set; }
  public Itest_TypeObjectObject As_TypeObject { get; set; }
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
  : test_TypeRef
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
  : test_TypeRef
  , Itest_ObjAlternateEnum
{
  public Itest_Name Label { get; set; }
  public Itest_ObjAlternateEnumObject As_ObjAlternateEnum { get; set; }
}

public class test_ObjectFor<Tfor>
  : testfor
  , Itest_ObjectFor<Tfor>
{
  public Itest_Name Object { get; set; }
  public Itest_ObjectForObject As_ObjectFor { get; set; }
}

public class test_ObjField<Ttype>
  : test_Aliased
  , Itest_ObjField<Ttype>
{
  public Ttype Type { get; set; }
  public Itest_ObjFieldObject As_ObjField { get; set; }
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
  : test_TypeRef
  , Itest_ObjFieldEnum
{
  public Itest_Name Label { get; set; }
  public Itest_ObjFieldEnumObject As_ObjFieldEnum { get; set; }
}

public class test_ForParam<Ttype>
  : Itest_ForParam<Ttype>
{
  public Itest_ObjAlternate As_ObjAlternate { get; set; }
  public Itest_ObjField<Ttype> As_ObjField { get; set; }
  public Itest_ForParamObject As_ForParam { get; set; }
}
