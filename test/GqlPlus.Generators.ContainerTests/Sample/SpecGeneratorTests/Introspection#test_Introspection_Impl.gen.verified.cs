//HintName: test_Introspection_Impl.gen.cs
// Generated from {CurrentDirectory}Introspection.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Introspection;

public class test_Schema
  : test_Named
  , Itest_Schema
{
  public Itest_SchemaObject? As__Schema { get; set; }
}

public class test_SchemaObject
  : test_NamedObject
  , Itest_SchemaObject
{
  public IDictionary<Itest_Name, Itest_Categories>? Categories(Itest_CategoryFilter? parameter)
    => null;
  public IDictionary<Itest_Name, Itest_Directives>? Directives(Itest_Filter? parameter)
    => null;
  public IDictionary<Itest_Name, Itest_Type>? Types(Itest_TypeFilter? parameter)
    => null;
  public IDictionary<Itest_Name, Itest_Setting>? Settings(Itest_Filter? parameter)
    => null;

  public test_SchemaObject()
  {
  }
}

public class test_Name
  : GqlpDomainString
  , Itest_Name
{
}

public class test_Filter
  : GqlpModelImplementationBase
  , Itest_Filter
{
  public ICollection<Itest_NameFilter>? As_NameFilter { get; set; }
  public Itest_FilterObject? As__Filter { get; set; }
}

public class test_FilterObject
  : GqlpModelImplementationBase
  , Itest_FilterObject
{
  public ICollection<Itest_NameFilter> Names { get; set; }
  public test_DomainKind? MatchAliases { get; set; }
  public ICollection<Itest_NameFilter> Aliases { get; set; }
  public test_DomainKind? ReturnByAlias { get; set; }
  public test_DomainKind? ReturnReferencedTypes { get; set; }

  public test_FilterObject(ICollection<Itest_NameFilter> names, ICollection<Itest_NameFilter> aliases)
  {
    Names = names;
    Aliases = aliases;
  }
}

public class test_NameFilter
  : GqlpDomainString
  , Itest_NameFilter
{
}

public class test_CategoryFilter
  : test_Filter
  , Itest_CategoryFilter
{
  public Itest_CategoryFilterObject? As__CategoryFilter { get; set; }
}

public class test_CategoryFilterObject
  : test_FilterObject
  , Itest_CategoryFilterObject
{
  public ICollection<test_Resolution> Resolutions { get; set; }

  public test_CategoryFilterObject(ICollection<Itest_NameFilter> names, ICollection<Itest_NameFilter> aliases, ICollection<test_Resolution> resolutions)
    : base(names, aliases)
  {
    Resolutions = resolutions;
  }
}

public class test_TypeFilter
  : test_Filter
  , Itest_TypeFilter
{
  public Itest_TypeFilterObject? As__TypeFilter { get; set; }
}

public class test_TypeFilterObject
  : test_FilterObject
  , Itest_TypeFilterObject
{
  public ICollection<test_TypeKind> Kinds { get; set; }

  public test_TypeFilterObject(ICollection<Itest_NameFilter> names, ICollection<Itest_NameFilter> aliases, ICollection<test_TypeKind> kinds)
    : base(names, aliases)
  {
    Kinds = kinds;
  }
}

public class test_Aliased
  : test_Named
  , Itest_Aliased
{
  public Itest_AliasedObject? As__Aliased { get; set; }
}

public class test_AliasedObject
  : test_NamedObject
  , Itest_AliasedObject
{
  public ICollection<Itest_Name> Aliases { get; set; }

  public test_AliasedObject(ICollection<test_DomainKind> description, Itest_Name name, ICollection<Itest_Name> aliases)
    : base(description, name)
  {
    Aliases = aliases;
  }
}

public class test_Named
  : test_Described
  , Itest_Named
{
  public Itest_NamedObject? As__Named { get; set; }
}

public class test_NamedObject
  : test_DescribedObject
  , Itest_NamedObject
{
  public Itest_Name Name { get; set; }

  public test_NamedObject(ICollection<test_DomainKind> description, Itest_Name name)
    : base(description)
  {
    Name = name;
  }
}

public class test_Described
  : GqlpModelImplementationBase
  , Itest_Described
{
  public Itest_DescribedObject? As__Described { get; set; }
}

