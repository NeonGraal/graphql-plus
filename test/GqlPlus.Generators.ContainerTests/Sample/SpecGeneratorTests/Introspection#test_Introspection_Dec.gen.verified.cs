//HintName: test_Introspection_Dec.gen.cs
// Generated from {CurrentDirectory}Introspection.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Introspection;

internal class test_SchemaDecoder
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

internal class test_NameDecoder
{
}

internal class test_FilterDecoder
{
  public ICollection<Itest_NameFilter> Names { get; set; }
  public bool? MatchAliases { get; set; }
  public ICollection<Itest_NameFilter> Aliases { get; set; }
  public bool? ReturnByAlias { get; set; }
  public bool? ReturnReferencedTypes { get; set; }
}

internal class test_NameFilterDecoder
{
}

internal class test_CategoryFilterDecoder
{
  public ICollection<test_Resolution> Resolutions { get; set; }
}

internal class test_TypeFilterDecoder
{
  public ICollection<test_TypeKind> Kinds { get; set; }
}

internal class test_AliasedDecoder
{
  public ICollection<Itest_Name> Aliases { get; set; }
}

internal class test_NamedDecoder
{
  public Itest_Name Name { get; set; }
}

internal class test_DescribedDecoder
{
  public ICollection<string> Description { get; set; }
}

internal class test_AndTypeDecoder
{
  public Itest_Type Type { get; set; }
}

internal class test_CategoriesDecoder
{
  public Itest_Category Category { get; set; }
}

