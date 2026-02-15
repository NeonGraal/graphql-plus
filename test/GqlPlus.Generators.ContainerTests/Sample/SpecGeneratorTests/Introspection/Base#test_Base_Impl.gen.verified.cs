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
}

public class test_ObjTypeParam
  : test_Named
  , Itest_ObjTypeParam
{
  public Itest_TypeRef<Itest_TypeKind> Constraint { get; set; }
}

public class test_ObjBase
  : test_Named
  , Itest_ObjBase
{
  public ICollection<Itest_ObjTypeArg> TypeArgs { get; set; }
}

public class test_ObjTypeArg
  : test_TypeRef<Itest_TypeKind>
  , Itest_ObjTypeArg
{
  public Itest_Name? Label { get; set; }
}

public class test_TypeParam
  : test_Described
  , Itest_TypeParam
{
  public Itest_Name TypeParam { get; set; }
}

public class test_ObjAlternate
  : Itest_ObjAlternate
{
  public Itest_ObjBase Type { get; set; }
  public ICollection<Itest_Collections> Collections { get; set; }
}

public class test_ObjAlternateEnum
  : test_TypeRef<Itest_TypeKind>
  , Itest_ObjAlternateEnum
{
  public Itest_Name Label { get; set; }
}

public class test_ObjectFor<TFor>
  : Itest_ObjectFor<TFor>
{
  public Itest_Name ObjectType { get; set; }
}

public class test_ObjField<TType>
  : test_Aliased
  , Itest_ObjField<TType>
{
  public TType Type { get; set; }
}

public class test_ObjFieldType
  : test_ObjBase
  , Itest_ObjFieldType
{
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
}

public class test_ObjFieldEnum
  : test_TypeRef<Itest_TypeKind>
  , Itest_ObjFieldEnum
{
  public Itest_Name Label { get; set; }
}

public class test_ForParam<TType>
  : Itest_ForParam<TType>
{
}