public class test_DescribedObject
  : GqlpModelImplementationBase
  , Itest_DescribedObject
{
  public ICollection<test_DomainKind> Description { get; set; }

  public test_DescribedObject(ICollection<test_DomainKind> description)
  {
    Description = description;
  }
}

public class test_AndType
  : test_Named
  , Itest_AndType
{
  public Itest_Type? As_Type { get; set; }
  public Itest_AndTypeObject? As__AndType { get; set; }
}

public class test_AndTypeObject
  : test_NamedObject
  , Itest_AndTypeObject
{
  public Itest_Type Type { get; set; }

  public test_AndTypeObject(Itest_Type type)
  {
    Type = type;
  }
}

public class test_Categories
  : test_AndType
  , Itest_Categories
{
  public Itest_Category? As_Category { get; set; }
  public Itest_CategoriesObject? As__Categories { get; set; }
}

public class test_CategoriesObject
  : test_AndTypeObject
  , Itest_CategoriesObject
{
  public Itest_Category Category { get; set; }

  public test_CategoriesObject(Itest_Type type, Itest_Category category)
    : base(type)
  {
    Category = category;
  }
}

public class test_Category
  : test_Aliased
  , Itest_Category
{
  public Itest_CategoryObject? As__Category { get; set; }
}

public class test_CategoryObject
  : test_AliasedObject
  , Itest_CategoryObject
{
  public test_Resolution Resolution { get; set; }
  public Itest_TypeRef<test_TypeKind> Output { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }

  public test_CategoryObject(test_Resolution resolution, Itest_TypeRef<test_TypeKind> output, ICollection<Itest_Modifiers> modifiers)
  {
    Resolution = resolution;
    Output = output;
    Modifiers = modifiers;
  }
}

public class test_Directives
  : test_AndType
  , Itest_Directives
{
  public Itest_Directive? As_Directive { get; set; }
  public Itest_DirectivesObject? As__Directives { get; set; }
}

public class test_DirectivesObject
  : test_AndTypeObject
  , Itest_DirectivesObject
{
  public Itest_Directive Directive { get; set; }

  public test_DirectivesObject(Itest_Type type, Itest_Directive directive)
    : base(type)
  {
    Directive = directive;
  }
}

public class test_Directive
  : test_Aliased
  , Itest_Directive
{
  public Itest_DirectiveObject? As__Directive { get; set; }
}

public class test_DirectiveObject
  : test_AliasedObject
  , Itest_DirectiveObject
{
  public Itest_InputFieldType? Parameter { get; set; }
  public test_DomainKind Repeatable { get; set; }
  public IDictionary<test_Location, GqlpUnit> Locations { get; set; }

  public test_DirectiveObject(test_DomainKind repeatable, IDictionary<test_Location, GqlpUnit> locations)
  {
    Repeatable = repeatable;
    Locations = locations;
  }
}

public class test_Setting
  : test_Named
  , Itest_Setting
{
  public Itest_SettingObject? As__Setting { get; set; }
}

public class test_SettingObject
  : test_NamedObject
  , Itest_SettingObject
{
  public GqlpValue Value { get; set; }

  public test_SettingObject(GqlpValue value)
  {
    Value = value;
  }
}

public class test_Type
  : GqlpModelImplementationBase
  , Itest_Type
{
  public Itest_BaseType<test_TypeKind>? As_TypeKindBasic { get; set; }
  public Itest_BaseType<test_TypeKind>? As_TypeKindInternal { get; set; }
  public Itest_BaseDomain<test_DomainKind, Itest_DomainTrueFalse, Itest_DomainItemTrueFalse>? As_DomainKindBoolean { get; set; }
  public Itest_BaseDomain<test_DomainKind, Itest_DomainLabel, Itest_DomainItemLabel>? As_DomainKindEnum { get; set; }
  public Itest_BaseDomain<test_DomainKind, Itest_DomainRange, Itest_DomainItemRange>? As_DomainKindNumber { get; set; }
  public Itest_BaseDomain<test_DomainKind, Itest_DomainRegex, Itest_DomainItemRegex>? As_DomainKindString { get; set; }
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

  public test_TypeObject()
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

  public test_BaseTypeObject(TKind typeKind)
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

  public test_ChildTypeObject(TKind typeKind, TParent parent)
    : base(typeKind)
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

  public test_ParentTypeObject(TKind typeKind, TParent parent, ICollection<TItem> items, ICollection<TAllItem> allItems)
    : base(typeKind, parent)
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

  public test_TypeRefObject(ICollection<test_DomainKind> description, Itest_Name name, TKind typeKind)
    : base(description, name)
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

  public test_TypeSimpleObject()
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

  public test_CollectionsObject()
  {
  }
}

