//HintName: test_Introspection_Enc.gen.cs
// Generated from {CurrentDirectory}Introspection.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Introspection;

internal class test_SchemaEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_SchemaObject>
{
  private readonly IEncoder<Itest_NamedObject> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  public Structured Encode(Itest_SchemaObject input)
    => _itest_Named.Encode(input);
}

internal class test_NameEncoder : IEncoder<Itest_Name>
{
  public Structured Encode(Itest_Name input)
    => new(input.Value);
}

internal class test_NameFilterEncoder : IEncoder<Itest_NameFilter>
{
  public Structured Encode(Itest_NameFilter input)
    => new(input.Value);
}

internal class test_AliasedEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_AliasedObject>
{
  private readonly IEncoder<Itest_NamedObject> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_AliasedObject input)
    => _itest_Named.Encode(input)
      .AddList("aliases", input.Aliases, _itest_Name);
}

internal class test_NamedEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_NamedObject>
{
  private readonly IEncoder<Itest_DescribedObject> _itest_Described = encoders.EncoderFor<Itest_DescribedObject>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_NamedObject input)
    => _itest_Described.Encode(input)
      .AddEncoded("name", input.Name, _itest_Name);
}

internal class test_DescribedEncoder : IEncoder<Itest_DescribedObject>
{
  public Structured Encode(Itest_DescribedObject input)
    => Structured.Empty()
      .Add("description", input.Description.Encode());
}

internal class test_AndTypeEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_AndTypeObject>
{
  private readonly IEncoder<Itest_NamedObject> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  private readonly IEncoder<Itest_Type> _itest_Type = encoders.EncoderFor<Itest_Type>();
  public Structured Encode(Itest_AndTypeObject input)
    => _itest_Named.Encode(input)
      .AddEncoded("type", input.Type, _itest_Type);
}

internal class test_CategoriesEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_CategoriesObject>
{
  private readonly IEncoder<Itest_AndTypeObject> _itest_AndType = encoders.EncoderFor<Itest_AndTypeObject>();
  private readonly IEncoder<Itest_Category> _itest_Category = encoders.EncoderFor<Itest_Category>();
  public Structured Encode(Itest_CategoriesObject input)
    => _itest_AndType.Encode(input)
      .AddEncoded("category", input.Category, _itest_Category);
}

internal class test_CategoryEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_CategoryObject>
{
  private readonly IEncoder<Itest_AliasedObject> _itest_Aliased = encoders.EncoderFor<Itest_AliasedObject>();
  private readonly IEncoder<Itest_TypeRef<test_TypeKind>> _itest_TypeRef = encoders.EncoderFor<Itest_TypeRef<test_TypeKind>>();
  private readonly IEncoder<Itest_Modifiers> _itest_Modifiers = encoders.EncoderFor<Itest_Modifiers>();
  public Structured Encode(Itest_CategoryObject input)
    => _itest_Aliased.Encode(input)
      .AddEnum("resolution", input.Resolution)
      .AddEncoded("output", input.Output, _itest_TypeRef)
      .AddList("modifiers", input.Modifiers, _itest_Modifiers);
}

internal class test_ResolutionEncoder : IEncoder<test_Resolution>
{
  public Structured Encode(test_Resolution input)
    => new(input.ToString(), "_Resolution");
}

internal class test_DirectivesEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DirectivesObject>
{
  private readonly IEncoder<Itest_AndTypeObject> _itest_AndType = encoders.EncoderFor<Itest_AndTypeObject>();
  private readonly IEncoder<Itest_Directive> _itest_Directive = encoders.EncoderFor<Itest_Directive>();
  public Structured Encode(Itest_DirectivesObject input)
    => _itest_AndType.Encode(input)
      .AddEncoded("directive", input.Directive, _itest_Directive);
}

internal class test_DirectiveEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DirectiveObject>
{
  private readonly IEncoder<Itest_AliasedObject> _itest_Aliased = encoders.EncoderFor<Itest_AliasedObject>();
  private readonly IEncoder<Itest_InputFieldType> _itest_InputFieldType = encoders.EncoderFor<Itest_InputFieldType>();
  public Structured Encode(Itest_DirectiveObject input)
    => _itest_Aliased.Encode(input)
      .AddEncoded("parameter", input.Parameter, _itest_InputFieldType)
      .Add("repeatable", input.Repeatable);
}

internal class test_LocationEncoder : IEncoder<test_Location>
{
  public Structured Encode(test_Location input)
    => new(input.ToString(), "_Location");
}

internal class test_OperationsEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OperationsObject>
{
  private readonly IEncoder<Itest_Operation> _itest_Operation = encoders.EncoderFor<Itest_Operation>();
  private readonly IEncoder<Itest_Type> _itest_Type = encoders.EncoderFor<Itest_Type>();
  public Structured Encode(Itest_OperationsObject input)
    => Structured.Empty()
      .AddEncoded("operation", input.Operation, _itest_Operation)
      .AddEncoded("type", input.Type, _itest_Type);
}

