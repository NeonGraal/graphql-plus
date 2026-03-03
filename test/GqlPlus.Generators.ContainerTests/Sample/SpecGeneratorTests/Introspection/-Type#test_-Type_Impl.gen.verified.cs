//HintName: test_-Type_Impl.gen.cs
// Generated from {CurrentDirectory}-Type.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Type;

public class test_Type
  : GqlpModelImplementationBase
  , Itest_Type
{
  public Itest_BaseType<test_TypeKind>? As_TypeKindBasic { get; set; }
  public Itest_BaseType<test_TypeKind>? As_TypeKindInternal { get; set; }
  public Itest_BaseDomain<Itest_DomainKind, Itest_DomainTrueFalse, Itest_DomainItemTrueFalse>? As_DomainKindBoolean { get; set; }
  public Itest_BaseDomain<Itest_DomainKind, Itest_DomainLabel, Itest_DomainItemLabel>? As_DomainKindEnum { get; set; }
  public Itest_BaseDomain<Itest_DomainKind, Itest_DomainRange, Itest_DomainItemRange>? As_DomainKindNumber { get; set; }
  public Itest_BaseDomain<Itest_DomainKind, Itest_DomainRegex, Itest_DomainItemRegex>? As_DomainKindString { get; set; }
  public Itest_ParentType<test_TypeKind, Itest_Aliased, Itest_EnumLabel>? As_TypeKindEnum { get; set; }
  public Itest_ParentType<test_TypeKind, Itest_UnionRef, Itest_UnionMember>? As_TypeKindUnion { get; set; }
  public Itest_TypeObject<test_TypeKind, Itest_DualField>? As_TypeKindDual { get; set; }
  public Itest_TypeObject<test_TypeKind, Itest_InputField>? As_TypeKindInput { get; set; }
  public Itest_TypeObject<test_TypeKind, Itest_OutputField>? As_TypeKindOutput { get; set; }
  public Itest_TypeObject? As__Type { get; set; }
}

public class test_TypeObject
  : GqlpModelImplementationBase
  , Itest_TypeObject
{

  public test_TypeObject
    ()
  {
  }
}

public class test_BaseType<TKind>
  : test_Aliased
  , Itest_BaseType<TKind>
{
  public Itest_BaseTypeObject<TKind>? As__BaseType { get; set; }
}

public class test_BaseTypeObject<TKind>
  : test_AliasedObject
  , Itest_BaseTypeObject<TKind>
{
  public TKind TypeKind { get; set; }

  public test_BaseTypeObject
    ( TKind typeKind
    )
  {
    TypeKind = typeKind;
  }
}

public class test_ChildType<TKind,TParent>
  : test_BaseType<TKind>
  , Itest_ChildType<TKind,TParent>
{
  public Itest_ChildTypeObject<TKind,TParent>? As__ChildType { get; set; }
}

public class test_ChildTypeObject<TKind,TParent>
  : test_BaseTypeObject<TKind>
  , Itest_ChildTypeObject<TKind,TParent>
{
  public TParent Parent { get; set; }

  public test_ChildTypeObject
    ( TKind typeKind
    , TParent parent
    ) : base(typeKind)
  {
    Parent = parent;
  }
}

public class test_ParentType<TKind,TItem,TAllItem>
  : test_ChildType<TKind, Itest_Named>
  , Itest_ParentType<TKind,TItem,TAllItem>
{
  public Itest_ParentTypeObject<TKind,TItem,TAllItem>? As__ParentType { get; set; }
}

public class test_ParentTypeObject<TKind,TItem,TAllItem>
  : test_ChildTypeObject<TKind, Itest_Named>
  , Itest_ParentTypeObject<TKind,TItem,TAllItem>
{
  public ICollection<TItem> Items { get; set; }
  public ICollection<TAllItem> AllItems { get; set; }

  public test_ParentTypeObject
    ( TKind typeKind
    , Itest_Named parent
    , ICollection<TItem> items
    , ICollection<TAllItem> allItems
    ) : base(typeKind, parent)
  {
    Items = items;
    AllItems = allItems;
  }
}

public class test_TypeRef<TKind>
  : test_Named
  , Itest_TypeRef<TKind>
{
  public Itest_TypeRefObject<TKind>? As__TypeRef { get; set; }
}

public class test_TypeRefObject<TKind>
  : test_NamedObject
  , Itest_TypeRefObject<TKind>
{
  public TKind TypeKind { get; set; }

  public test_TypeRefObject
    ( TKind typeKind
    )
  {
    TypeKind = typeKind;
  }
}

public class test_TypeSimple
  : GqlpModelImplementationBase
  , Itest_TypeSimple
{
  public Itest_TypeRef<test_TypeKind>? As_TypeKindBasic { get; set; }
  public Itest_TypeRef<test_TypeKind>? As_TypeKindEnum { get; set; }
  public Itest_TypeRef<test_TypeKind>? As_TypeKindDomain { get; set; }
  public Itest_TypeRef<test_TypeKind>? As_TypeKindUnion { get; set; }
  public Itest_TypeSimpleObject? As__TypeSimple { get; set; }
}

public class test_TypeSimpleObject
  : GqlpModelImplementationBase
  , Itest_TypeSimpleObject
{

  public test_TypeSimpleObject
    ()
  {
  }
}

public class test_Collections
  : GqlpModelImplementationBase
  , Itest_Collections
{
  public Itest_Modifier<test_ModifierKind>? As_ModifierKindList { get; set; }
  public Itest_ModifierKeyed<test_ModifierKind>? As_ModifierKindDictionary { get; set; }
  public Itest_ModifierKeyed<test_ModifierKind>? As_ModifierKindTypeParam { get; set; }
  public Itest_CollectionsObject? As__Collections { get; set; }
}

public class test_CollectionsObject
  : GqlpModelImplementationBase
  , Itest_CollectionsObject
{

  public test_CollectionsObject
    ()
  {
  }
}

public class test_ModifierKeyed<TModifier>
  : test_Modifier<TModifier>
  , Itest_ModifierKeyed<TModifier>
{
  public Itest_ModifierKeyedObject<TModifier>? As__ModifierKeyed { get; set; }
}

public class test_ModifierKeyedObject<TModifier>
  : test_ModifierObject<TModifier>
  , Itest_ModifierKeyedObject<TModifier>
{
  public Itest_TypeSimple By { get; set; }
  public bool IsOptional { get; set; }

  public test_ModifierKeyedObject
    ( TModifier modifierKind
    , Itest_TypeSimple by
    , bool isOptional
    ) : base(modifierKind)
  {
    By = by;
    IsOptional = isOptional;
  }
}

public class test_Modifiers
  : GqlpModelImplementationBase
  , Itest_Modifiers
{
  public Itest_Modifier<test_ModifierKind>? As_ModifierKindOptional { get; set; }
  public Itest_Collections? As_Collections { get; set; }
  public Itest_ModifiersObject? As__Modifiers { get; set; }
}

public class test_ModifiersObject
  : GqlpModelImplementationBase
  , Itest_ModifiersObject
{

  public test_ModifiersObject
    ()
  {
  }
}

public class test_Modifier<TModifier>
  : GqlpModelImplementationBase
  , Itest_Modifier<TModifier>
{
  public Itest_ModifierObject<TModifier>? As__Modifier { get; set; }
}

public class test_ModifierObject<TModifier>
  : GqlpModelImplementationBase
  , Itest_ModifierObject<TModifier>
{
  public TModifier ModifierKind { get; set; }

  public test_ModifierObject
    ( TModifier modifierKind
    )
  {
    ModifierKind = modifierKind;
  }
}