public class test_ModifierKeyed<TKind>
  : test_Modifier<TKind>
  , Itest_ModifierKeyed<TKind>
{
  public Itest_ModifierKeyedObject<TKind>? As__ModifierKeyed { get; set; }
}

public class test_ModifierKeyedObject<TKind>
  : test_ModifierObject<TKind>
  , Itest_ModifierKeyedObject<TKind>
{
  public Itest_TypeSimple By { get; set; }
  public test_DomainKind IsOptional { get; set; }

  public test_ModifierKeyedObject(TKind modifierKind, Itest_TypeSimple by, test_DomainKind isOptional)
    : base(modifierKind)
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

  public test_ModifiersObject()
  {
  }
}

public class test_Modifier<TKind>
  : GqlpModelImplementationBase
  , Itest_Modifier<TKind>
{
  public Itest_ModifierObject<TKind>? As__Modifier { get; set; }
}

public class test_ModifierObject<TKind>
  : GqlpModelImplementationBase
  , Itest_ModifierObject<TKind>
{
  public TKind ModifierKind { get; set; }

  public test_ModifierObject(TKind modifierKind)
  {
    ModifierKind = modifierKind;
  }
}

public class test_DomainRef<TKind>
  : test_TypeRef<test_TypeKind>
  , Itest_DomainRef<TKind>
{
  public Itest_DomainRefObject<TKind>? As__DomainRef { get; set; }
}

public class test_DomainRefObject<TKind>
  : test_TypeRefObject<test_TypeKind>
  , Itest_DomainRefObject<TKind>
{
  public TKind DomainKind { get; set; }

  public test_DomainRefObject(TKind domainKind)
  {
    DomainKind = domainKind;
  }
}

public class test_BaseDomain<TDomain,TItem,TDomainItem>
  : test_ParentType<test_TypeKind, TItem, TDomainItem>
  , Itest_BaseDomain<TDomain,TItem,TDomainItem>
{
  public Itest_BaseDomainObject<TDomain,TItem,TDomainItem>? As__BaseDomain { get; set; }
}

public class test_BaseDomainObject<TDomain,TItem,TDomainItem>
  : test_ParentTypeObject<test_TypeKind, TItem, TDomainItem>
  , Itest_BaseDomainObject<TDomain,TItem,TDomainItem>
{
  public TDomain DomainKind { get; set; }

  public test_BaseDomainObject(TKind typeKind, TParent parent, ICollection<TItem> items, ICollection<TAllItem> allItems, TDomain domainKind)
    : base(typeKind, parent, items, allItems)
  {
    DomainKind = domainKind;
  }
}

public class test_BaseDomainItem
  : test_Described
  , Itest_BaseDomainItem
{
  public Itest_BaseDomainItemObject? As__BaseDomainItem { get; set; }
}

public class test_BaseDomainItemObject
  : test_DescribedObject
  , Itest_BaseDomainItemObject
{
  public test_DomainKind Exclude { get; set; }

  public test_BaseDomainItemObject(ICollection<test_DomainKind> description, test_DomainKind exclude)
    : base(description)
  {
    Exclude = exclude;
  }
}

public class test_DomainItem<TItem>
  : GqlpModelImplementationBase
  , Itest_DomainItem<TItem>
{
  public TItem? As_Parent { get; set; }
  public Itest_DomainItemObject<TItem>? As__DomainItem { get; set; }
}

public class test_DomainItemObject<TItem>
  : GqlpModelImplementationBase
  , Itest_DomainItemObject<TItem>
{
  public Itest_Name Domain { get; set; }

  public test_DomainItemObject(Itest_Name domain)
  {
    Domain = domain;
  }
}