internal class test_OpDirectivesEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpDirectivesObject>
{
  private readonly IEncoder<Itest_NamedObject> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  private readonly IEncoder<Itest_OpDirective> _itest_OpDirective = encoders.EncoderFor<Itest_OpDirective>();
  public Structured Encode(Itest_OpDirectivesObject input)
    => _itest_Named.Encode(input)
      .AddList("directives", input.Directives, _itest_OpDirective);
}

internal class test_OperationEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OperationObject>
{
  private readonly IEncoder<Itest_AliasedObject> _itest_Aliased = encoders.EncoderFor<Itest_AliasedObject>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  private readonly IEncoder<Itest_OpDirective> _itest_OpDirective = encoders.EncoderFor<Itest_OpDirective>();
  private readonly IEncoder<Itest_OpResult> _itest_OpResult = encoders.EncoderFor<Itest_OpResult>();
  public Structured Encode(Itest_OperationObject input)
    => _itest_Aliased.Encode(input)
      .AddEncoded("category", input.Category, _itest_Name)
      .AddList("directives", input.Directives, _itest_OpDirective)
      .AddEncoded("result", input.Result, _itest_OpResult);
}

internal class test_OpVariableEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpVariableObject>
{
  private readonly IEncoder<Itest_OpDirectivesObject> _itest_OpDirectives = encoders.EncoderFor<Itest_OpDirectivesObject>();
  private readonly IEncoder<Itest_TypeRef<test_TypeKind>> _itest_TypeRef = encoders.EncoderFor<Itest_TypeRef<test_TypeKind>>();
  private readonly IEncoder<Itest_Modifiers> _itest_Modifiers = encoders.EncoderFor<Itest_Modifiers>();
  private readonly IEncoder<GqlpValue> _gqlpValue = encoders.EncoderFor<GqlpValue>();
  public Structured Encode(Itest_OpVariableObject input)
    => _itest_OpDirectives.Encode(input)
      .AddEncoded("type", input.Type, _itest_TypeRef)
      .AddList("modifiers", input.Modifiers, _itest_Modifiers)
      .AddEncoded("defaultValue", input.DefaultValue, _gqlpValue);
}

internal class test_OpDirectiveEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpDirectiveObject>
{
  private readonly IEncoder<Itest_NamedObject> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  private readonly IEncoder<Itest_OpArgument> _itest_OpArgument = encoders.EncoderFor<Itest_OpArgument>();
  public Structured Encode(Itest_OpDirectiveObject input)
    => _itest_Named.Encode(input)
      .AddEncoded("argument", input.Argument, _itest_OpArgument);
}

internal class test_OpFragmentEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpFragmentObject>
{
  private readonly IEncoder<Itest_OpDirectivesObject> _itest_OpDirectives = encoders.EncoderFor<Itest_OpDirectivesObject>();
  private readonly IEncoder<Itest_TypeRef<test_TypeKind>> _itest_TypeRef = encoders.EncoderFor<Itest_TypeRef<test_TypeKind>>();
  public Structured Encode(Itest_OpFragmentObject input)
    => _itest_OpDirectives.Encode(input)
      .AddEncoded("type", input.Type, _itest_TypeRef);
}

internal class test_OpArgumentEncoder : IEncoder<Itest_OpArgumentObject>
{
  public Structured Encode(Itest_OpArgumentObject input)
    => Structured.Empty();
}

internal class test_OpArgValueEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpArgValueObject>
{
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_OpArgValueObject input)
    => Structured.Empty()
      .AddEncoded("variable", input.Variable, _itest_Name);
}

internal class test_OpArgListEncoder : IEncoder<Itest_OpArgListObject>
{
  public Structured Encode(Itest_OpArgListObject input)
    => Structured.Empty();
}

internal class test_OpArgMapEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpArgMapObject>
{
  private readonly IEncoder<Itest_OpArgValue> _itest_OpArgValue = encoders.EncoderFor<Itest_OpArgValue>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_OpArgMapObject input)
    => Structured.Empty()
      .AddEncoded("value", input.Value, _itest_OpArgValue)
      .AddEncoded("byVariable", input.ByVariable, _itest_Name);
}

internal class test_OpResultEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpResultObject>
{
  private readonly IEncoder<Itest_OpArgument> _itest_OpArgument = encoders.EncoderFor<Itest_OpArgument>();
  public Structured Encode(Itest_OpResultObject input)
    => Structured.Empty()
      .AddEncoded("argument", input.Argument, _itest_OpArgument);
}

internal class test_PathEncoder : IEncoder<Itest_Path>
{
  public Structured Encode(Itest_Path input)
    => new(input.Value);
}

internal class test_OpSelectionEncoder : IEncoder<Itest_OpSelectionObject>
{
  public Structured Encode(Itest_OpSelectionObject input)
    => Structured.Empty();
}

