//HintName: test_Introspection_Model.gen.cs
// Generated from {CurrentDirectory}Introspection.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
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
  public IDictionary<Itest_Name, Itest_Categories> Categories { get; set; }
  public IDictionary<Itest_Name, Itest_Categories>? Call_Categories(Itest_CategoryFilter? parameter)
    => null;
  public IDictionary<Itest_Name, Itest_Directives> Directives { get; set; }
  public IDictionary<Itest_Name, Itest_Directives>? Call_Directives(Itest_Filter? parameter)
    => null;
  public IDictionary<Itest_Name, Itest_Type> Types { get; set; }
  public IDictionary<Itest_Name, Itest_Type>? Call_Types(Itest_TypeFilter? parameter)
    => null;
  public IDictionary<Itest_Name, Itest_Setting> Settings { get; set; }
  public IDictionary<Itest_Name, Itest_Setting>? Call_Settings(Itest_Filter? parameter)
    => null;

  public test_SchemaObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , IDictionary<Itest_Name, Itest_Categories> pcategories
    , IDictionary<Itest_Name, Itest_Directives> pdirectives
    , IDictionary<Itest_Name, Itest_Type> ptypes
    , IDictionary<Itest_Name, Itest_Setting> psettings
    ) : base(pdescription, pname)
  {
    Categories = pcategories;
    Directives = pdirectives;
    Types = ptypes;
    Settings = psettings;
  }
}

public class test_Name
  : GqlpDomainString
  , Itest_Name
{
}

public class test_Filter
  : GqlpModelBase
  , Itest_Filter
{
  public ICollection<Itest_NameFilter>? As_NameFilter { get; set; }
  public Itest_FilterObject? As__Filter { get; set; }
}