public class test_DomainValue<TKind,TValue>
  : test_DomainRef<TKind>
  , Itest_DomainValue<TKind,TValue>
{
  public TValue? Asvalue { get; set; }
  public Itest_DomainValueObject<TKind,TValue>? As__DomainValue { get; set; }
}

public class test_DomainValueObject<TKind,TValue>
  : test_DomainRefObject<TKind>
  , Itest_DomainValueObject<TKind,TValue>
{
  public TValue Value { get; set; }

  public test_DomainValueObject(TKind domainKind, TValue value)
    : base(domainKind)
  {
    Value = value;
  }
}

public class test_BasicValue
  : GqlpModelImplementationBase
  , Itest_BasicValue
{
  public test_DomainKind? As_DomainKindBoolean { get; set; }
  public Itest_EnumValue? As_EnumValue { get; set; }
  public test_DomainKind? As_DomainKindNumber { get; set; }
  public test_DomainKind? As_DomainKindString { get; set; }
  public Itest_BasicValueObject? As__BasicValue { get; set; }
}

public class test_BasicValueObject
  : GqlpModelImplementationBase
  , Itest_BasicValueObject
{

  public test_BasicValueObject()
  {
  }
}

public class test_DomainTrueFalse
  : test_BaseDomainItem
  , Itest_DomainTrueFalse
{
  public Itest_DomainTrueFalseObject? As__DomainTrueFalse { get; set; }
}

public class test_DomainTrueFalseObject
  : test_BaseDomainItemObject
  , Itest_DomainTrueFalseObject
{
  public test_DomainKind Value { get; set; }

  public test_DomainTrueFalseObject(ICollection<test_DomainKind> description, test_DomainKind exclude, test_DomainKind value)
    : base(description, exclude)
  {
    Value = value;
  }
}

public class test_DomainItemTrueFalse
  : test_DomainItem<Itest_DomainTrueFalse>
  , Itest_DomainItemTrueFalse
{
  public Itest_DomainItemTrueFalseObject? As__DomainItemTrueFalse { get; set; }
}

public class test_DomainItemTrueFalseObject
  : test_DomainItemObject<Itest_DomainTrueFalse>
  , Itest_DomainItemTrueFalseObject
{

  public test_DomainItemTrueFalseObject(Itest_Name domain)
    : base(domain)
  {
  }
}

public class test_DomainLabel
  : test_BaseDomainItem
  , Itest_DomainLabel
{
  public Itest_DomainLabelObject? As__DomainLabel { get; set; }
}

public class test_DomainLabelObject
  : test_BaseDomainItemObject
  , Itest_DomainLabelObject
{
  public Itest_EnumValue Label { get; set; }

  public test_DomainLabelObject(Itest_EnumValue label)
  {
    Label = label;
  }
}

public class test_DomainItemLabel
  : test_DomainItem<Itest_DomainLabel>
  , Itest_DomainItemLabel
{
  public Itest_DomainItemLabelObject? As__DomainItemLabel { get; set; }
}

public class test_DomainItemLabelObject
  : test_DomainItemObject<Itest_DomainLabel>
  , Itest_DomainItemLabelObject
{

  public test_DomainItemLabelObject(Itest_Name domain)
    : base(domain)
  {
  }
}

public class test_DomainRange
  : test_BaseDomainItem
  , Itest_DomainRange
{
  public Itest_DomainRangeObject? As__DomainRange { get; set; }
}

public class test_DomainRangeObject
  : test_BaseDomainItemObject
  , Itest_DomainRangeObject
{
  public test_DomainKind? Lower { get; set; }
  public test_DomainKind? Upper { get; set; }

  public test_DomainRangeObject(ICollection<test_DomainKind> description, test_DomainKind exclude)
    : base(description, exclude)
  {
  }
}

public class test_DomainItemRange
  : test_DomainItem<Itest_DomainRange>
  , Itest_DomainItemRange
{
  public Itest_DomainItemRangeObject? As__DomainItemRange { get; set; }
}

public class test_DomainItemRangeObject
  : test_DomainItemObject<Itest_DomainRange>
  , Itest_DomainItemRangeObject
{

  public test_DomainItemRangeObject(Itest_Name domain)
    : base(domain)
  {
  }
}