internal class test_OpFieldEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpFieldObject>
{
  private readonly IEncoder<Itest_OpDirectivesObject> _itest_OpDirectives = encoders.EncoderFor<Itest_OpDirectivesObject>();
  private readonly IEncoder<Itest_OpArgument> _itest_OpArgument = encoders.EncoderFor<Itest_OpArgument>();
  private readonly IEncoder<Itest_Modifiers> _itest_Modifiers = encoders.EncoderFor<Itest_Modifiers>();
  public Structured Encode(Itest_OpFieldObject input)
    => _itest_OpDirectives.Encode(input)
      .Add("fieldAlias", input.FieldAlias)
      .AddEncoded("argument", input.Argument, _itest_OpArgument)
      .AddList("modifiers", input.Modifiers, _itest_Modifiers);
}

internal class test_OpInlineEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpInlineObject>
{
  private readonly IEncoder<Itest_TypeRef<test_TypeKind>> _itest_TypeRef = encoders.EncoderFor<Itest_TypeRef<test_TypeKind>>();
  private readonly IEncoder<Itest_OpDirective> _itest_OpDirective = encoders.EncoderFor<Itest_OpDirective>();
  public Structured Encode(Itest_OpInlineObject input)
    => Structured.Empty()
      .AddEncoded("type", input.Type, _itest_TypeRef)
      .AddList("directives", input.Directives, _itest_OpDirective);
}

internal class test_OpSpreadEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpSpreadObject>
{
  private readonly IEncoder<Itest_OpDirective> _itest_OpDirective = encoders.EncoderFor<Itest_OpDirective>();
  public Structured Encode(Itest_OpSpreadObject input)
    => Structured.Empty()
      .Add("fragment", input.Fragment)
      .AddList("directives", input.Directives, _itest_OpDirective);
}

internal class test_SettingEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_SettingObject>
{
  private readonly IEncoder<Itest_NamedObject> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  private readonly IEncoder<GqlpValue> _gqlpValue = encoders.EncoderFor<GqlpValue>();
  public Structured Encode(Itest_SettingObject input)
    => _itest_Named.Encode(input)
      .AddEncoded("value", input.Value, _gqlpValue);
}

internal class test_TypeEncoder : IEncoder<Itest_TypeObject>
{
  public Structured Encode(Itest_TypeObject input)
    => Structured.Empty();
}

internal class test_BaseTypeEncoder<TTypeKind>(
  IEncoderRepository encoders
) : IEncoder<Itest_BaseTypeObject<TTypeKind>>
{
  private readonly IEncoder<Itest_AliasedObject> _itest_Aliased = encoders.EncoderFor<Itest_AliasedObject>();
  private readonly IEncoder<TTypeKind> _typeKind = encoders.EncoderFor<TTypeKind>();
  public Structured Encode(Itest_BaseTypeObject<TTypeKind> input)
    => _itest_Aliased.Encode(input)
      .AddEncoded("typeKind", input.TypeKind, _typeKind);
}

internal class test_ChildTypeEncoder<TTypeKind,TParent>(
  IEncoderRepository encoders
) : IEncoder<Itest_ChildTypeObject<TTypeKind,TParent>>
{
  private readonly IEncoder<Itest_BaseTypeObject<TTypeKind>> _itest_BaseType = encoders.EncoderFor<Itest_BaseTypeObject<TTypeKind>>();
  private readonly IEncoder<TParent> _parent = encoders.EncoderFor<TParent>();
  public Structured Encode(Itest_ChildTypeObject<TTypeKind,TParent> input)
    => _itest_BaseType.Encode(input)
      .AddEncoded("parent", input.Parent, _parent);
}

internal class test_ParentTypeEncoder<TTypeKind,TItem,TAllItem>(
  IEncoderRepository encoders
) : IEncoder<Itest_ParentTypeObject<TTypeKind,TItem,TAllItem>>
{
  private readonly IEncoder<Itest_ChildTypeObject<TTypeKind, Itest_Named>> _itest_ChildType = encoders.EncoderFor<Itest_ChildTypeObject<TTypeKind, Itest_Named>>();
  private readonly IEncoder<TItem> _item = encoders.EncoderFor<TItem>();
  private readonly IEncoder<TAllItem> _allItem = encoders.EncoderFor<TAllItem>();
  public Structured Encode(Itest_ParentTypeObject<TTypeKind,TItem,TAllItem> input)
    => _itest_ChildType.Encode(input)
      .AddList("items", input.Items, _item)
      .AddList("allItems", input.AllItems, _allItem);
}

internal class test_SimpleKindEncoder : IEncoder<test_SimpleKind>
{
  public Structured Encode(test_SimpleKind input)
    => new(input.ToString(), "_SimpleKind");
}

internal class test_TypeKindEncoder : IEncoder<test_TypeKind>
{
  public Structured Encode(test_TypeKind input)
    => new(input.ToString(), "_TypeKind");
}

internal class test_TypeRefEncoder<TTypeKind>(
  IEncoderRepository encoders
) : IEncoder<Itest_TypeRefObject<TTypeKind>>
{
  private readonly IEncoder<Itest_NamedObject> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  private readonly IEncoder<TTypeKind> _typeKind = encoders.EncoderFor<TTypeKind>();
  public Structured Encode(Itest_TypeRefObject<TTypeKind> input)
    => _itest_Named.Encode(input)
      .AddEncoded("typeKind", input.TypeKind, _typeKind);
}

