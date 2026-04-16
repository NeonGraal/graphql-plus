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

  internal static test_SchemaEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_NameEncoder : IEncoder<Itest_Name>
{
  public Structured Encode(Itest_Name input)
    => new(input.Value);

  internal static test_NameEncoder Factory(IEncoderRepository _) => new();
}

internal class test_NameFilterEncoder : IEncoder<Itest_NameFilter>
{
  public Structured Encode(Itest_NameFilter input)
    => new(input.Value);

  internal static test_NameFilterEncoder Factory(IEncoderRepository _) => new();
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

  internal static test_AliasedEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_NamedEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_DescribedEncoder : IEncoder<Itest_DescribedObject>
{
  public Structured Encode(Itest_DescribedObject input)
    => Structured.Empty()
      .Add("description", input.Description.Encode());

  internal static test_DescribedEncoder Factory(IEncoderRepository _) => new();
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

  internal static test_AndTypeEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_CategoriesEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_CategoryEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_ResolutionEncoder : IEncoder<test_Resolution>
{
  public Structured Encode(test_Resolution input)
    => new(input.ToString(), "_Resolution");

  internal static test_ResolutionEncoder Factory(IEncoderRepository _) => new();
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

  internal static test_DirectivesEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_DirectiveEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_LocationEncoder : IEncoder<test_Location>
{
  public Structured Encode(test_Location input)
    => new(input.ToString(), "_Location");

  internal static test_LocationEncoder Factory(IEncoderRepository _) => new();
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

  internal static test_OperationsEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_OpDirectivesEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_OperationEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_OpVariableEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_OpDirectiveEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_OpFragmentEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_OpArgumentEncoder : IEncoder<Itest_OpArgumentObject>
{
  public Structured Encode(Itest_OpArgumentObject input)
    => Structured.Empty();

  internal static test_OpArgumentEncoder Factory(IEncoderRepository _) => new();
}

internal class test_OpArgValueEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpArgValueObject>
{
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_OpArgValueObject input)
    => Structured.Empty()
      .AddEncoded("variable", input.Variable, _itest_Name);

  internal static test_OpArgValueEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_OpArgListEncoder : IEncoder<Itest_OpArgListObject>
{
  public Structured Encode(Itest_OpArgListObject input)
    => Structured.Empty();

  internal static test_OpArgListEncoder Factory(IEncoderRepository _) => new();
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

  internal static test_OpArgMapEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_OpResultEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpResultObject>
{
  private readonly IEncoder<Itest_OpArgument> _itest_OpArgument = encoders.EncoderFor<Itest_OpArgument>();
  public Structured Encode(Itest_OpResultObject input)
    => Structured.Empty()
      .AddEncoded("argument", input.Argument, _itest_OpArgument);

  internal static test_OpResultEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_PathEncoder : IEncoder<Itest_Path>
{
  public Structured Encode(Itest_Path input)
    => new(input.Value);

  internal static test_PathEncoder Factory(IEncoderRepository _) => new();
}

internal class test_OpSelectionEncoder : IEncoder<Itest_OpSelectionObject>
{
  public Structured Encode(Itest_OpSelectionObject input)
    => Structured.Empty();

  internal static test_OpSelectionEncoder Factory(IEncoderRepository _) => new();
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

  internal static test_OpFieldEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_OpInlineEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_OpSpreadEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_SettingEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_TypeEncoder : IEncoder<Itest_TypeObject>
{
  public Structured Encode(Itest_TypeObject input)
    => Structured.Empty();

  internal static test_TypeEncoder Factory(IEncoderRepository _) => new();
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

  internal static test_SimpleKindEncoder Factory(IEncoderRepository _) => new();
}

internal class test_TypeKindEncoder : IEncoder<test_TypeKind>
{
  public Structured Encode(test_TypeKind input)
    => new(input.ToString(), "_TypeKind");

  internal static test_TypeKindEncoder Factory(IEncoderRepository _) => new();
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

  internal static test_TypeSimpleEncoder Factory(IEncoderRepository _) => new();
}

internal class test_CollectionsEncoder : IEncoder<Itest_CollectionsObject>
{
  public Structured Encode(Itest_CollectionsObject input)
    => Structured.Empty();

  internal static test_CollectionsEncoder Factory(IEncoderRepository _) => new();
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

  internal static test_ModifiersEncoder Factory(IEncoderRepository _) => new();
}

internal class test_ModifierKindEncoder : IEncoder<test_ModifierKind>
{
  public Structured Encode(test_ModifierKind input)
    => new(input.ToString(), "_ModifierKind");

  internal static test_ModifierKindEncoder Factory(IEncoderRepository _) => new();
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

  internal static test_DomainKindEncoder Factory(IEncoderRepository _) => new();
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

  internal static test_BaseDomainItemEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_BasicValueEncoder Factory(IEncoderRepository _) => new();
}

internal class test_DomainTrueFalseEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainTrueFalseObject>
{
  private readonly IEncoder<Itest_BaseDomainItemObject> _itest_BaseDomainItem = encoders.EncoderFor<Itest_BaseDomainItemObject>();
  public Structured Encode(Itest_DomainTrueFalseObject input)
    => _itest_BaseDomainItem.Encode(input)
      .Add("value", input.Value);

  internal static test_DomainTrueFalseEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_DomainItemTrueFalseEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainItemTrueFalseObject>
{
  private readonly IEncoder<Itest_DomainItemObject<Itest_DomainTrueFalse>> _itest_DomainItem = encoders.EncoderFor<Itest_DomainItemObject<Itest_DomainTrueFalse>>();
  public Structured Encode(Itest_DomainItemTrueFalseObject input)
    => _itest_DomainItem.Encode(input);

  internal static test_DomainItemTrueFalseEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_DomainLabelEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_DomainItemLabelEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainItemLabelObject>
{
  private readonly IEncoder<Itest_DomainItemObject<Itest_DomainLabel>> _itest_DomainItem = encoders.EncoderFor<Itest_DomainItemObject<Itest_DomainLabel>>();
  public Structured Encode(Itest_DomainItemLabelObject input)
    => _itest_DomainItem.Encode(input);

  internal static test_DomainItemLabelEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_DomainRangeEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_DomainItemRangeEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainItemRangeObject>
{
  private readonly IEncoder<Itest_DomainItemObject<Itest_DomainRange>> _itest_DomainItem = encoders.EncoderFor<Itest_DomainItemObject<Itest_DomainRange>>();
  public Structured Encode(Itest_DomainItemRangeObject input)
    => _itest_DomainItem.Encode(input);

  internal static test_DomainItemRangeEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_DomainRegexEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainRegexObject>
{
  private readonly IEncoder<Itest_BaseDomainItemObject> _itest_BaseDomainItem = encoders.EncoderFor<Itest_BaseDomainItemObject>();
  public Structured Encode(Itest_DomainRegexObject input)
    => _itest_BaseDomainItem.Encode(input)
      .Add("pattern", input.Pattern);

  internal static test_DomainRegexEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_DomainItemRegexEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainItemRegexObject>
{
  private readonly IEncoder<Itest_DomainItemObject<Itest_DomainRegex>> _itest_DomainItem = encoders.EncoderFor<Itest_DomainItemObject<Itest_DomainRegex>>();
  public Structured Encode(Itest_DomainItemRegexObject input)
    => _itest_DomainItem.Encode(input);

  internal static test_DomainItemRegexEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_EnumLabelEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_EnumValueEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_UnionRefEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_UnionRefObject>
{
  private readonly IEncoder<Itest_TypeRefObject<test_SimpleKind>> _itest_TypeRef = encoders.EncoderFor<Itest_TypeRefObject<test_SimpleKind>>();
  public Structured Encode(Itest_UnionRefObject input)
    => _itest_TypeRef.Encode(input);

  internal static test_UnionRefEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_UnionMemberEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_ObjectKindEncoder : IEncoder<Itest_ObjectKind>
{
  public Structured Encode(Itest_ObjectKind input)
    => new((decimal?)input.Value);

  internal static test_ObjectKindEncoder Factory(IEncoderRepository _) => new();
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

  internal static test_ObjTypeParamEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_ObjBaseEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_ObjTypeArgEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_TypeParamEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_ObjAlternateEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_ObjAlternateEnumEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_ObjFieldTypeEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_ObjFieldEnumEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_DualFieldEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_InputFieldEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_InputFieldObject>
{
  private readonly IEncoder<Itest_ObjFieldObject<Itest_InputFieldType>> _itest_ObjField = encoders.EncoderFor<Itest_ObjFieldObject<Itest_InputFieldType>>();
  public Structured Encode(Itest_InputFieldObject input)
    => _itest_ObjField.Encode(input);

  internal static test_InputFieldEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_InputFieldTypeEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_OutputFieldEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OutputFieldObject>
{
  private readonly IEncoder<Itest_ObjFieldObject<Itest_ObjFieldType>> _itest_ObjField = encoders.EncoderFor<Itest_ObjFieldObject<Itest_ObjFieldType>>();
  public Structured Encode(Itest_OutputFieldObject input)
    => _itest_ObjField.Encode(input);

  internal static test_OutputFieldEncoder Factory(IEncoderRepository r) => new(r);
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

  internal static test_OutputFieldTypeEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_IntrospectionEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_IntrospectionEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_SchemaObject>(test_SchemaEncoder.Factory)
      .AddEncoder<Itest_Name>(test_NameEncoder.Factory)
      .AddEncoder<Itest_NameFilter>(test_NameFilterEncoder.Factory)
      .AddEncoder<Itest_AliasedObject>(test_AliasedEncoder.Factory)
      .AddEncoder<Itest_NamedObject>(test_NamedEncoder.Factory)
      .AddEncoder<Itest_DescribedObject>(test_DescribedEncoder.Factory)
      .AddEncoder<Itest_AndTypeObject>(test_AndTypeEncoder.Factory)
      .AddEncoder<Itest_CategoriesObject>(test_CategoriesEncoder.Factory)
      .AddEncoder<Itest_CategoryObject>(test_CategoryEncoder.Factory)
      .AddEncoder<test_Resolution>(test_ResolutionEncoder.Factory)
      .AddEncoder<Itest_DirectivesObject>(test_DirectivesEncoder.Factory)
      .AddEncoder<Itest_DirectiveObject>(test_DirectiveEncoder.Factory)
      .AddEncoder<test_Location>(test_LocationEncoder.Factory)
      .AddEncoder<Itest_OperationsObject>(test_OperationsEncoder.Factory)
      .AddEncoder<Itest_OpDirectivesObject>(test_OpDirectivesEncoder.Factory)
      .AddEncoder<Itest_OperationObject>(test_OperationEncoder.Factory)
      .AddEncoder<Itest_OpVariableObject>(test_OpVariableEncoder.Factory)
      .AddEncoder<Itest_OpDirectiveObject>(test_OpDirectiveEncoder.Factory)
      .AddEncoder<Itest_OpFragmentObject>(test_OpFragmentEncoder.Factory)
      .AddEncoder<Itest_OpArgumentObject>(test_OpArgumentEncoder.Factory)
      .AddEncoder<Itest_OpArgValueObject>(test_OpArgValueEncoder.Factory)
      .AddEncoder<Itest_OpArgListObject>(test_OpArgListEncoder.Factory)
      .AddEncoder<Itest_OpArgMapObject>(test_OpArgMapEncoder.Factory)
      .AddEncoder<Itest_OpResultObject>(test_OpResultEncoder.Factory)
      .AddEncoder<Itest_Path>(test_PathEncoder.Factory)
      .AddEncoder<Itest_OpSelectionObject>(test_OpSelectionEncoder.Factory)
      .AddEncoder<Itest_OpFieldObject>(test_OpFieldEncoder.Factory)
      .AddEncoder<Itest_OpInlineObject>(test_OpInlineEncoder.Factory)
      .AddEncoder<Itest_OpSpreadObject>(test_OpSpreadEncoder.Factory)
      .AddEncoder<Itest_SettingObject>(test_SettingEncoder.Factory)
      .AddEncoder<Itest_TypeObject>(test_TypeEncoder.Factory)
      .AddEncoder<test_SimpleKind>(test_SimpleKindEncoder.Factory)
      .AddEncoder<test_TypeKind>(test_TypeKindEncoder.Factory)
      .AddEncoder<Itest_TypeSimpleObject>(test_TypeSimpleEncoder.Factory)
      .AddEncoder<Itest_CollectionsObject>(test_CollectionsEncoder.Factory)
      .AddEncoder<Itest_ModifiersObject>(test_ModifiersEncoder.Factory)
      .AddEncoder<test_ModifierKind>(test_ModifierKindEncoder.Factory)
      .AddEncoder<test_DomainKind>(test_DomainKindEncoder.Factory)
      .AddEncoder<Itest_BaseDomainItemObject>(test_BaseDomainItemEncoder.Factory)
      .AddEncoder<Itest_BasicValueObject>(test_BasicValueEncoder.Factory)
      .AddEncoder<Itest_DomainTrueFalseObject>(test_DomainTrueFalseEncoder.Factory)
      .AddEncoder<Itest_DomainItemTrueFalseObject>(test_DomainItemTrueFalseEncoder.Factory)
      .AddEncoder<Itest_DomainLabelObject>(test_DomainLabelEncoder.Factory)
      .AddEncoder<Itest_DomainItemLabelObject>(test_DomainItemLabelEncoder.Factory)
      .AddEncoder<Itest_DomainRangeObject>(test_DomainRangeEncoder.Factory)
      .AddEncoder<Itest_DomainItemRangeObject>(test_DomainItemRangeEncoder.Factory)
      .AddEncoder<Itest_DomainRegexObject>(test_DomainRegexEncoder.Factory)
      .AddEncoder<Itest_DomainItemRegexObject>(test_DomainItemRegexEncoder.Factory)
      .AddEncoder<Itest_EnumLabelObject>(test_EnumLabelEncoder.Factory)
      .AddEncoder<Itest_EnumValueObject>(test_EnumValueEncoder.Factory)
      .AddEncoder<Itest_UnionRefObject>(test_UnionRefEncoder.Factory)
      .AddEncoder<Itest_UnionMemberObject>(test_UnionMemberEncoder.Factory)
      .AddEncoder<Itest_ObjectKind>(test_ObjectKindEncoder.Factory)
      .AddEncoder<Itest_ObjTypeParamObject>(test_ObjTypeParamEncoder.Factory)
      .AddEncoder<Itest_ObjBaseObject>(test_ObjBaseEncoder.Factory)
      .AddEncoder<Itest_ObjTypeArgObject>(test_ObjTypeArgEncoder.Factory)
      .AddEncoder<Itest_TypeParamObject>(test_TypeParamEncoder.Factory)
      .AddEncoder<Itest_ObjAlternateObject>(test_ObjAlternateEncoder.Factory)
      .AddEncoder<Itest_ObjAlternateEnumObject>(test_ObjAlternateEnumEncoder.Factory)
      .AddEncoder<Itest_ObjFieldTypeObject>(test_ObjFieldTypeEncoder.Factory)
      .AddEncoder<Itest_ObjFieldEnumObject>(test_ObjFieldEnumEncoder.Factory)
      .AddEncoder<Itest_DualFieldObject>(test_DualFieldEncoder.Factory)
      .AddEncoder<Itest_InputFieldObject>(test_InputFieldEncoder.Factory)
      .AddEncoder<Itest_InputFieldTypeObject>(test_InputFieldTypeEncoder.Factory)
      .AddEncoder<Itest_OutputFieldObject>(test_OutputFieldEncoder.Factory)
      .AddEncoder<Itest_OutputFieldTypeObject>(test_OutputFieldTypeEncoder.Factory);
}