public class test_DomainRegex
  : test_BaseDomainItem
  , Itest_DomainRegex
{
  public Itest_DomainRegexObject? As__DomainRegex { get; set; }
}

public class test_DomainRegexObject
  : test_BaseDomainItemObject
  , Itest_DomainRegexObject
{
  public test_DomainKind Pattern { get; set; }

  public test_DomainRegexObject(ICollection<test_DomainKind> description, test_DomainKind exclude, test_DomainKind pattern)
    : base(description, exclude)
  {
    Pattern = pattern;
  }
}

public class test_DomainItemRegex
  : test_DomainItem<Itest_DomainRegex>
  , Itest_DomainItemRegex
{
  public Itest_DomainItemRegexObject? As__DomainItemRegex { get; set; }
}

public class test_DomainItemRegexObject
  : test_DomainItemObject<Itest_DomainRegex>
  , Itest_DomainItemRegexObject
{

  public test_DomainItemRegexObject(Itest_Name domain)
    : base(domain)
  {
  }
}

public class test_EnumLabel
  : test_Aliased
  , Itest_EnumLabel
{
  public Itest_EnumLabelObject? As__EnumLabel { get; set; }
}

public class test_EnumLabelObject
  : test_AliasedObject
  , Itest_EnumLabelObject
{
  public Itest_Name EnumType { get; set; }

  public test_EnumLabelObject(ICollection<test_DomainKind> description, Itest_Name name, ICollection<Itest_Name> aliases, Itest_Name enumType)
    : base(description, name, aliases)
  {
    EnumType = enumType;
  }
}

public class test_EnumValue
  : test_TypeRef<test_TypeKind>
  , Itest_EnumValue
{
  public Itest_EnumValueObject? As__EnumValue { get; set; }
}

public class test_EnumValueObject
  : test_TypeRefObject<test_TypeKind>
  , Itest_EnumValueObject
{
  public Itest_Name Label { get; set; }

  public test_EnumValueObject(Itest_Name label)
  {
    Label = label;
  }
}

public class test_UnionRef
  : test_TypeRef<test_SimpleKind>
  , Itest_UnionRef
{
  public Itest_UnionRefObject? As__UnionRef { get; set; }
}

public class test_UnionRefObject
  : test_TypeRefObject<test_SimpleKind>
  , Itest_UnionRefObject
{

  public test_UnionRefObject()
  {
  }
}

public class test_UnionMember
  : test_UnionRef
  , Itest_UnionMember
{
  public Itest_UnionMemberObject? As__UnionMember { get; set; }
}

public class test_UnionMemberObject
  : test_UnionRefObject
  , Itest_UnionMemberObject
{
  public Itest_Name Union { get; set; }

  public test_UnionMemberObject(Itest_Name union)
  {
    Union = union;
  }
}

public class test_ObjectKind
  : GqlpDomainEnum
  , Itest_ObjectKind
{
}

public class test_TypeObject<TKind,TField>
  : test_ChildType<TKind, Itest_ObjBase>
  , Itest_TypeObject<TKind,TField>
{
  public Itest_TypeObjectObject<TKind,TField>? As__TypeObject { get; set; }
}

public class test_TypeObjectObject<TKind,TField>
  : test_ChildTypeObject<TKind, Itest_ObjBase>
  , Itest_TypeObjectObject<TKind,TField>
{
  public ICollection<Itest_ObjTypeParam> TypeParams { get; set; }
  public ICollection<TField> Fields { get; set; }
  public ICollection<Itest_ObjAlternate> Alternates { get; set; }
  public ICollection<Itest_ObjectFor<TField>> AllFields { get; set; }
  public ICollection<Itest_ObjectFor<Itest_ObjAlternate>> AllAlternates { get; set; }

  public test_TypeObjectObject(TKind typeKind, TParent parent, ICollection<Itest_ObjTypeParam> typeParams, ICollection<TField> fields, ICollection<Itest_ObjAlternate> alternates, ICollection<Itest_ObjectFor<TField>> allFields, ICollection<Itest_ObjectFor<Itest_ObjAlternate>> allAlternates)
    : base(typeKind, parent)
  {
    TypeParams = typeParams;
    Fields = fields;
    Alternates = alternates;
    AllFields = allFields;
    AllAlternates = allAlternates;
  }
}