internal class test_TypeSimpleEncoder : IEncoder<Itest_TypeSimpleObject>
{
  public Structured Encode(Itest_TypeSimpleObject input)
    => Structured.Empty();
}

internal class test_CollectionsEncoder : IEncoder<Itest_CollectionsObject>
{
  public Structured Encode(Itest_CollectionsObject input)
    => Structured.Empty();
}

internal class test_ModifierKeyedEncoder<TModifierKind>(
  IEncoderRepository encoders
) : IEncoder<Itest_ModifierKeyedObject<TModifierKind>>
{
  private readonly IEncoder<Itest_ModifierObject<TModifierKind>> _itest_Modifier = encoders.EncoderFor<Itest_ModifierObject<TModifierKind>>();
  private readonly IEncoder<Itest_TypeSimple> _itest_TypeSimple = encoders.EncoderFor<Itest_TypeSimple>();
  public Structured Encode(Itest_ModifierKeyedObject<TModifierKind> input)
    => _itest_Modifier.Encode(input)
      .AddEncoded("by", input.By, _itest_TypeSimple)
      .Add("isOptional", input.IsOptional);
}

internal class test_ModifiersEncoder : IEncoder<Itest_ModifiersObject>
{
  public Structured Encode(Itest_ModifiersObject input)
    => Structured.Empty();
}

internal class test_ModifierKindEncoder : IEncoder<test_ModifierKind>
{
  public Structured Encode(test_ModifierKind input)
    => new(input.ToString(), "_ModifierKind");
}

internal class test_ModifierEncoder<TModifierKind>(
  IEncoderRepository encoders
) : IEncoder<Itest_ModifierObject<TModifierKind>>
{
  private readonly IEncoder<TModifierKind> _modifierKind = encoders.EncoderFor<TModifierKind>();
  public Structured Encode(Itest_ModifierObject<TModifierKind> input)
    => Structured.Empty()
      .AddEncoded("modifierKind", input.ModifierKind, _modifierKind);
}

internal class test_DomainKindEncoder : IEncoder<test_DomainKind>
{
  public Structured Encode(test_DomainKind input)
    => new(input.ToString(), "_DomainKind");
}

