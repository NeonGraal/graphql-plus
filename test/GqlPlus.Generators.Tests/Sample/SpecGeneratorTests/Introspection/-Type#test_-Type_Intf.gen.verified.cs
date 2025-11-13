//HintName: test_-Type_Intf.gen.cs
// Generated from -Type.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp__Type;

public interface Itest_Type
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

public interface Itest_TypeField
{
}

public interface Itest_BaseType<Tkind>
  : Itest_Aliased
{
  public test_BaseType _BaseType { get; set; }
}

public interface Itest_BaseTypeField<Tkind>
  : Itest_AliasedField
{
  public Tkind typeKind { get; set; }
}

public interface Itest_ChildType<Tkind,Tparent>
  : Itest_BaseType
{
  public test_ChildType _ChildType { get; set; }
}

public interface Itest_ChildTypeField<Tkind,Tparent>
  : Itest_BaseTypeField
{
  public Tparent parent { get; set; }
}

public interface Itest_ParentType<Tkind,Titem,TallItem>
  : Itest_ChildType
{
  public test_ParentType _ParentType { get; set; }
}

public interface Itest_ParentTypeField<Tkind,Titem,TallItem>
  : Itest_ChildTypeField
{
  public ICollection<Titem> items { get; set; }
  public ICollection<TallItem> allItems { get; set; }
}

public interface Itest_TypeRef<Tkind>
  : Itest_Named
{
  public test_TypeRef _TypeRef { get; set; }
}

public interface Itest_TypeRefField<Tkind>
  : Itest_NamedField
{
  public Tkind typeKind { get; set; }
}

public interface Itest_TypeSimple
{
  public test_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public test_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public test_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public test_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public test_TypeSimple _TypeSimple { get; set; }
}

public interface Itest_TypeSimpleField
{
}

public interface Itest_Collections
{
  public test_Modifier<test_ModifierKind> As_Modifier { get; set; }
  public test_ModifierKeyed<test_ModifierKind> As_ModifierKeyed { get; set; }
  public test_ModifierKeyed<test_ModifierKind> As_ModifierKeyed { get; set; }
  public test_Collections _Collections { get; set; }
}

public interface Itest_CollectionsField
{
}

public interface Itest_ModifierKeyed<Tkind>
  : Itest_Modifier
{
  public test_ModifierKeyed _ModifierKeyed { get; set; }
}

public interface Itest_ModifierKeyedField<Tkind>
  : Itest_ModifierField
{
  public test_TypeSimple by { get; set; }
  public testBoolean optional { get; set; }
}

public interface Itest_Modifiers
{
  public test_Modifier<test_ModifierKind> As_Modifier { get; set; }
  public test_Collections As_Collections { get; set; }
  public test_Modifiers _Modifiers { get; set; }
}

public interface Itest_ModifiersField
{
}

public interface Itest_Modifier<Tkind>
{
  public test_Modifier _Modifier { get; set; }
}

public interface Itest_ModifierField<Tkind>
{
  public Tkind modifierKind { get; set; }
}
