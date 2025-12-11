//HintName: test_-Type_Impl.gen.cs
// Generated from -Type.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Type;

public class test_Type
  : Itest_Type
{
  public test_BaseType<test_TypeKind> As_BaseType { get; set; }
  public test_BaseType<test_TypeKind> As_BaseType { get; set; }
  public test_BaseDomain<test_DomainKind, test_DomainTrueFalse, test_DomainItemTrueFalse> As_BaseDomain { get; set; }
  public test_BaseDomain<test_DomainKind, test_DomainLabel, test_DomainItemLabel> As_BaseDomain { get; set; }
  public test_BaseDomain<test_DomainKind, test_DomainRange, test_DomainItemRange> As_BaseDomain { get; set; }
  public test_BaseDomain<test_DomainKind, test_DomainRegex, test_DomainItemRegex> As_BaseDomain { get; set; }
  public test_ParentType<test_TypeKind, test_Aliased, test_EnumLabel> As_ParentType { get; set; }
  public test_ParentType<test_TypeKind, test_UnionRef, test_UnionMember> As_ParentType { get; set; }
  public test_TypeObject<test_TypeKind, test_DualField> As_TypeObject { get; set; }
  public test_TypeObject<test_TypeKind, test_InputField> As_TypeObject { get; set; }
  public test_TypeObject<test_TypeKind, test_OutputField> As_TypeObject { get; set; }
  public test_Type _Type { get; set; }
}

public class test_BaseType<Tkind>
  : test_Aliased
  , Itest_BaseType<Tkind>
{
  public Tkind typeKind { get; set; }
  public test_BaseType _BaseType { get; set; }
}

public class test_ChildType<Tkind,Tparent>
  : test_BaseType
  , Itest_ChildType<Tkind,Tparent>
{
  public Tparent parent { get; set; }
  public test_ChildType _ChildType { get; set; }
}

public class test_ParentType<Tkind,Titem,TallItem>
  : test_ChildType
  , Itest_ParentType<Tkind,Titem,TallItem>
{
  public ICollection<Titem> items { get; set; }
  public ICollection<TallItem> allItems { get; set; }
  public test_ParentType _ParentType { get; set; }
}

public class test_TypeRef<Tkind>
  : test_Named
  , Itest_TypeRef<Tkind>
{
  public Tkind typeKind { get; set; }
  public test_TypeRef _TypeRef { get; set; }
}

public class test_TypeSimple
  : Itest_TypeSimple
{
  public test_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public test_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public test_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public test_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public test_TypeSimple _TypeSimple { get; set; }
}

public class test_Collections
  : Itest_Collections
{
  public test_Modifier<test_ModifierKind> As_Modifier { get; set; }
  public test_ModifierKeyed<test_ModifierKind> As_ModifierKeyed { get; set; }
  public test_ModifierKeyed<test_ModifierKind> As_ModifierKeyed { get; set; }
  public test_Collections _Collections { get; set; }
}

public class test_ModifierKeyed<Tkind>
  : test_Modifier
  , Itest_ModifierKeyed<Tkind>
{
  public test_TypeSimple by { get; set; }
  public testBoolean optional { get; set; }
  public test_ModifierKeyed _ModifierKeyed { get; set; }
}

public class test_Modifiers
  : Itest_Modifiers
{
  public test_Modifier<test_ModifierKind> As_Modifier { get; set; }
  public test_Collections As_Collections { get; set; }
  public test_Modifiers _Modifiers { get; set; }
}

public class test_Modifier<Tkind>
  : Itest_Modifier<Tkind>
{
  public Tkind modifierKind { get; set; }
  public test_Modifier _Modifier { get; set; }
}