internal class test_DomainRefEncoder<TDomainKind>(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainRefObject<TDomainKind>>
{
  private readonly IEncoder<Itest_TypeRefObject<test_TypeKind>> _itest_TypeRef = encoders.EncoderFor<Itest_TypeRefObject<test_TypeKind>>();
  private readonly IEncoder<TDomainKind> _domainKind = encoders.EncoderFor<TDomainKind>();
  public Structured Encode(Itest_DomainRefObject<TDomainKind> input)
    => _itest_TypeRef.Encode(input)
      .AddEncoded("domainKind", input.DomainKind, _domainKind);
}

internal class test_BaseDomainEncoder<TDomainKind,TItem,TDomainItem>(
  IEncoderRepository encoders
) : IEncoder<Itest_BaseDomainObject<TDomainKind,TItem,TDomainItem>>
{
  private readonly IEncoder<Itest_ParentTypeObject<test_TypeKind, TItem, TDomainItem>> _itest_ParentType = encoders.EncoderFor<Itest_ParentTypeObject<test_TypeKind, TItem, TDomainItem>>();
  private readonly IEncoder<TDomainKind> _domainKind = encoders.EncoderFor<TDomainKind>();
  public Structured Encode(Itest_BaseDomainObject<TDomainKind,TItem,TDomainItem> input)
    => _itest_ParentType.Encode(input)
      .AddEncoded("domainKind", input.DomainKind, _domainKind);
}

internal class test_BaseDomainItemEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_BaseDomainItemObject>
{
  private readonly IEncoder<Itest_DescribedObject> _itest_Described = encoders.EncoderFor<Itest_DescribedObject>();
  public Structured Encode(Itest_BaseDomainItemObject input)
    => _itest_Described.Encode(input)
      .Add("exclude", input.Exclude);
}

internal class test_DomainItemEncoder<TItem>(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainItemObject<TItem>>
{
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_DomainItemObject<TItem> input)
    => Structured.Empty()
      .AddEncoded("domain", input.Domain, _itest_Name);
}

internal class test_DomainValueEncoder<TDomainKind,TValue>(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainValueObject<TDomainKind,TValue>>
{
  private readonly IEncoder<Itest_DomainRefObject<TDomainKind>> _itest_DomainRef = encoders.EncoderFor<Itest_DomainRefObject<TDomainKind>>();
  private readonly IEncoder<TValue> _value = encoders.EncoderFor<TValue>();
  public Structured Encode(Itest_DomainValueObject<TDomainKind,TValue> input)
    => _itest_DomainRef.Encode(input)
      .AddEncoded("value", input.Value, _value);
}

internal class test_BasicValueEncoder : IEncoder<Itest_BasicValueObject>
{
  public Structured Encode(Itest_BasicValueObject input)
    => Structured.Empty();
}

internal class test_DomainTrueFalseEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainTrueFalseObject>
{
  private readonly IEncoder<Itest_BaseDomainItemObject> _itest_BaseDomainItem = encoders.EncoderFor<Itest_BaseDomainItemObject>();
  public Structured Encode(Itest_DomainTrueFalseObject input)
    => _itest_BaseDomainItem.Encode(input)
      .Add("value", input.Value);
}

internal class test_DomainItemTrueFalseEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainItemTrueFalseObject>
{
  private readonly IEncoder<Itest_DomainItemObject<Itest_DomainTrueFalse>> _itest_DomainItem = encoders.EncoderFor<Itest_DomainItemObject<Itest_DomainTrueFalse>>();
  public Structured Encode(Itest_DomainItemTrueFalseObject input)
    => _itest_DomainItem.Encode(input);
}

internal class test_DomainLabelEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainLabelObject>
{
  private readonly IEncoder<Itest_BaseDomainItemObject> _itest_BaseDomainItem = encoders.EncoderFor<Itest_BaseDomainItemObject>();
  private readonly IEncoder<Itest_EnumValue> _itest_EnumValue = encoders.EncoderFor<Itest_EnumValue>();
  public Structured Encode(Itest_DomainLabelObject input)
    => _itest_BaseDomainItem.Encode(input)
      .AddEncoded("label", input.Label, _itest_EnumValue);
}

internal class test_DomainItemLabelEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainItemLabelObject>
{
  private readonly IEncoder<Itest_DomainItemObject<Itest_DomainLabel>> _itest_DomainItem = encoders.EncoderFor<Itest_DomainItemObject<Itest_DomainLabel>>();
  public Structured Encode(Itest_DomainItemLabelObject input)
    => _itest_DomainItem.Encode(input);
}

internal class test_DomainRangeEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainRangeObject>
{
  private readonly IEncoder<Itest_BaseDomainItemObject> _itest_BaseDomainItem = encoders.EncoderFor<Itest_BaseDomainItemObject>();
  public Structured Encode(Itest_DomainRangeObject input)
    => _itest_BaseDomainItem.Encode(input)
      .Add("lower", input.Lower)
      .Add("upper", input.Upper);
}

internal class test_DomainItemRangeEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainItemRangeObject>
{
  private readonly IEncoder<Itest_DomainItemObject<Itest_DomainRange>> _itest_DomainItem = encoders.EncoderFor<Itest_DomainItemObject<Itest_DomainRange>>();
  public Structured Encode(Itest_DomainItemRangeObject input)
    => _itest_DomainItem.Encode(input);
}

internal class test_DomainRegexEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainRegexObject>
{
  private readonly IEncoder<Itest_BaseDomainItemObject> _itest_BaseDomainItem = encoders.EncoderFor<Itest_BaseDomainItemObject>();
  public Structured Encode(Itest_DomainRegexObject input)
    => _itest_BaseDomainItem.Encode(input)
      .Add("pattern", input.Pattern);
}

internal class test_DomainItemRegexEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainItemRegexObject>
{
  private readonly IEncoder<Itest_DomainItemObject<Itest_DomainRegex>> _itest_DomainItem = encoders.EncoderFor<Itest_DomainItemObject<Itest_DomainRegex>>();
  public Structured Encode(Itest_DomainItemRegexObject input)
    => _itest_DomainItem.Encode(input);
}

internal class test_EnumLabelEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_EnumLabelObject>
{
  private readonly IEncoder<Itest_AliasedObject> _itest_Aliased = encoders.EncoderFor<Itest_AliasedObject>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_EnumLabelObject input)
    => _itest_Aliased.Encode(input)
      .AddEncoded("enumType", input.EnumType, _itest_Name);
}

internal class test_EnumValueEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_EnumValueObject>
{
  private readonly IEncoder<Itest_TypeRefObject<test_TypeKind>> _itest_TypeRef = encoders.EncoderFor<Itest_TypeRefObject<test_TypeKind>>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_EnumValueObject input)
    => _itest_TypeRef.Encode(input)
      .AddEncoded("label", input.Label, _itest_Name);
}

internal class test_UnionRefEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_UnionRefObject>
{
  private readonly IEncoder<Itest_TypeRefObject<test_SimpleKind>> _itest_TypeRef = encoders.EncoderFor<Itest_TypeRefObject<test_SimpleKind>>();
  public Structured Encode(Itest_UnionRefObject input)
    => _itest_TypeRef.Encode(input);
}

internal class test_UnionMemberEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_UnionMemberObject>
{
  private readonly IEncoder<Itest_UnionRefObject> _itest_UnionRef = encoders.EncoderFor<Itest_UnionRefObject>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_UnionMemberObject input)
    => _itest_UnionRef.Encode(input)
      .AddEncoded("union", input.Union, _itest_Name);
}

internal class test_ObjectKindEncoder : IEncoder<Itest_ObjectKind>
{
  public Structured Encode(Itest_ObjectKind input)
    => new((decimal?)input.Value);
}