internal class test_CategoryDecoder
{
  public test_Resolution Resolution { get; set; }
  public Itest_TypeRef<test_TypeKind> Output { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
}

internal class test_ResolutionDecoder
{
  public string Parallel { get; set; }
  public string Sequential { get; set; }
  public string Single { get; set; }
}

internal class test_DirectivesDecoder
{
  public Itest_Directive Directive { get; set; }
}

internal class test_DirectiveDecoder
{
  public Itest_InputFieldType? Parameter { get; set; }
  public bool Repeatable { get; set; }
  public IDictionary<test_Location, GqlpUnit> Locations { get; set; }
}

internal class test_LocationDecoder
{
  public string Operation { get; set; }
  public string Variable { get; set; }
  public string Field { get; set; }
  public string Inline { get; set; }
  public string Spread { get; set; }
  public string Fragment { get; set; }
}

internal class test_SettingDecoder
{
  public GqlpValue Value { get; set; }
}

internal class test_TypeDecoder
{
}

internal class test_BaseTypeDecoder<TTypeKind>
{
  public TTypeKind TypeKind { get; set; }
}

internal class test_ChildTypeDecoder<TTypeKind,TParent>
{
  public TParent Parent { get; set; }
}

internal class test_ParentTypeDecoder<TTypeKind,TItem,TAllItem>
{
  public ICollection<TItem> Items { get; set; }
  public ICollection<TAllItem> AllItems { get; set; }
}

internal class test_SimpleKindDecoder
{
  public string Basic { get; set; }
  public string Enum { get; set; }
  public string Internal { get; set; }
  public string Domain { get; set; }
  public string Union { get; set; }
}

internal class test_TypeKindDecoder
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

internal class test_TypeRefDecoder<TTypeKind>
{
  public TTypeKind TypeKind { get; set; }
}

internal class test_TypeSimpleDecoder
{
}

internal class test_CollectionsDecoder
{
}

internal class test_ModifierKeyedDecoder<TModifierKind>
{
  public Itest_TypeSimple By { get; set; }
  public bool IsOptional { get; set; }
}

internal class test_ModifiersDecoder
{
}

internal class test_ModifierKindDecoder
{
  public string Opt { get; set; }
  public string Optional { get; set; }
  public string List { get; set; }
  public string Dict { get; set; }
  public string Dictionary { get; set; }
  public string Param { get; set; }
  public string TypeParam { get; set; }
}

internal class test_ModifierDecoder<TModifierKind>
{
  public TModifierKind ModifierKind { get; set; }
}

internal class test_DomainKindDecoder
{
  public string Boolean { get; set; }
  public string Enum { get; set; }
  public string Number { get; set; }
  public string String { get; set; }
}

internal class test_DomainRefDecoder<TDomainKind>
{
  public TDomainKind DomainKind { get; set; }
}

internal class test_BaseDomainDecoder<TDomainKind,TItem,TDomainItem>
{
  public TDomainKind DomainKind { get; set; }
}

internal class test_BaseDomainItemDecoder
{
  public bool Exclude { get; set; }
}

internal class test_DomainItemDecoder<TItem>
{
  public Itest_Name Domain { get; set; }
}

internal class test_DomainValueDecoder<TDomainKind,TValue>
{
  public TValue Value { get; set; }
}

internal class test_BasicValueDecoder
{
}

internal class test_DomainTrueFalseDecoder
{
  public bool Value { get; set; }
}

internal class test_DomainItemTrueFalseDecoder
{
}

internal class test_DomainLabelDecoder
{
  public Itest_EnumValue Label { get; set; }
}

internal class test_DomainItemLabelDecoder
{
}

internal class test_DomainRangeDecoder
{
  public decimal? Lower { get; set; }
  public decimal? Upper { get; set; }
}

internal class test_DomainItemRangeDecoder
{
}

internal class test_DomainRegexDecoder
{
  public string Pattern { get; set; }
}

internal class test_DomainItemRegexDecoder
{
}

internal class test_EnumLabelDecoder
{
  public Itest_Name EnumType { get; set; }
}

internal class test_EnumValueDecoder
{
  public Itest_Name Label { get; set; }
}

internal class test_UnionRefDecoder
{
}

internal class test_UnionMemberDecoder
{
  public Itest_Name Union { get; set; }
}

internal class test_ObjectKindDecoder
{
}

internal class test_TypeObjectDecoder<TObjectKind,TField>
{
  public ICollection<Itest_ObjTypeParam> TypeParams { get; set; }
  public ICollection<TField> Fields { get; set; }
  public ICollection<Itest_ObjAlternate> Alternates { get; set; }
  public ICollection<Itest_ObjectFor<TField>> AllFields { get; set; }
  public ICollection<Itest_ObjectFor<Itest_ObjAlternate>> AllAlternates { get; set; }
}

internal class test_ObjTypeParamDecoder
{
  public Itest_TypeRef<test_TypeKind> Constraint { get; set; }
}

internal class test_ObjBaseDecoder
{
  public ICollection<Itest_ObjTypeArg> TypeArgs { get; set; }
}

internal class test_ObjTypeArgDecoder
{
  public Itest_Name? Label { get; set; }
}

internal class test_TypeParamDecoder
{
  public Itest_Name TypeParam { get; set; }
}

internal class test_ObjAlternateDecoder
{
  public Itest_ObjBase Type { get; set; }
  public ICollection<Itest_Collections> Collections { get; set; }
}

internal class test_ObjAlternateEnumDecoder
{
  public Itest_Name Label { get; set; }
}

internal class test_ObjectForDecoder<TFor>
{
  public Itest_Name ObjectType { get; set; }
}

internal class test_ObjFieldDecoder<TType>
{
  public TType Type { get; set; }
}

internal class test_ObjFieldTypeDecoder
{
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
}

internal class test_ObjFieldEnumDecoder
{
  public Itest_Name Label { get; set; }
}

internal class test_ForParamDecoder<TType>
{
}

internal class test_DualFieldDecoder
{
}

internal class test_InputFieldDecoder
{
}

internal class test_InputFieldTypeDecoder
{
  public GqlpValue? DefaultValue { get; set; }
}

internal class test_OutputFieldDecoder
{
}

internal class test_OutputFieldTypeDecoder
{
  public Itest_InputFieldType? Parameter { get; set; }
}
