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
  public IDictionary<Itest_Name, Itest_Categories>? Categories()
    => null;
  public IDictionary<Itest_Name, Itest_Directives>? Directives(Itest_Filter? parameter)
    => null;
  public IDictionary<Itest_Name, Itest_Directives>? Directives()
    => null;
  public IDictionary<Itest_Name, Itest_Type>? Types(Itest_TypeFilter? parameter)
    => null;
  public IDictionary<Itest_Name, Itest_Type>? Types()
    => null;
  public IDictionary<Itest_Name, Itest_Setting>? Settings(Itest_Filter? parameter)
    => null;
  public IDictionary<Itest_Name, Itest_Setting>? Settings()
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

internal static class test_IntrospectionDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_IntrospectionDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_SchemaObject>(r => new test_SchemaDecoder(r))
      .AddDecoder<Itest_Name>(_ => new test_NameDecoder())
      .AddDecoder<Itest_FilterObject>(r => new test_FilterDecoder(r))
      .AddDecoder<Itest_NameFilter>(_ => new test_NameFilterDecoder())
      .AddDecoder<Itest_CategoryFilterObject>(r => new test_CategoryFilterDecoder(r))
      .AddDecoder<Itest_TypeFilterObject>(r => new test_TypeFilterDecoder(r))
      .AddDecoder<Itest_AliasedObject>(r => new test_AliasedDecoder(r))
      .AddDecoder<Itest_NamedObject>(r => new test_NamedDecoder(r))
      .AddDecoder<Itest_DescribedObject>(r => new test_DescribedDecoder(r))
      .AddDecoder<Itest_AndTypeObject>(r => new test_AndTypeDecoder(r))
      .AddDecoder<Itest_CategoriesObject>(r => new test_CategoriesDecoder(r))
      .AddDecoder<Itest_CategoryObject>(r => new test_CategoryDecoder(r))
      .AddDecoder<test_Resolution>(_ => new test_ResolutionDecoder())
      .AddDecoder<Itest_DirectivesObject>(r => new test_DirectivesDecoder(r))
      .AddDecoder<Itest_DirectiveObject>(r => new test_DirectiveDecoder(r))
      .AddDecoder<test_Location>(_ => new test_LocationDecoder())
      .AddDecoder<Itest_SettingObject>(r => new test_SettingDecoder(r))
      .AddDecoder<Itest_TypeObject>(_ => new test_TypeDecoder())
      .AddDecoder<test_SimpleKind>(_ => new test_SimpleKindDecoder())
      .AddDecoder<test_TypeKind>(_ => new test_TypeKindDecoder())
      .AddDecoder<Itest_TypeSimpleObject>(_ => new test_TypeSimpleDecoder())
      .AddDecoder<Itest_CollectionsObject>(_ => new test_CollectionsDecoder())
      .AddDecoder<Itest_ModifiersObject>(_ => new test_ModifiersDecoder())
      .AddDecoder<test_ModifierKind>(_ => new test_ModifierKindDecoder())
      .AddDecoder<test_DomainKind>(_ => new test_DomainKindDecoder())
      .AddDecoder<Itest_BaseDomainItemObject>(r => new test_BaseDomainItemDecoder(r))
      .AddDecoder<Itest_BasicValueObject>(_ => new test_BasicValueDecoder())
      .AddDecoder<Itest_DomainTrueFalseObject>(r => new test_DomainTrueFalseDecoder(r))
      .AddDecoder<Itest_DomainItemTrueFalseObject>(_ => new test_DomainItemTrueFalseDecoder())
      .AddDecoder<Itest_DomainLabelObject>(r => new test_DomainLabelDecoder(r))
      .AddDecoder<Itest_DomainItemLabelObject>(_ => new test_DomainItemLabelDecoder())
      .AddDecoder<Itest_DomainRangeObject>(r => new test_DomainRangeDecoder(r))
      .AddDecoder<Itest_DomainItemRangeObject>(_ => new test_DomainItemRangeDecoder())
      .AddDecoder<Itest_DomainRegexObject>(r => new test_DomainRegexDecoder(r))
      .AddDecoder<Itest_DomainItemRegexObject>(_ => new test_DomainItemRegexDecoder())
      .AddDecoder<Itest_EnumLabelObject>(r => new test_EnumLabelDecoder(r))
      .AddDecoder<Itest_EnumValueObject>(r => new test_EnumValueDecoder(r))
      .AddDecoder<Itest_UnionRefObject>(_ => new test_UnionRefDecoder())
      .AddDecoder<Itest_UnionMemberObject>(r => new test_UnionMemberDecoder(r))
      .AddDecoder<Itest_ObjectKind>(_ => new test_ObjectKindDecoder())
      .AddDecoder<Itest_ObjTypeParamObject>(r => new test_ObjTypeParamDecoder(r))
      .AddDecoder<Itest_ObjBaseObject>(r => new test_ObjBaseDecoder(r))
      .AddDecoder<Itest_ObjTypeArgObject>(r => new test_ObjTypeArgDecoder(r))
      .AddDecoder<Itest_TypeParamObject>(r => new test_TypeParamDecoder(r))
      .AddDecoder<Itest_ObjAlternateObject>(r => new test_ObjAlternateDecoder(r))
      .AddDecoder<Itest_ObjAlternateEnumObject>(r => new test_ObjAlternateEnumDecoder(r))
      .AddDecoder<Itest_ObjFieldTypeObject>(r => new test_ObjFieldTypeDecoder(r))
      .AddDecoder<Itest_ObjFieldEnumObject>(r => new test_ObjFieldEnumDecoder(r))
      .AddDecoder<Itest_DualFieldObject>(_ => new test_DualFieldDecoder())
      .AddDecoder<Itest_InputFieldObject>(_ => new test_InputFieldDecoder())
      .AddDecoder<Itest_InputFieldTypeObject>(r => new test_InputFieldTypeDecoder(r))
      .AddDecoder<Itest_OutputFieldObject>(_ => new test_OutputFieldDecoder())
      .AddDecoder<Itest_OutputFieldTypeObject>(r => new test_OutputFieldTypeDecoder(r));
}
