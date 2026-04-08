//HintName: test_Introspection_Enc.gen.cs
// Generated from {CurrentDirectory}Introspection.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Introspection;

internal class test_SchemaEncoder
{
  public IDictionary<Itest_Name, Itest_Categories>? Categories(Itest_CategoryFilter? parameter)
    => null;
  public IDictionary<Itest_Name, Itest_Directives>? Directives(Itest_Filter? parameter)
    => null;
  public IDictionary<Itest_Name, Itest_Type>? Types(Itest_TypeFilter? parameter)
    => null;
  public IDictionary<Itest_Name, Itest_Setting>? Settings(Itest_Filter? parameter)
    => null;
}

internal class test_NameEncoder
{
}

internal class test_FilterEncoder
{
  public ICollection<Itest_NameFilter> Names { get; set; }
  public bool? MatchAliases { get; set; }
  public ICollection<Itest_NameFilter> Aliases { get; set; }
  public bool? ReturnByAlias { get; set; }
  public bool? ReturnReferencedTypes { get; set; }
}

internal class test_NameFilterEncoder
{
}

internal class test_CategoryFilterEncoder
{
  public ICollection<test_Resolution> Resolutions { get; set; }
}

internal class test_TypeFilterEncoder
{
  public ICollection<test_TypeKind> Kinds { get; set; }
}

internal class test_AliasedEncoder
{
  public ICollection<Itest_Name> Aliases { get; set; }
}

internal class test_NamedEncoder
{
  public Itest_Name Name { get; set; }
}

internal class test_DescribedEncoder
{
  public ICollection<string> Description { get; set; }
}

internal class test_AndTypeEncoder
{
  public Itest_Type Type { get; set; }
}

internal class test_CategoriesEncoder
{
  public Itest_Category Category { get; set; }
}

