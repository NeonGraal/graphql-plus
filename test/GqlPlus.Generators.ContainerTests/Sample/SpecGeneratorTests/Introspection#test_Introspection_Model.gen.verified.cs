//HintName: test_Introspection_Model.gen.cs
// Generated from {CurrentDirectory}Introspection.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
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
  public IDictionary<Itest_Name, Itest_Operations>? Operations(Itest_Filter? parameter)
    => null;
  public IDictionary<Itest_Name, Itest_Type>? Types(Itest_TypeFilter? parameter)
    => null;
  public IDictionary<Itest_Name, Itest_Setting>? Settings(Itest_Filter? parameter)
    => null;

  public test_SchemaObject
    ( ICollection<string> description
    , Itest_Name name
    ) : base(description, name)
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
  public bool? MatchAliases { get; set; }
  public ICollection<Itest_NameFilter> Aliases { get; set; }
  public bool? ReturnByAlias { get; set; }
  public bool? ReturnReferencedTypes { get; set; }

  public test_FilterObject
    ( ICollection<Itest_NameFilter> names
    , ICollection<Itest_NameFilter> aliases
    )
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

  public test_CategoryFilterObject
    ( ICollection<Itest_NameFilter> names
    , ICollection<Itest_NameFilter> aliases
    , ICollection<test_Resolution> resolutions
    ) : base(names, aliases)
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

  public test_TypeFilterObject
    ( ICollection<Itest_NameFilter> names
    , ICollection<Itest_NameFilter> aliases
    , ICollection<test_TypeKind> kinds
    ) : base(names, aliases)
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

  public test_AliasedObject
    ( ICollection<string> description
    , Itest_Name name
    , ICollection<Itest_Name> aliases
    ) : base(description, name)
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

  public test_NamedObject
    ( ICollection<string> description
    , Itest_Name name
    ) : base(description)
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
  public ICollection<string> Description { get; set; }

  public test_DescribedObject
    ( ICollection<string> description
    )
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

  public test_AndTypeObject
    ( ICollection<string> description
    , Itest_Name name
    , Itest_Type type
    ) : base(description, name)
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

  public test_CategoriesObject
    ( ICollection<string> description
    , Itest_Name name
    , Itest_Type type
    , Itest_Category category
    ) : base(description, name, type)
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

  public test_CategoryObject
    ( ICollection<string> description
    , Itest_Name name
    , ICollection<Itest_Name> aliases
    , test_Resolution resolution
    , Itest_TypeRef<test_TypeKind> output
    , ICollection<Itest_Modifiers> modifiers
    ) : base(description, name, aliases)
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

  public test_DirectivesObject
    ( ICollection<string> description
    , Itest_Name name
    , Itest_Type type
    , Itest_Directive directive
    ) : base(description, name, type)
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
  public bool Repeatable { get; set; }
  public IDictionary<test_Location, GqlpUnit> Locations { get; set; }

  public test_DirectiveObject
    ( ICollection<string> description
    , Itest_Name name
    , ICollection<Itest_Name> aliases
    , bool repeatable
    , IDictionary<test_Location, GqlpUnit> locations
    ) : base(description, name, aliases)
  {
    Repeatable = repeatable;
    Locations = locations;
  }
}

public class test_Operations
  : GqlpModelImplementationBase
  , Itest_Operations
{
  public Itest_Operation? As_Operation { get; set; }
  public Itest_Type? As_Type { get; set; }
  public Itest_OperationsObject? As__Operations { get; set; }
}

public class test_OperationsObject
  : GqlpModelImplementationBase
  , Itest_OperationsObject
{
  public Itest_Operation Operation { get; set; }
  public Itest_Type Type { get; set; }

  public test_OperationsObject
    ( Itest_Operation operation
    , Itest_Type type
    )
  {
    Operation = operation;
    Type = type;
  }
}

public class test_OpDirectives
  : test_Named
  , Itest_OpDirectives
{
  public Itest_OpDirectivesObject? As__OpDirectives { get; set; }
}