internal class test_TypeObjectEncoder<TObjectKind,TField>(
  IEncoderRepository encoders
) : IEncoder<Itest_TypeObjectObject<TObjectKind,TField>>
{
  private readonly IEncoder<Itest_ChildTypeObject<TObjectKind, Itest_ObjBase>> _itest_ChildType = encoders.EncoderFor<Itest_ChildTypeObject<TObjectKind, Itest_ObjBase>>();
  private readonly IEncoder<Itest_ObjTypeParam> _itest_ObjTypeParam = encoders.EncoderFor<Itest_ObjTypeParam>();
  private readonly IEncoder<TField> _field = encoders.EncoderFor<TField>();
  private readonly IEncoder<Itest_ObjAlternate> _itest_ObjAlternate = encoders.EncoderFor<Itest_ObjAlternate>();
  private readonly IEncoder<Itest_ObjectFor<TField>> _itest_ObjectFor = encoders.EncoderFor<Itest_ObjectFor<TField>>();
  private readonly IEncoder<Itest_ObjectFor<Itest_ObjAlternate>> _itest_ObjectFor2 = encoders.EncoderFor<Itest_ObjectFor<Itest_ObjAlternate>>();
  public Structured Encode(Itest_TypeObjectObject<TObjectKind,TField> input)
    => _itest_ChildType.Encode(input)
      .AddList("typeParams", input.TypeParams, _itest_ObjTypeParam)
      .AddList("fields", input.Fields, _field)
      .AddList("alternates", input.Alternates, _itest_ObjAlternate)
      .AddList("allFields", input.AllFields, _itest_ObjectFor)
      .AddList("allAlternates", input.AllAlternates, _itest_ObjectFor2);
}

internal class test_ObjTypeParamEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_ObjTypeParamObject>
{
  private readonly IEncoder<Itest_NamedObject> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  private readonly IEncoder<Itest_TypeRef<test_TypeKind>> _itest_TypeRef = encoders.EncoderFor<Itest_TypeRef<test_TypeKind>>();
  public Structured Encode(Itest_ObjTypeParamObject input)
    => _itest_Named.Encode(input)
      .AddEncoded("constraint", input.Constraint, _itest_TypeRef);
}

internal class test_ObjBaseEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_ObjBaseObject>
{
  private readonly IEncoder<Itest_NamedObject> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  private readonly IEncoder<Itest_ObjTypeArg> _itest_ObjTypeArg = encoders.EncoderFor<Itest_ObjTypeArg>();
  public Structured Encode(Itest_ObjBaseObject input)
    => _itest_Named.Encode(input)
      .AddList("typeArgs", input.TypeArgs, _itest_ObjTypeArg);
}

internal class test_ObjTypeArgEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_ObjTypeArgObject>
{
  private readonly IEncoder<Itest_TypeRefObject<test_TypeKind>> _itest_TypeRef = encoders.EncoderFor<Itest_TypeRefObject<test_TypeKind>>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_ObjTypeArgObject input)
    => _itest_TypeRef.Encode(input)
      .AddEncoded("label", input.Label, _itest_Name);
}

internal class test_TypeParamEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_TypeParamObject>
{
  private readonly IEncoder<Itest_DescribedObject> _itest_Described = encoders.EncoderFor<Itest_DescribedObject>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_TypeParamObject input)
    => _itest_Described.Encode(input)
      .AddEncoded("typeParam", input.TypeParam, _itest_Name);
}

internal class test_ObjAlternateEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_ObjAlternateObject>
{
  private readonly IEncoder<Itest_ObjBase> _itest_ObjBase = encoders.EncoderFor<Itest_ObjBase>();
  private readonly IEncoder<Itest_Collections> _itest_Collections = encoders.EncoderFor<Itest_Collections>();
  public Structured Encode(Itest_ObjAlternateObject input)
    => Structured.Empty()
      .AddEncoded("type", input.Type, _itest_ObjBase)
      .AddList("collections", input.Collections, _itest_Collections);
}

internal class test_ObjAlternateEnumEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_ObjAlternateEnumObject>
{
  private readonly IEncoder<Itest_TypeRefObject<test_TypeKind>> _itest_TypeRef = encoders.EncoderFor<Itest_TypeRefObject<test_TypeKind>>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_ObjAlternateEnumObject input)
    => _itest_TypeRef.Encode(input)
      .AddEncoded("label", input.Label, _itest_Name);
}

internal class test_ObjectForEncoder<TFor>(
  IEncoderRepository encoders
) : IEncoder<Itest_ObjectForObject<TFor>>
{
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_ObjectForObject<TFor> input)
    => Structured.Empty()
      .AddEncoded("objectType", input.ObjectType, _itest_Name);
}

internal class test_ObjFieldEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<Itest_ObjFieldObject<TType>>
{
  private readonly IEncoder<Itest_AliasedObject> _itest_Aliased = encoders.EncoderFor<Itest_AliasedObject>();
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(Itest_ObjFieldObject<TType> input)
    => _itest_Aliased.Encode(input)
      .AddEncoded("type", input.Type, _type);
}