internal class test_CategoryEncoder
{
  public test_Resolution Resolution { get; set; }
  public Itest_TypeRef<test_TypeKind> Output { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
}

internal class test_ResolutionEncoder
{
  public string Parallel { get; set; }
  public string Sequential { get; set; }
  public string Single { get; set; }
}

internal class test_DirectivesEncoder
{
  public Itest_Directive Directive { get; set; }
}

internal class test_DirectiveEncoder
{
  public Itest_InputFieldType? Parameter { get; set; }
  public bool Repeatable { get; set; }
  public IDictionary<test_Location, GqlpUnit> Locations { get; set; }
}

internal class test_LocationEncoder
{
  public string Operation { get; set; }
  public string Variable { get; set; }
  public string Field { get; set; }
  public string Inline { get; set; }
  public string Spread { get; set; }
  public string Fragment { get; set; }
}

internal class test_SettingEncoder
{
  public GqlpValue Value { get; set; }
}

internal class test_TypeEncoder
{
}

internal class test_BaseTypeEncoder<TTypeKind>
{
  public TTypeKind TypeKind { get; set; }
}

internal class test_ChildTypeEncoder<TTypeKind,TParent>
{
  public TParent Parent { get; set; }
}

internal class test_ParentTypeEncoder<TTypeKind,TItem,TAllItem>
{
  public ICollection<TItem> Items { get; set; }
  public ICollection<TAllItem> AllItems { get; set; }
}

internal class test_SimpleKindEncoder
{
  public string Basic { get; set; }
  public string Enum { get; set; }
  public string Internal { get; set; }
  public string Domain { get; set; }
  public string Union { get; set; }
}

internal class test_TypeKindEncoder
{
  public string Basic { get; set; }
  public string Enum { get; set; }
  public string Internal { get; set; }
  public string Domain { get; set; }
  public string Union { get; set; }
  public string Dual { get; set; }
  public string Input { get; set; }
  public string Output { get; set; }
}

internal class test_TypeRefEncoder<TTypeKind>
{
  public TTypeKind TypeKind { get; set; }
}

internal class test_TypeSimpleEncoder
{
}

internal class test_CollectionsEncoder
{
}

internal class test_ModifierKeyedEncoder<TModifierKind>
{
  public Itest_TypeSimple By { get; set; }
  public bool IsOptional { get; set; }
}

internal class test_ModifiersEncoder
{
}

internal class test_ModifierKindEncoder
{
  public string Opt { get; set; }
  public string Optional { get; set; }
  public string List { get; set; }
  public string Dict { get; set; }
  public string Dictionary { get; set; }
  public string Param { get; set; }
  public string TypeParam { get; set; }
}

internal class test_ModifierEncoder<TModifierKind>
{
  public TModifierKind ModifierKind { get; set; }
}

internal class test_DomainKindEncoder
{
  public string Boolean { get; set; }
  public string Enum { get; set; }
  public string Number { get; set; }
  public string String { get; set; }
}

internal class test_DomainRefEncoder<TDomainKind>
{
  public TDomainKind DomainKind { get; set; }
}

internal class test_BaseDomainEncoder<TDomainKind,TItem,TDomainItem>
{
  public TDomainKind DomainKind { get; set; }
}

internal class test_BaseDomainItemEncoder
{
  public bool Exclude { get; set; }
}

internal class test_DomainItemEncoder<TItem>
{
  public Itest_Name Domain { get; set; }
}

internal class test_DomainValueEncoder<TDomainKind,TValue>
{
  public TValue Value { get; set; }
}

internal class test_BasicValueEncoder
{
}

internal class test_DomainTrueFalseEncoder
{
  public bool Value { get; set; }
}

internal class test_DomainItemTrueFalseEncoder
{
}

internal class test_DomainLabelEncoder
{
  public Itest_EnumValue Label { get; set; }
}

internal class test_DomainItemLabelEncoder
{
}

internal class test_DomainRangeEncoder
{
  public decimal? Lower { get; set; }
  public decimal? Upper { get; set; }
}

internal class test_DomainItemRangeEncoder
{
}

internal class test_DomainRegexEncoder
{
  public string Pattern { get; set; }
}

internal class test_DomainItemRegexEncoder
{
}

internal class test_EnumLabelEncoder
{
  public Itest_Name EnumType { get; set; }
}

internal class test_EnumValueEncoder
{
  public Itest_Name Label { get; set; }
}

internal class test_UnionRefEncoder
{
}

internal class test_UnionMemberEncoder
{
  public Itest_Name Union { get; set; }
}

internal class test_ObjectKindEncoder
{
}

internal class test_TypeObjectEncoder<TObjectKind,TField>
{
  public ICollection<Itest_ObjTypeParam> TypeParams { get; set; }
  public ICollection<TField> Fields { get; set; }
  public ICollection<Itest_ObjAlternate> Alternates { get; set; }
  public ICollection<Itest_ObjectFor<TField>> AllFields { get; set; }
  public ICollection<Itest_ObjectFor<Itest_ObjAlternate>> AllAlternates { get; set; }
}

internal class test_ObjTypeParamEncoder
{
  public Itest_TypeRef<test_TypeKind> Constraint { get; set; }
}

internal class test_ObjBaseEncoder
{
  public ICollection<Itest_ObjTypeArg> TypeArgs { get; set; }
}

internal class test_ObjTypeArgEncoder
{
  public Itest_Name? Label { get; set; }
}

internal class test_TypeParamEncoder
{
  public Itest_Name TypeParam { get; set; }
}

internal class test_ObjAlternateEncoder
{
  public Itest_ObjBase Type { get; set; }
  public ICollection<Itest_Collections> Collections { get; set; }
}

internal class test_ObjAlternateEnumEncoder
{
  public Itest_Name Label { get; set; }
}

internal class test_ObjectForEncoder<TFor>
{
  public Itest_Name ObjectType { get; set; }
}

internal class test_ObjFieldEncoder<TType>
{
  public TType Type { get; set; }
}

internal class test_ObjFieldTypeEncoder
{
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
}

internal class test_ObjFieldEnumEncoder
{
  public Itest_Name Label { get; set; }
}

internal class test_ForParamEncoder<TType>
{
}

internal class test_DualFieldEncoder
{
}

internal class test_InputFieldEncoder
{
}

internal class test_InputFieldTypeEncoder
{
  public GqlpValue? DefaultValue { get; set; }
}

internal class test_OutputFieldEncoder
{
}

internal class test_OutputFieldTypeEncoder
{
  public Itest_InputFieldType? Parameter { get; set; }
}