public class test_ObjTypeParam
  : test_Named
  , Itest_ObjTypeParam
{
  public Itest_ObjTypeParamObject? As__ObjTypeParam { get; set; }
}

public class test_ObjTypeParamObject
  : test_NamedObject
  , Itest_ObjTypeParamObject
{
  public Itest_TypeRef<test_TypeKind> Constraint { get; set; }

  public test_ObjTypeParamObject(Itest_TypeRef<test_TypeKind> constraint)
  {
    Constraint = constraint;
  }
}

public class test_ObjBase
  : test_Named
  , Itest_ObjBase
{
  public Itest_TypeParam? As_TypeParam { get; set; }
  public Itest_ObjBaseObject? As__ObjBase { get; set; }
}

public class test_ObjBaseObject
  : test_NamedObject
  , Itest_ObjBaseObject
{
  public ICollection<Itest_ObjTypeArg> TypeArgs { get; set; }

  public test_ObjBaseObject(ICollection<Itest_ObjTypeArg> typeArgs)
  {
    TypeArgs = typeArgs;
  }
}

public class test_ObjTypeArg
  : test_TypeRef<test_TypeKind>
  , Itest_ObjTypeArg
{
  public Itest_TypeParam? As_TypeParam { get; set; }
  public Itest_ObjTypeArgObject? As__ObjTypeArg { get; set; }
}

public class test_ObjTypeArgObject
  : test_TypeRefObject<test_TypeKind>
  , Itest_ObjTypeArgObject
{
  public Itest_Name? Label { get; set; }

  public test_ObjTypeArgObject()
  {
  }
}

public class test_TypeParam
  : test_Described
  , Itest_TypeParam
{
  public Itest_TypeParamObject? As__TypeParam { get; set; }
}

public class test_TypeParamObject
  : test_DescribedObject
  , Itest_TypeParamObject
{
  public Itest_Name TypeParam { get; set; }

  public test_TypeParamObject(Itest_Name typeParam)
  {
    TypeParam = typeParam;
  }
}

public class test_ObjAlternate
  : GqlpModelImplementationBase
  , Itest_ObjAlternate
{
  public Itest_ObjAlternateEnum? As_ObjAlternateEnum { get; set; }
  public Itest_ObjAlternateObject? As__ObjAlternate { get; set; }
}

public class test_ObjAlternateObject
  : GqlpModelImplementationBase
  , Itest_ObjAlternateObject
{
  public Itest_ObjBase Type { get; set; }
  public ICollection<Itest_Collections> Collections { get; set; }

  public test_ObjAlternateObject(Itest_ObjBase type, ICollection<Itest_Collections> collections)
  {
    Type = type;
    Collections = collections;
  }
}

public class test_ObjAlternateEnum
  : test_TypeRef<test_TypeKind>
  , Itest_ObjAlternateEnum
{
  public Itest_ObjAlternateEnumObject? As__ObjAlternateEnum { get; set; }
}

public class test_ObjAlternateEnumObject
  : test_TypeRefObject<test_TypeKind>
  , Itest_ObjAlternateEnumObject
{
  public Itest_Name Label { get; set; }

  public test_ObjAlternateEnumObject(Itest_Name label)
  {
    Label = label;
  }
}

public class test_ObjectFor<TFor>
  : GqlpModelImplementationBase
  , Itest_ObjectFor<TFor>
{
  public TFor? As_Parent { get; set; }
  public Itest_ObjectForObject<TFor>? As__ObjectFor { get; set; }
}

public class test_ObjectForObject<TFor>
  : GqlpModelImplementationBase
  , Itest_ObjectForObject<TFor>
{
  public Itest_Name ObjectType { get; set; }

  public test_ObjectForObject(Itest_Name objectType)
  {
    ObjectType = objectType;
  }
}

public class test_ObjField<TType>
  : test_Aliased
  , Itest_ObjField<TType>
{
  public Itest_ObjFieldObject<TType>? As__ObjField { get; set; }
}