public class test_OpDirectivesObject
  : test_NamedObject
  , Itest_OpDirectivesObject
{
  public ICollection<Itest_OpDirective> Directives { get; set; }

  public test_OpDirectivesObject
    ( ICollection<string> description
    , Itest_Name name
    , ICollection<Itest_OpDirective> directives
    ) : base(description, name)
  {
    Directives = directives;
  }
}

public class test_Operation
  : test_Aliased
  , Itest_Operation
{
  public Itest_OperationObject? As__Operation { get; set; }
}

public class test_OperationObject
  : test_AliasedObject
  , Itest_OperationObject
{
  public Itest_Name Category { get; set; }
  public IDictionary<Itest_Name, Itest_OpVariable> Variables { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
  public IDictionary<Itest_Name, Itest_OpFragment> Fragments { get; set; }
  public Itest_OpResult Result { get; set; }
  public IDictionary<Itest_Path, ICollection<Itest_OpSelection>> Selections { get; set; }

  public test_OperationObject
    ( ICollection<string> description
    , Itest_Name name
    , ICollection<Itest_Name> aliases
    , Itest_Name category
    , IDictionary<Itest_Name, Itest_OpVariable> variables
    , ICollection<Itest_OpDirective> directives
    , IDictionary<Itest_Name, Itest_OpFragment> fragments
    , Itest_OpResult result
    , IDictionary<Itest_Path, ICollection<Itest_OpSelection>> selections
    ) : base(description, name, aliases)
  {
    Category = category;
    Variables = variables;
    Directives = directives;
    Fragments = fragments;
    Result = result;
    Selections = selections;
  }
}

public class test_OpVariable
  : test_OpDirectives
  , Itest_OpVariable
{
  public Itest_OpVariableObject? As__OpVariable { get; set; }
}

public class test_OpVariableObject
  : test_OpDirectivesObject
  , Itest_OpVariableObject
{
  public Itest_TypeRef<test_TypeKind> Type { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
  public GqlpValue? DefaultValue { get; set; }

  public test_OpVariableObject
    ( ICollection<string> description
    , Itest_Name name
    , ICollection<Itest_OpDirective> directives
    , Itest_TypeRef<test_TypeKind> type
    , ICollection<Itest_Modifiers> modifiers
    ) : base(description, name, directives)
  {
    Type = type;
    Modifiers = modifiers;
  }
}

public class test_OpDirective
  : test_Named
  , Itest_OpDirective
{
  public Itest_OpDirectiveObject? As__OpDirective { get; set; }
}

public class test_OpDirectiveObject
  : test_NamedObject
  , Itest_OpDirectiveObject
{
  public Itest_OpArgument? Argument { get; set; }

  public test_OpDirectiveObject
    ( ICollection<string> description
    , Itest_Name name
    ) : base(description, name)
  {
  }
}

public class test_OpFragment
  : test_OpDirectives
  , Itest_OpFragment
{
  public Itest_OpFragmentObject? As__OpFragment { get; set; }
}

public class test_OpFragmentObject
  : test_OpDirectivesObject
  , Itest_OpFragmentObject
{
  public Itest_TypeRef<test_TypeKind> Type { get; set; }

  public test_OpFragmentObject
    ( ICollection<string> description
    , Itest_Name name
    , ICollection<Itest_OpDirective> directives
    , Itest_TypeRef<test_TypeKind> type
    ) : base(description, name, directives)
  {
    Type = type;
  }
}

public class test_OpArgument
  : GqlpModelImplementationBase
  , Itest_OpArgument
{
  public Itest_OpArgValue? As_OpArgValue { get; set; }
  public Itest_OpArgList? As_OpArgList { get; set; }
  public Itest_OpArgMap? As_OpArgMap { get; set; }
  public Itest_OpArgumentObject? As__OpArgument { get; set; }
}

public class test_OpArgumentObject
  : GqlpModelImplementationBase
  , Itest_OpArgumentObject
{

  public test_OpArgumentObject
    ()
  {
  }
}

public class test_OpArgValue
  : GqlpModelImplementationBase
  , Itest_OpArgValue
{
  public GqlpValue? AsValue { get; set; }
  public Itest_OpArgValueObject? As__OpArgValue { get; set; }
}

public class test_OpArgValueObject
  : GqlpModelImplementationBase
  , Itest_OpArgValueObject
{
  public Itest_Name Variable { get; set; }

  public test_OpArgValueObject
    ( Itest_Name variable
    )
  {
    Variable = variable;
  }
}

public class test_OpArgList
  : GqlpModelImplementationBase
  , Itest_OpArgList
{
  public ICollection<Itest_OpArgValue>? As_OpArgValue { get; set; }
  public Itest_OpArgListObject? As__OpArgList { get; set; }
}

public class test_OpArgListObject
  : GqlpModelImplementationBase
  , Itest_OpArgListObject
{

  public test_OpArgListObject
    ()
  {
  }
}

public class test_OpArgMap
  : GqlpModelImplementationBase
  , Itest_OpArgMap
{
  public IDictionary<GqlpScalar, Itest_OpArgValue>? As_OpArgValue { get; set; }
  public Itest_OpArgMapObject? As__OpArgMap { get; set; }
}

public class test_OpArgMapObject
  : GqlpModelImplementationBase
  , Itest_OpArgMapObject
{
  public Itest_OpArgValue Value { get; set; }
  public Itest_Name ByVariable { get; set; }

  public test_OpArgMapObject
    ( Itest_OpArgValue value
    , Itest_Name byVariable
    )
  {
    Value = value;
    ByVariable = byVariable;
  }
}

public class test_OpResult
  : GqlpModelImplementationBase
  , Itest_OpResult
{
  public Itest_TypeRef<test_SimpleKind>? As_TypeRef { get; set; }
  public Itest_OpResultObject? As__OpResult { get; set; }
}

public class test_OpResultObject
  : GqlpModelImplementationBase
  , Itest_OpResultObject
{
  public Itest_OpArgument? Argument { get; set; }

  public test_OpResultObject
    ()
  {
  }
}

public class test_Path
  : GqlpDomainString
  , Itest_Path
{
}

public class test_OpSelection
  : GqlpModelImplementationBase
  , Itest_OpSelection
{
  public Itest_OpField? As_OpField { get; set; }
  public Itest_OpSpread? As_OpSpread { get; set; }
  public Itest_OpInline? As_OpInline { get; set; }
  public Itest_OpSelectionObject? As__OpSelection { get; set; }
}

public class test_OpSelectionObject
  : GqlpModelImplementationBase
  , Itest_OpSelectionObject
{

  public test_OpSelectionObject
    ()
  {
  }
}

public class test_OpField
  : test_OpDirectives
  , Itest_OpField
{
  public Itest_OpFieldObject? As__OpField { get; set; }
}

public class test_OpFieldObject
  : test_OpDirectivesObject
  , Itest_OpFieldObject
{
  public string? FieldAlias { get; set; }
  public Itest_OpArgument? Argument { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }

  public test_OpFieldObject
    ( ICollection<string> description
    , Itest_Name name
    , ICollection<Itest_OpDirective> directives
    , ICollection<Itest_Modifiers> modifiers
    ) : base(description, name, directives)
  {
    Modifiers = modifiers;
  }
}

public class test_OpInline
  : GqlpModelImplementationBase
  , Itest_OpInline
{
  public Itest_OpInlineObject? As__OpInline { get; set; }
}

public class test_OpInlineObject
  : GqlpModelImplementationBase
  , Itest_OpInlineObject
{
  public Itest_TypeRef<test_TypeKind>? Type { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }

  public test_OpInlineObject
    ( ICollection<Itest_OpDirective> directives
    )
  {
    Directives = directives;
  }
}

public class test_OpSpread
  : GqlpModelImplementationBase
  , Itest_OpSpread
{
  public Itest_OpSpreadObject? As__OpSpread { get; set; }
}

public class test_OpSpreadObject
  : GqlpModelImplementationBase
  , Itest_OpSpreadObject
{
  public string Fragment { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }

  public test_OpSpreadObject
    ( string fragment
    , ICollection<Itest_OpDirective> directives
    )
  {
    Fragment = fragment;
    Directives = directives;
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
    ( ICollection<string> description
    , Itest_Name name
    , GqlpValue value
    ) : base(description, name)
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
    ( ICollection<string> description
    , Itest_Name name
    , ICollection<Itest_Name> aliases
    , TTypeKind typeKind
    ) : base(description, name, aliases)
  {
    TypeKind = typeKind;
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
    ( ICollection<string> description
    , Itest_Name name
    , ICollection<Itest_Name> aliases
    , TTypeKind typeKind
    , TParent parent
    ) : base(description, name, aliases, typeKind)
  {
    Parent = parent;
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
    ( ICollection<string> description
    , Itest_Name name
    , ICollection<Itest_Name> aliases
    , TTypeKind typeKind
    , Itest_Named parent
    , ICollection<TItem> items
    , ICollection<TAllItem> allItems
    ) : base(description, name, aliases, typeKind, parent)
  {
    Items = items;
    AllItems = allItems;
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
    ( ICollection<string> description
    , Itest_Name name
    , TTypeKind typeKind
    ) : base(description, name)
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
    ( TModifierKind modifierKind
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

public class test_Modifier<TModifierKind>
  : GqlpModelImplementationBase
  , Itest_Modifier<TModifierKind>
{
  public Itest_ModifierObject<TModifierKind>? As__Modifier { get; set; }
}

public class test_ModifierObject<TModifierKind>
  : GqlpModelImplementationBase
  , Itest_ModifierObject<TModifierKind>
{
  public TModifierKind ModifierKind { get; set; }

  public test_ModifierObject
    ( TModifierKind modifierKind
    )
  {
    ModifierKind = modifierKind;
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
    ( ICollection<string> description
    , Itest_Name name
    , TDomainKind domainKind
    ) : base(description, name, test_TypeKind.Domain)
  {
    DomainKind = domainKind;
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
    ( ICollection<string> description
    , Itest_Name name
    , ICollection<Itest_Name> aliases
    , Itest_Named parent
    , ICollection<TItem> items
    , ICollection<TDomainItem> allItems
    , TDomainKind domainKind
    ) : base(description, name, aliases, test_TypeKind.Domain, parent, items, allItems)
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
  public bool Exclude { get; set; }

  public test_BaseDomainItemObject
    ( ICollection<string> description
    , bool exclude
    ) : base(description)
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

  public test_DomainItemObject
    ( Itest_Name domain
    )
  {
    Domain = domain;
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
    ( ICollection<string> description
    , Itest_Name name
    , TDomainKind domainKind
    , TValue value
    ) : base(description, name, domainKind)
  {
    Value = value;
  }
}

public class test_BasicValue
  : GqlpModelImplementationBase
  , Itest_BasicValue
{
  public bool? AsBoolean { get; set; }
  public Itest_EnumValue? As_EnumValue { get; set; }
  public decimal? AsNumber { get; set; }
  public string? AsString { get; set; }
  public Itest_BasicValueObject? As__BasicValue { get; set; }
}

public class test_BasicValueObject
  : GqlpModelImplementationBase
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
    ( ICollection<string> description
    , bool exclude
    , bool value
    ) : base(description, exclude)
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

  public test_DomainItemTrueFalseObject
    ( Itest_Name domain
    ) : base(domain)
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
    ( ICollection<string> description
    , bool exclude
    , Itest_EnumValue label
    ) : base(description, exclude)
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

  public test_DomainItemLabelObject
    ( Itest_Name domain
    ) : base(domain)
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
    ( ICollection<string> description
    , bool exclude
    ) : base(description, exclude)
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
    ( Itest_Name domain
    ) : base(domain)
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
    ( ICollection<string> description
    , bool exclude
    , string pattern
    ) : base(description, exclude)
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

  public test_DomainItemRegexObject
    ( Itest_Name domain
    ) : base(domain)
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
    ( ICollection<string> description
    , Itest_Name name
    , ICollection<Itest_Name> aliases
    , Itest_Name enumType
    ) : base(description, name, aliases)
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

  public test_EnumValueObject
    ( ICollection<string> description
    , Itest_Name name
    , Itest_Name label
    ) : base(description, name, test_TypeKind.Enum)
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

  public test_UnionRefObject
    ( ICollection<string> description
    , Itest_Name name
    , test_SimpleKind typeKind
    ) : base(description, name, typeKind)
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
    ( ICollection<string> description
    , Itest_Name name
    , test_SimpleKind typeKind
    , Itest_Name union
    ) : base(description, name, typeKind)
  {
    Union = union;
  }
}

public class test_ObjectKind
  : GqlpDomainEnum
  , Itest_ObjectKind
{
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
    ( ICollection<string> description
    , Itest_Name name
    , ICollection<Itest_Name> aliases
    , TObjectKind typeKind
    , Itest_ObjBase parent
    , ICollection<Itest_ObjTypeParam> typeParams
    , ICollection<TField> fields
    , ICollection<Itest_ObjAlternate> alternates
    , ICollection<Itest_ObjectFor<TField>> allFields
    , ICollection<Itest_ObjectFor<Itest_ObjAlternate>> allAlternates
    ) : base(description, name, aliases, typeKind, parent)
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

  public test_ObjTypeParamObject
    ( ICollection<string> description
    , Itest_Name name
    , Itest_TypeRef<test_TypeKind> constraint
    ) : base(description, name)
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

  public test_ObjBaseObject
    ( ICollection<string> description
    , Itest_Name name
    , ICollection<Itest_ObjTypeArg> typeArgs
    ) : base(description, name)
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

  public test_ObjTypeArgObject
    ( ICollection<string> description
    , Itest_Name name
    , test_TypeKind typeKind
    ) : base(description, name, typeKind)
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
    ( ICollection<string> description
    , Itest_Name typeParam
    ) : base(description)
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

  public test_ObjAlternateObject
    ( Itest_ObjBase type
    , ICollection<Itest_Collections> collections
    )
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

  public test_ObjAlternateEnumObject
    ( ICollection<string> description
    , Itest_Name name
    , Itest_Name label
    ) : base(description, name, test_TypeKind.Enum)
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

  public test_ObjectForObject
    ( Itest_Name objectType
    )
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

  public test_ObjFieldObject
    ( ICollection<string> description
    , Itest_Name name
    , ICollection<Itest_Name> aliases
    , TType type
    ) : base(description, name, aliases)
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

  public test_ObjFieldTypeObject
    ( ICollection<string> description
    , Itest_Name name
    , ICollection<Itest_ObjTypeArg> typeArgs
    , ICollection<Itest_Modifiers> modifiers
    ) : base(description, name, typeArgs)
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

  public test_ObjFieldEnumObject
    ( ICollection<string> description
    , Itest_Name name
    , Itest_Name label
    ) : base(description, name, test_TypeKind.Enum)
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
    ( ICollection<string> description
    , Itest_Name name
    , ICollection<Itest_Name> aliases
    , Itest_ObjFieldType type
    ) : base(description, name, aliases, type)
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
    ( ICollection<string> description
    , Itest_Name name
    , ICollection<Itest_Name> aliases
    , Itest_InputFieldType type
    ) : base(description, name, aliases, type)
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
    ( ICollection<string> description
    , Itest_Name name
    , ICollection<Itest_ObjTypeArg> typeArgs
    , ICollection<Itest_Modifiers> modifiers
    ) : base(description, name, typeArgs, modifiers)
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
    ( ICollection<string> description
    , Itest_Name name
    , ICollection<Itest_Name> aliases
    , Itest_ObjFieldType type
    ) : base(description, name, aliases, type)
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
    ( ICollection<string> description
    , Itest_Name name
    , ICollection<Itest_ObjTypeArg> typeArgs
    , ICollection<Itest_Modifiers> modifiers
    ) : base(description, name, typeArgs, modifiers)
  {
  }
}