public class test_FilterObject
  : GqlpModelBase
  , Itest_FilterObject
{
  public ICollection<Itest_NameFilter> Names { get; set; }
  public bool? MatchAliases { get; set; }
  public ICollection<Itest_NameFilter> Aliases { get; set; }
  public bool? ReturnByAlias { get; set; }
  public bool? ReturnReferencedTypes { get; set; }

  public test_FilterObject
    ( ICollection<Itest_NameFilter> pnames
    , ICollection<Itest_NameFilter> paliases
    )
  {
    Names = pnames;
    Aliases = paliases;
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

  public test_CategoryFilterObject
    ( ICollection<Itest_NameFilter> pnames
    , ICollection<Itest_NameFilter> paliases
    , ICollection<test_Resolution> presolutions
    ) : base(pnames, paliases)
  {
    Resolutions = presolutions;
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

  public test_TypeFilterObject
    ( ICollection<Itest_NameFilter> pnames
    , ICollection<Itest_NameFilter> paliases
    , ICollection<test_TypeKind> pkinds
    ) : base(pnames, paliases)
  {
    Kinds = pkinds;
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

  public test_AliasedObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , ICollection<Itest_Name> paliases
    ) : base(pdescription, pname)
  {
    Aliases = paliases;
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

  public test_NamedObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    ) : base(pdescription)
  {
    Name = pname;
  }
}

public class test_Described
  : GqlpModelBase
  , Itest_Described
{
  public Itest_DescribedObject? As__Described { get; set; }
}

public class test_DescribedObject
  : GqlpModelBase
  , Itest_DescribedObject
{
  public ICollection<string> Description { get; set; }

  public test_DescribedObject
    ( ICollection<string> pdescription
    )
  {
    Description = pdescription;
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

  public test_AndTypeObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , Itest_Type ptype
    ) : base(pdescription, pname)
  {
    Type = ptype;
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

  public test_CategoriesObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , Itest_Type ptype
    , Itest_Category pcategory
    ) : base(pdescription, pname, ptype)
  {
    Category = pcategory;
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

  public test_CategoryObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , ICollection<Itest_Name> paliases
    , test_Resolution presolution
    , Itest_TypeRef<test_TypeKind> poutput
    , ICollection<Itest_Modifiers> pmodifiers
    ) : base(pdescription, pname, paliases)
  {
    Resolution = presolution;
    Output = poutput;
    Modifiers = pmodifiers;
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

  public test_DirectivesObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , Itest_Type ptype
    , Itest_Directive pdirective
    ) : base(pdescription, pname, ptype)
  {
    Directive = pdirective;
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
  public bool Repeatable { get; set; }
  public IDictionary<test_Location, GqlpUnit> Locations { get; set; }

  public test_DirectiveObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , ICollection<Itest_Name> paliases
    , bool prepeatable
    , IDictionary<test_Location, GqlpUnit> plocations
    ) : base(pdescription, pname, paliases)
  {
    Repeatable = prepeatable;
    Locations = plocations;
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

  public test_SettingObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , GqlpValue pvalue
    ) : base(pdescription, pname)
  {
    Value = pvalue;
  }
}

public class test_Type
  : GqlpModelBase
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
    ( ICollection<string> pdescription
    , Itest_Name pname
    , ICollection<Itest_Name> paliases
    , TTypeKind ptypeKind
    ) : base(pdescription, pname, paliases)
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
    ( ICollection<string> pdescription
    , Itest_Name pname
    , ICollection<Itest_Name> paliases
    , TTypeKind ptypeKind
    , TParent pparent
    ) : base(pdescription, pname, paliases, ptypeKind)
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
    ( ICollection<string> pdescription
    , Itest_Name pname
    , ICollection<Itest_Name> paliases
    , TTypeKind ptypeKind
    , Itest_Named pparent
    , ICollection<TItem> pitems
    , ICollection<TAllItem> pallItems
    ) : base(pdescription, pname, paliases, ptypeKind, pparent)
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
    ( ICollection<string> pdescription
    , Itest_Name pname
    , TTypeKind ptypeKind
    ) : base(pdescription, pname)
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

public class test_DomainRef<TDomainKind>
  : test_TypeRef<test_TypeKind>
  , Itest_DomainRef<TDomainKind>
{
  public Itest_DomainRefObject<TDomainKind>? As__DomainRef { get; set; }
}

public class test_DomainRefObject<TDomainKind>
  : test_TypeRefObject<test_TypeKind>
  , Itest_DomainRefObject<TDomainKind>
{
  public TDomainKind DomainKind { get; set; }

  public test_DomainRefObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , TDomainKind pdomainKind
    ) : base(pdescription, pname, test_TypeKind.Domain)
  {
    DomainKind = pdomainKind;
  }
}

public class test_BaseDomain<TDomainKind,TItem,TDomainItem>
  : test_ParentType<test_TypeKind, TItem, TDomainItem>
  , Itest_BaseDomain<TDomainKind,TItem,TDomainItem>
{
  public Itest_BaseDomainObject<TDomainKind,TItem,TDomainItem>? As__BaseDomain { get; set; }
}

public class test_BaseDomainObject<TDomainKind,TItem,TDomainItem>
  : test_ParentTypeObject<test_TypeKind, TItem, TDomainItem>
  , Itest_BaseDomainObject<TDomainKind,TItem,TDomainItem>
{
  public TDomainKind DomainKind { get; set; }

  public test_BaseDomainObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , ICollection<Itest_Name> paliases
    , Itest_Named pparent
    , ICollection<TItem> pitems
    , ICollection<TDomainItem> pallItems
    , TDomainKind pdomainKind
    ) : base(pdescription, pname, paliases, test_TypeKind.Domain, pparent, pitems, pallItems)
  {
    DomainKind = pdomainKind;
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
  public bool Exclude { get; set; }

  public test_BaseDomainItemObject
    ( ICollection<string> pdescription
    , bool pexclude
    ) : base(pdescription)
  {
    Exclude = pexclude;
  }
}

public class test_DomainItem<TItem>
  : GqlpModelBase
  , Itest_DomainItem<TItem>
{
  public TItem? As_Parent { get; set; }
  public Itest_DomainItemObject<TItem>? As__DomainItem { get; set; }
}

public class test_DomainItemObject<TItem>
  : GqlpModelBase
  , Itest_DomainItemObject<TItem>
{
  public Itest_Name Domain { get; set; }

  public test_DomainItemObject
    ( Itest_Name pdomain
    )
  {
    Domain = pdomain;
  }
}

public class test_DomainValue<TDomainKind,TValue>
  : test_DomainRef<TDomainKind>
  , Itest_DomainValue<TDomainKind,TValue>
{
  public TValue? Asvalue { get; set; }
  public Itest_DomainValueObject<TDomainKind,TValue>? As__DomainValue { get; set; }
}

public class test_DomainValueObject<TDomainKind,TValue>
  : test_DomainRefObject<TDomainKind>
  , Itest_DomainValueObject<TDomainKind,TValue>
{
  public TValue Value { get; set; }

  public test_DomainValueObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , TDomainKind pdomainKind
    , TValue pvalue
    ) : base(pdescription, pname, pdomainKind)
  {
    Value = pvalue;
  }
}