internal class test_ObjFieldTypeEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_ObjFieldTypeObject>
{
  private readonly IEncoder<Itest_ObjBaseObject> _itest_ObjBase = encoders.EncoderFor<Itest_ObjBaseObject>();
  private readonly IEncoder<Itest_Modifiers> _itest_Modifiers = encoders.EncoderFor<Itest_Modifiers>();
  public Structured Encode(Itest_ObjFieldTypeObject input)
    => _itest_ObjBase.Encode(input)
      .AddList("modifiers", input.Modifiers, _itest_Modifiers);
}

internal class test_ObjFieldEnumEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_ObjFieldEnumObject>
{
  private readonly IEncoder<Itest_TypeRefObject<test_TypeKind>> _itest_TypeRef = encoders.EncoderFor<Itest_TypeRefObject<test_TypeKind>>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_ObjFieldEnumObject input)
    => _itest_TypeRef.Encode(input)
      .AddEncoded("label", input.Label, _itest_Name);
}

internal class test_ForParamEncoder<TType> : IEncoder<Itest_ForParamObject<TType>>
{
  public Structured Encode(Itest_ForParamObject<TType> input)
    => Structured.Empty();
}

internal class test_DualFieldEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DualFieldObject>
{
  private readonly IEncoder<Itest_ObjFieldObject<Itest_ObjFieldType>> _itest_ObjField = encoders.EncoderFor<Itest_ObjFieldObject<Itest_ObjFieldType>>();
  public Structured Encode(Itest_DualFieldObject input)
    => _itest_ObjField.Encode(input);
}

internal class test_InputFieldEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_InputFieldObject>
{
  private readonly IEncoder<Itest_ObjFieldObject<Itest_InputFieldType>> _itest_ObjField = encoders.EncoderFor<Itest_ObjFieldObject<Itest_InputFieldType>>();
  public Structured Encode(Itest_InputFieldObject input)
    => _itest_ObjField.Encode(input);
}

internal class test_InputFieldTypeEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_InputFieldTypeObject>
{
  private readonly IEncoder<Itest_ObjFieldTypeObject> _itest_ObjFieldType = encoders.EncoderFor<Itest_ObjFieldTypeObject>();
  private readonly IEncoder<GqlpValue> _gqlpValue = encoders.EncoderFor<GqlpValue>();
  public Structured Encode(Itest_InputFieldTypeObject input)
    => _itest_ObjFieldType.Encode(input)
      .AddEncoded("defaultValue", input.DefaultValue, _gqlpValue);
}

internal class test_OutputFieldEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OutputFieldObject>
{
  private readonly IEncoder<Itest_ObjFieldObject<Itest_ObjFieldType>> _itest_ObjField = encoders.EncoderFor<Itest_ObjFieldObject<Itest_ObjFieldType>>();
  public Structured Encode(Itest_OutputFieldObject input)
    => _itest_ObjField.Encode(input);
}

internal class test_OutputFieldTypeEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OutputFieldTypeObject>
{
  private readonly IEncoder<Itest_ObjFieldTypeObject> _itest_ObjFieldType = encoders.EncoderFor<Itest_ObjFieldTypeObject>();
  private readonly IEncoder<Itest_InputFieldType> _itest_InputFieldType = encoders.EncoderFor<Itest_InputFieldType>();
  public Structured Encode(Itest_OutputFieldTypeObject input)
    => _itest_ObjFieldType.Encode(input)
      .AddEncoded("parameter", input.Parameter, _itest_InputFieldType);
}