public class test_ObjFieldObject<TType>
  : test_AliasedObject
  , Itest_ObjFieldObject<TType>
{
  public TType Type { get; set; }

  public test_ObjFieldObject(TType type)
  {
    Type = type;
  }
}

public class test_ObjFieldType
  : test_ObjBase
  , Itest_ObjFieldType
{
  public Itest_ObjFieldEnum? As_ObjFieldEnum { get; set; }
  public Itest_ObjFieldTypeObject? As__ObjFieldType { get; set; }
}

public class test_ObjFieldTypeObject
  : test_ObjBaseObject
  , Itest_ObjFieldTypeObject
{
  public ICollection<Itest_Modifiers> Modifiers { get; set; }

  public test_ObjFieldTypeObject(ICollection<Itest_ObjTypeArg> typeArgs, ICollection<Itest_Modifiers> modifiers)
    : base(typeArgs)
  {
    Modifiers = modifiers;
  }
}

public class test_ObjFieldEnum
  : test_TypeRef<test_TypeKind>
  , Itest_ObjFieldEnum
{
  public Itest_ObjFieldEnumObject? As__ObjFieldEnum { get; set; }
}

public class test_ObjFieldEnumObject
  : test_TypeRefObject<test_TypeKind>
  , Itest_ObjFieldEnumObject
{
  public Itest_Name Label { get; set; }

  public test_ObjFieldEnumObject(Itest_Name label)
  {
    Label = label;
  }
}

public class test_ForParam<TType>
  : GqlpModelImplementationBase
  , Itest_ForParam<TType>
{
  public Itest_ObjAlternate? As_ObjAlternate { get; set; }
  public Itest_ObjField<TType>? As_ObjField { get; set; }
  public Itest_ForParamObject<TType>? As__ForParam { get; set; }
}

public class test_ForParamObject<TType>
  : GqlpModelImplementationBase
  , Itest_ForParamObject<TType>
{

  public test_ForParamObject()
  {
  }
}

public class test_DualField
  : test_ObjField<Itest_ObjFieldType>
  , Itest_DualField
{
  public Itest_DualFieldObject? As__DualField { get; set; }
}

public class test_DualFieldObject
  : test_ObjFieldObject<Itest_ObjFieldType>
  , Itest_DualFieldObject
{

  public test_DualFieldObject(TType type)
    : base(type)
  {
  }
}

public class test_InputField
  : test_ObjField<Itest_InputFieldType>
  , Itest_InputField
{
  public Itest_InputFieldObject? As__InputField { get; set; }
}

public class test_InputFieldObject
  : test_ObjFieldObject<Itest_InputFieldType>
  , Itest_InputFieldObject
{

  public test_InputFieldObject(TType type)
    : base(type)
  {
  }
}

public class test_InputFieldType
  : test_ObjFieldType
  , Itest_InputFieldType
{
  public Itest_InputFieldTypeObject? As__InputFieldType { get; set; }
}

public class test_InputFieldTypeObject
  : test_ObjFieldTypeObject
  , Itest_InputFieldTypeObject
{
  public GqlpValue? DefaultValue { get; set; }

  public test_InputFieldTypeObject(ICollection<Itest_ObjTypeArg> typeArgs, ICollection<Itest_Modifiers> modifiers)
    : base(typeArgs, modifiers)
  {
  }
}

public class test_OutputField
  : test_ObjField<Itest_ObjFieldType>
  , Itest_OutputField
{
  public Itest_OutputFieldObject? As__OutputField { get; set; }
}

public class test_OutputFieldObject
  : test_ObjFieldObject<Itest_ObjFieldType>
  , Itest_OutputFieldObject
{

  public test_OutputFieldObject(TType type)
    : base(type)
  {
  }
}

public class test_OutputFieldType
  : test_ObjFieldType
  , Itest_OutputFieldType
{
  public Itest_OutputFieldTypeObject? As__OutputFieldType { get; set; }
}

public class test_OutputFieldTypeObject
  : test_ObjFieldTypeObject
  , Itest_OutputFieldTypeObject
{
  public Itest_InputFieldType? Parameter { get; set; }

  public test_OutputFieldTypeObject(ICollection<Itest_ObjTypeArg> typeArgs, ICollection<Itest_Modifiers> modifiers)
    : base(typeArgs, modifiers)
  {
  }
}