public class test_BasicValue
  : GqlpModelBase
  , Itest_BasicValue
{
  public bool? AsBoolean { get; set; }
  public Itest_EnumValue? As_EnumValue { get; set; }
  public decimal? AsNumber { get; set; }
  public string? AsString { get; set; }
  public Itest_BasicValueObject? As__BasicValue { get; set; }
}

public class test_BasicValueObject
  : GqlpModelBase
  , Itest_BasicValueObject
{

  public test_BasicValueObject
    ()
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
  public bool Value { get; set; }

  public test_DomainTrueFalseObject
    ( ICollection<string> pdescription
    , bool pexclude
    , bool pvalue
    ) : base(pdescription, pexclude)
  {
    Value = pvalue;
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

  public test_DomainItemTrueFalseObject
    ( Itest_Name pdomain
    ) : base(pdomain)
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

  public test_DomainLabelObject
    ( ICollection<string> pdescription
    , bool pexclude
    , Itest_EnumValue plabel
    ) : base(pdescription, pexclude)
  {
    Label = plabel;
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

  public test_DomainItemLabelObject
    ( Itest_Name pdomain
    ) : base(pdomain)
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
  public decimal? Lower { get; set; }
  public decimal? Upper { get; set; }

  public test_DomainRangeObject
    ( ICollection<string> pdescription
    , bool pexclude
    ) : base(pdescription, pexclude)
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

  public test_DomainItemRangeObject
    ( Itest_Name pdomain
    ) : base(pdomain)
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
  public string Pattern { get; set; }

  public test_DomainRegexObject
    ( ICollection<string> pdescription
    , bool pexclude
    , string ppattern
    ) : base(pdescription, pexclude)
  {
    Pattern = ppattern;
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

  public test_DomainItemRegexObject
    ( Itest_Name pdomain
    ) : base(pdomain)
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

  public test_EnumLabelObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , ICollection<Itest_Name> paliases
    , Itest_Name penumType
    ) : base(pdescription, pname, paliases)
  {
    EnumType = penumType;
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

  public test_EnumValueObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , Itest_Name plabel
    ) : base(pdescription, pname, test_TypeKind.Enum)
  {
    Label = plabel;
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

  public test_UnionRefObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , test_SimpleKind ptypeKind
    ) : base(pdescription, pname, ptypeKind)
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

  public test_UnionMemberObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , test_SimpleKind ptypeKind
    , Itest_Name punion
    ) : base(pdescription, pname, ptypeKind)
  {
    Union = punion;
  }
}

public class test_ObjectKind
  : GqlpDomainEnum
  , Itest_ObjectKind
{
  public new test_TypeKind? Value { get; set; }
}

public class test_TypeObject<TObjectKind,TField>
  : test_ChildType<TObjectKind, Itest_ObjBase>
  , Itest_TypeObject<TObjectKind,TField>
{
  public Itest_TypeObjectObject<TObjectKind,TField>? As__TypeObject { get; set; }
}

public class test_TypeObjectObject<TObjectKind,TField>
  : test_ChildTypeObject<TObjectKind, Itest_ObjBase>
  , Itest_TypeObjectObject<TObjectKind,TField>
{
  public ICollection<Itest_ObjTypeParam> TypeParams { get; set; }
  public ICollection<TField> Fields { get; set; }
  public ICollection<Itest_ObjAlternate> Alternates { get; set; }
  public ICollection<Itest_ObjectFor<TField>> AllFields { get; set; }
  public ICollection<Itest_ObjectFor<Itest_ObjAlternate>> AllAlternates { get; set; }

  public test_TypeObjectObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , ICollection<Itest_Name> paliases
    , TObjectKind ptypeKind
    , Itest_ObjBase pparent
    , ICollection<Itest_ObjTypeParam> ptypeParams
    , ICollection<TField> pfields
    , ICollection<Itest_ObjAlternate> palternates
    , ICollection<Itest_ObjectFor<TField>> pallFields
    , ICollection<Itest_ObjectFor<Itest_ObjAlternate>> pallAlternates
    ) : base(pdescription, pname, paliases, ptypeKind, pparent)
  {
    TypeParams = ptypeParams;
    Fields = pfields;
    Alternates = palternates;
    AllFields = pallFields;
    AllAlternates = pallAlternates;
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

  public test_ObjTypeParamObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , Itest_TypeRef<test_TypeKind> pconstraint
    ) : base(pdescription, pname)
  {
    Constraint = pconstraint;
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

  public test_ObjBaseObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , ICollection<Itest_ObjTypeArg> ptypeArgs
    ) : base(pdescription, pname)
  {
    TypeArgs = ptypeArgs;
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

  public test_ObjTypeArgObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , test_TypeKind ptypeKind
    ) : base(pdescription, pname, ptypeKind)
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

  public test_TypeParamObject
    ( ICollection<string> pdescription
    , Itest_Name ptypeParam
    ) : base(pdescription)
  {
    TypeParam = ptypeParam;
  }
}