internal static class test_IntrospectionEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_IntrospectionEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_SchemaObject>(r => new test_SchemaEncoder(r))
      .AddEncoder<Itest_Name>(_ => new test_NameEncoder())
      .AddEncoder<Itest_NameFilter>(_ => new test_NameFilterEncoder())
      .AddEncoder<Itest_AliasedObject>(r => new test_AliasedEncoder(r))
      .AddEncoder<Itest_NamedObject>(r => new test_NamedEncoder(r))
      .AddEncoder<Itest_DescribedObject>(_ => new test_DescribedEncoder())
      .AddEncoder<Itest_AndTypeObject>(r => new test_AndTypeEncoder(r))
      .AddEncoder<Itest_CategoriesObject>(r => new test_CategoriesEncoder(r))
      .AddEncoder<Itest_CategoryObject>(r => new test_CategoryEncoder(r))
      .AddEncoder<test_Resolution>(_ => new test_ResolutionEncoder())
      .AddEncoder<Itest_DirectivesObject>(r => new test_DirectivesEncoder(r))
      .AddEncoder<Itest_DirectiveObject>(r => new test_DirectiveEncoder(r))
      .AddEncoder<test_Location>(_ => new test_LocationEncoder())
      .AddEncoder<Itest_OperationsObject>(r => new test_OperationsEncoder(r))
      .AddEncoder<Itest_OpDirectivesObject>(r => new test_OpDirectivesEncoder(r))
      .AddEncoder<Itest_OperationObject>(r => new test_OperationEncoder(r))
      .AddEncoder<Itest_OpVariableObject>(r => new test_OpVariableEncoder(r))
      .AddEncoder<Itest_OpDirectiveObject>(r => new test_OpDirectiveEncoder(r))
      .AddEncoder<Itest_OpFragmentObject>(r => new test_OpFragmentEncoder(r))
      .AddEncoder<Itest_OpArgumentObject>(_ => new test_OpArgumentEncoder())
      .AddEncoder<Itest_OpArgValueObject>(r => new test_OpArgValueEncoder(r))
      .AddEncoder<Itest_OpArgListObject>(_ => new test_OpArgListEncoder())
      .AddEncoder<Itest_OpArgMapObject>(r => new test_OpArgMapEncoder(r))
      .AddEncoder<Itest_OpResultObject>(r => new test_OpResultEncoder(r))
      .AddEncoder<Itest_Path>(_ => new test_PathEncoder())
      .AddEncoder<Itest_OpSelectionObject>(_ => new test_OpSelectionEncoder())
      .AddEncoder<Itest_OpFieldObject>(r => new test_OpFieldEncoder(r))
      .AddEncoder<Itest_OpInlineObject>(r => new test_OpInlineEncoder(r))
      .AddEncoder<Itest_OpSpreadObject>(r => new test_OpSpreadEncoder(r))
      .AddEncoder<Itest_SettingObject>(r => new test_SettingEncoder(r))
      .AddEncoder<Itest_TypeObject>(_ => new test_TypeEncoder())
      .AddEncoder<test_SimpleKind>(_ => new test_SimpleKindEncoder())
      .AddEncoder<test_TypeKind>(_ => new test_TypeKindEncoder())
      .AddEncoder<Itest_TypeSimpleObject>(_ => new test_TypeSimpleEncoder())
      .AddEncoder<Itest_CollectionsObject>(_ => new test_CollectionsEncoder())
      .AddEncoder<Itest_ModifiersObject>(_ => new test_ModifiersEncoder())
      .AddEncoder<test_ModifierKind>(_ => new test_ModifierKindEncoder())
      .AddEncoder<test_DomainKind>(_ => new test_DomainKindEncoder())
      .AddEncoder<Itest_BaseDomainItemObject>(r => new test_BaseDomainItemEncoder(r))
      .AddEncoder<Itest_BasicValueObject>(_ => new test_BasicValueEncoder())
      .AddEncoder<Itest_DomainTrueFalseObject>(r => new test_DomainTrueFalseEncoder(r))
      .AddEncoder<Itest_DomainItemTrueFalseObject>(r => new test_DomainItemTrueFalseEncoder(r))
      .AddEncoder<Itest_DomainLabelObject>(r => new test_DomainLabelEncoder(r))
      .AddEncoder<Itest_DomainItemLabelObject>(r => new test_DomainItemLabelEncoder(r))
      .AddEncoder<Itest_DomainRangeObject>(r => new test_DomainRangeEncoder(r))
      .AddEncoder<Itest_DomainItemRangeObject>(r => new test_DomainItemRangeEncoder(r))
      .AddEncoder<Itest_DomainRegexObject>(r => new test_DomainRegexEncoder(r))
      .AddEncoder<Itest_DomainItemRegexObject>(r => new test_DomainItemRegexEncoder(r))
      .AddEncoder<Itest_EnumLabelObject>(r => new test_EnumLabelEncoder(r))
      .AddEncoder<Itest_EnumValueObject>(r => new test_EnumValueEncoder(r))
      .AddEncoder<Itest_UnionRefObject>(r => new test_UnionRefEncoder(r))
      .AddEncoder<Itest_UnionMemberObject>(r => new test_UnionMemberEncoder(r))
      .AddEncoder<Itest_ObjectKind>(_ => new test_ObjectKindEncoder())
      .AddEncoder<Itest_ObjTypeParamObject>(r => new test_ObjTypeParamEncoder(r))
      .AddEncoder<Itest_ObjBaseObject>(r => new test_ObjBaseEncoder(r))
      .AddEncoder<Itest_ObjTypeArgObject>(r => new test_ObjTypeArgEncoder(r))
      .AddEncoder<Itest_TypeParamObject>(r => new test_TypeParamEncoder(r))
      .AddEncoder<Itest_ObjAlternateObject>(r => new test_ObjAlternateEncoder(r))
      .AddEncoder<Itest_ObjAlternateEnumObject>(r => new test_ObjAlternateEnumEncoder(r))
      .AddEncoder<Itest_ObjFieldTypeObject>(r => new test_ObjFieldTypeEncoder(r))
      .AddEncoder<Itest_ObjFieldEnumObject>(r => new test_ObjFieldEnumEncoder(r))
      .AddEncoder<Itest_DualFieldObject>(r => new test_DualFieldEncoder(r))
      .AddEncoder<Itest_InputFieldObject>(r => new test_InputFieldEncoder(r))
      .AddEncoder<Itest_InputFieldTypeObject>(r => new test_InputFieldTypeEncoder(r))
      .AddEncoder<Itest_OutputFieldObject>(r => new test_OutputFieldEncoder(r))
      .AddEncoder<Itest_OutputFieldTypeObject>(r => new test_OutputFieldTypeEncoder(r));
}
