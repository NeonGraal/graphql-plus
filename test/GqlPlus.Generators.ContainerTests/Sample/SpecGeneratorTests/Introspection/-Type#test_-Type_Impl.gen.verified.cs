//HintName: test_-Type_Impl.gen.cs
// Generated from -Type.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Type;

public class test_Type
  : Itest_Type
{
  public Itest_BaseType<test_TypeKind> As_TypeKindBasic { get; set; }
  public Itest_BaseType<test_TypeKind> As_TypeKindInternal { get; set; }
  public Itest_BaseDomain<Itest_DomainKind, Itest_DomainTrueFalse, Itest_DomainItemTrueFalse> As_DomainKindBoolean { get; set; }
  public Itest_BaseDomain<Itest_DomainKind, Itest_DomainLabel, Itest_DomainItemLabel> As_DomainKindEnum { get; set; }
  public Itest_BaseDomain<Itest_DomainKind, Itest_DomainRange, Itest_DomainItemRange> As_DomainKindNumber { get; set; }
  public Itest_BaseDomain<Itest_DomainKind, Itest_DomainRegex, Itest_DomainItemRegex> As_DomainKindString { get; set; }
  public Itest_ParentType<test_TypeKind, Itest_Aliased, Itest_EnumLabel> As_TypeKindEnum { get; set; }
  public Itest_ParentType<test_TypeKind, Itest_UnionRef, Itest_UnionMember> As_TypeKindUnion { get; set; }
  public Itest_TypeObject<test_TypeKind, Itest_DualField> As_TypeKindDual { get; set; }
  public Itest_TypeObject<test_TypeKind, Itest_InputField> As_TypeKindInput { get; set; }
  public Itest_TypeObject<test_TypeKind, Itest_OutputField> As_TypeKindOutput { get; set; }
  public Itest_TypeObject As_Type { get; set; }
}

public class test_BaseType<TKind>
  : test_Aliased
  , Itest_BaseType<TKind>
{
  public TKind TypeKind { get; set; }
  public Itest_BaseTypeObject<TKind> As_BaseType { get; set; }
}

public class test_ChildType<TKind,TParent>
  : test_BaseType<TKind>
  , Itest_ChildType<TKind,TParent>
{
  public TParent Parent { get; set; }
  public Itest_ChildTypeObject<TKind,TParent> As_ChildType { get; set; }
}

public class test_ParentType<TKind,TItem,TAllItem>
  : test_ChildType<TKind, Itest_Named>
  , Itest_ParentType<TKind,TItem,TAllItem>
{
  public ICollection<TItem> Items { get; set; }
  public ICollection<TAllItem> AllItems { get; set; }
  public Itest_ParentTypeObject<TKind,TItem,TAllItem> As_ParentType { get; set; }
}

public class test_TypeRef<TKind>
  : test_Named
  , Itest_TypeRef<TKind>
{
  public TKind TypeKind { get; set; }
  public Itest_TypeRefObject<TKind> As_TypeRef { get; set; }
}

public class test_TypeSimple
  : Itest_TypeSimple
{
  public Itest_TypeRef<test_TypeKind> As_TypeKindBasic { get; set; }
  public Itest_TypeRef<test_TypeKind> As_TypeKindEnum { get; set; }
  public Itest_TypeRef<test_TypeKind> As_TypeKindDomain { get; set; }
  public Itest_TypeRef<test_TypeKind> As_TypeKindUnion { get; set; }
  public Itest_TypeSimpleObject As_TypeSimple { get; set; }
}

public class test_Collections
  : Itest_Collections
{
  public Itest_Modifier<test_ModifierKind> As_ModifierKindList { get; set; }
  public Itest_ModifierKeyed<test_ModifierKind> As_ModifierKindDictionary { get; set; }
  public Itest_ModifierKeyed<test_ModifierKind> As_ModifierKindTypeParam { get; set; }
  public Itest_CollectionsObject As_Collections { get; set; }
}

public class test_ModifierKeyed<TKind>
  : test_Modifier<TKind>
  , Itest_ModifierKeyed<TKind>
{
  public Itest_TypeSimple By { get; set; }
  public bool IsOptional { get; set; }
  public Itest_ModifierKeyedObject<TKind> As_ModifierKeyed { get; set; }
}

public class test_Modifiers
  : Itest_Modifiers
{
  public Itest_Modifier<test_ModifierKind> As_ModifierKindOptional { get; set; }
  public Itest_Collections As_Collections { get; set; }
  public Itest_ModifiersObject As_Modifiers { get; set; }
}

public class test_Modifier<TKind>
  : Itest_Modifier<TKind>
{
  public TKind ModifierKind { get; set; }
  public Itest_ModifierObject<TKind> As_Modifier { get; set; }
}
