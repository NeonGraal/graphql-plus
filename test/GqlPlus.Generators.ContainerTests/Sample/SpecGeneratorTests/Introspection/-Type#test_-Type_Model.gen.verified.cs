//HintName: test_-Type_Model.gen.cs
// Generated from {CurrentDirectory}-Type.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Type;

public class test_Type
  : GqlpModelBase
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
  : GqlpModelBase
  , Itest_TypeObject
{

  public test_TypeObject
    ()
  {
  }
}

public class test_BaseType<TTypeKind>
  : test_Aliased
  , Itest_BaseType<TTypeKind>
{
  public Itest_BaseTypeObject<TTypeKind>? As__BaseType { get; set; }
}

public class test_BaseTypeObject<TTypeKind>
  : test_AliasedObject
  , Itest_BaseTypeObject<TTypeKind>
{
  public TTypeKind TypeKind { get; set; }

  public test_BaseTypeObject
    ( TTypeKind ptypeKind
    )
  {
    TypeKind = ptypeKind;
  }
}

public class test_ChildType<TTypeKind,TParent>
  : test_BaseType<TTypeKind>
  , Itest_ChildType<TTypeKind,TParent>
{
  public Itest_ChildTypeObject<TTypeKind,TParent>? As__ChildType { get; set; }
}

public class test_ChildTypeObject<TTypeKind,TParent>
  : test_BaseTypeObject<TTypeKind>
  , Itest_ChildTypeObject<TTypeKind,TParent>
{
  public TParent Parent { get; set; }

  public test_ChildTypeObject
    ( TTypeKind ptypeKind
    , TParent pparent
    ) : base(ptypeKind)
  {
    Parent = pparent;
  }
}

public class test_ParentType<TTypeKind,TItem,TAllItem>
  : test_ChildType<TTypeKind, Itest_Named>
  , Itest_ParentType<TTypeKind,TItem,TAllItem>
{
  public Itest_ParentTypeObject<TTypeKind,TItem,TAllItem>? As__ParentType { get; set; }
}

public class test_ParentTypeObject<TTypeKind,TItem,TAllItem>
  : test_ChildTypeObject<TTypeKind, Itest_Named>
  , Itest_ParentTypeObject<TTypeKind,TItem,TAllItem>
{
  public ICollection<TItem> Items { get; set; }
  public ICollection<TAllItem> AllItems { get; set; }

  public test_ParentTypeObject
    ( TTypeKind ptypeKind
    , Itest_Named pparent
    , ICollection<TItem> pitems
    , ICollection<TAllItem> pallItems
    ) : base(ptypeKind, pparent)
  {
    Items = pitems;
    AllItems = pallItems;
  }
}

public class test_TypeRef<TTypeKind>
  : test_Named
  , Itest_TypeRef<TTypeKind>
{
  public Itest_TypeRefObject<TTypeKind>? As__TypeRef { get; set; }
}

public class test_TypeRefObject<TTypeKind>
  : test_NamedObject
  , Itest_TypeRefObject<TTypeKind>
{
  public TTypeKind TypeKind { get; set; }

  public test_TypeRefObject
    ( TTypeKind ptypeKind
    )
  {
    TypeKind = ptypeKind;
  }
}

public class test_TypeSimple
  : GqlpModelBase
  , Itest_TypeSimple
{
  public Itest_TypeRef<test_TypeKind>? As_TypeKindBasic { get; set; }
  public Itest_TypeRef<test_TypeKind>? As_TypeKindEnum { get; set; }
  public Itest_TypeRef<test_TypeKind>? As_TypeKindDomain { get; set; }
  public Itest_TypeRef<test_TypeKind>? As_TypeKindUnion { get; set; }
  public Itest_TypeSimpleObject? As__TypeSimple { get; set; }
}

public class test_TypeSimpleObject
  : GqlpModelBase
  , Itest_TypeSimpleObject
{

  public test_TypeSimpleObject
    ()
  {
  }
}

public class test_Collections
  : GqlpModelBase
  , Itest_Collections
{
  public Itest_Modifier<test_ModifierKind>? As_ModifierKindList { get; set; }
  public Itest_ModifierKeyed<test_ModifierKind>? As_ModifierKindDictionary { get; set; }
  public Itest_ModifierKeyed<test_ModifierKind>? As_ModifierKindTypeParam { get; set; }
  public Itest_CollectionsObject? As__Collections { get; set; }
}

public class test_CollectionsObject
  : GqlpModelBase
  , Itest_CollectionsObject
{

  public test_CollectionsObject
    ()
  {
  }
}

public class test_ModifierKeyed<TModifierKind>
  : test_Modifier<TModifierKind>
  , Itest_ModifierKeyed<TModifierKind>
{
  public Itest_ModifierKeyedObject<TModifierKind>? As__ModifierKeyed { get; set; }
}

public class test_ModifierKeyedObject<TModifierKind>
  : test_ModifierObject<TModifierKind>
  , Itest_ModifierKeyedObject<TModifierKind>
{
  public Itest_TypeSimple By { get; set; }
  public bool IsOptional { get; set; }

  public test_ModifierKeyedObject
    ( TModifierKind pmodifierKind
    , Itest_TypeSimple pby
    , bool pisOptional
    ) : base(pmodifierKind)
  {
    By = pby;
    IsOptional = pisOptional;
  }
}

public class test_Modifiers
  : GqlpModelBase
  , Itest_Modifiers
{
  public Itest_Modifier<test_ModifierKind>? As_ModifierKindOptional { get; set; }
  public Itest_Collections? As_Collections { get; set; }
  public Itest_ModifiersObject? As__Modifiers { get; set; }
}

public class test_ModifiersObject
  : GqlpModelBase
  , Itest_ModifiersObject
{

  public test_ModifiersObject
    ()
  {
  }
}

public class test_Modifier<TModifierKind>
  : GqlpModelBase
  , Itest_Modifier<TModifierKind>
{
  public Itest_ModifierObject<TModifierKind>? As__Modifier { get; set; }
}

public class test_ModifierObject<TModifierKind>
  : GqlpModelBase
  , Itest_ModifierObject<TModifierKind>
{
  public TModifierKind ModifierKind { get; set; }

  public test_ModifierObject
    ( TModifierKind pmodifierKind
    )
  {
    ModifierKind = pmodifierKind;
  }
}