public class test_ObjAlternate
  : GqlpModelBase
  , Itest_ObjAlternate
{
  public Itest_ObjAlternateEnum? As_ObjAlternateEnum { get; set; }
  public Itest_ObjAlternateObject? As__ObjAlternate { get; set; }
}

public class test_ObjAlternateObject
  : GqlpModelBase
  , Itest_ObjAlternateObject
{
  public Itest_ObjBase Type { get; set; }
  public ICollection<Itest_Collections> Collections { get; set; }

  public test_ObjAlternateObject
    ( Itest_ObjBase ptype
    , ICollection<Itest_Collections> pcollections
    )
  {
    Type = ptype;
    Collections = pcollections;
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

  public test_ObjAlternateEnumObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , Itest_Name plabel
    ) : base(pdescription, pname, test_TypeKind.Enum)
  {
    Label = plabel;
  }
}

public class test_ObjectFor<TFor>
  : GqlpModelBase
  , Itest_ObjectFor<TFor>
{
  public TFor? As_Parent { get; set; }
  public Itest_ObjectForObject<TFor>? As__ObjectFor { get; set; }
}

public class test_ObjectForObject<TFor>
  : GqlpModelBase
  , Itest_ObjectForObject<TFor>
{
  public Itest_Name ObjectType { get; set; }

  public test_ObjectForObject
    ( Itest_Name pobjectType
    )
  {
    ObjectType = pobjectType;
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

  public test_ObjFieldObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , ICollection<Itest_Name> paliases
    , TType ptype
    ) : base(pdescription, pname, paliases)
  {
    Type = ptype;
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

  public test_ObjFieldTypeObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , ICollection<Itest_ObjTypeArg> ptypeArgs
    , ICollection<Itest_Modifiers> pmodifiers
    ) : base(pdescription, pname, ptypeArgs)
  {
    Modifiers = pmodifiers;
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

  public test_ObjFieldEnumObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , Itest_Name plabel
    ) : base(pdescription, pname, test_TypeKind.Enum)
  {
    Label = plabel;
  }
}

public class test_ForParam<TType>
  : GqlpModelBase
  , Itest_ForParam<TType>
{
  public Itest_ObjAlternate? As_ObjAlternate { get; set; }
  public Itest_ObjField<TType>? As_ObjField { get; set; }
  public Itest_ForParamObject<TType>? As__ForParam { get; set; }
}

public class test_ForParamObject<TType>
  : GqlpModelBase
  , Itest_ForParamObject<TType>
{

  public test_ForParamObject
    ()
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

  public test_DualFieldObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , ICollection<Itest_Name> paliases
    , Itest_ObjFieldType ptype
    ) : base(pdescription, pname, paliases, ptype)
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

  public test_InputFieldObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , ICollection<Itest_Name> paliases
    , Itest_InputFieldType ptype
    ) : base(pdescription, pname, paliases, ptype)
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

  public test_InputFieldTypeObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , ICollection<Itest_ObjTypeArg> ptypeArgs
    , ICollection<Itest_Modifiers> pmodifiers
    ) : base(pdescription, pname, ptypeArgs, pmodifiers)
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

  public test_OutputFieldObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , ICollection<Itest_Name> paliases
    , Itest_ObjFieldType ptype
    ) : base(pdescription, pname, paliases, ptype)
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

  public test_OutputFieldTypeObject
    ( ICollection<string> pdescription
    , Itest_Name pname
    , ICollection<Itest_ObjTypeArg> ptypeArgs
    , ICollection<Itest_Modifiers> pmodifiers
    ) : base(pdescription, pname, ptypeArgs, pmodifiers)
  {
  }
}
