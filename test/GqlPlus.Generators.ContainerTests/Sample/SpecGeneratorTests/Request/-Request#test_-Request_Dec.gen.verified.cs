//HintName: test_-Request_Dec.gen.cs
// Generated from {CurrentDirectory}-Request.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Request;

internal class test_RequestDecoder : NullDecoder<Itest_RequestObject>
{
  public Itest_Identifier? Category { get; set; } = default!;
  public Itest_Identifier? Operation { get; set; } = default!;
  public Itest_Operation Definition { get; set; } = default!;
  public object? Parameters { get; set; } = default!;

  internal static test_RequestDecoder Factory(IDecoderRepository _) => new();
}

internal class test_IdentifierDecoder : NullDecoder<Itest_Identifier>
{

  internal static test_IdentifierDecoder Factory(IDecoderRepository _) => new();
}

internal class test_CollectionsDecoder : NullDecoder<Itest_CollectionsObject>
{

  internal static test_CollectionsDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ModifierKeyedDecoder<TModifierKind>
{
  public Itest_Identifier By { get; set; } = default!;
  public bool IsOptional { get; set; } = default!;
}

internal class test_ModifiersDecoder : NullDecoder<Itest_ModifiersObject>
{

  internal static test_ModifiersDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ModifierKindDecoder : NullDecoder<test_ModifierKind>
{
  public string Opt { get; set; } = default!;
  public string Optional { get; set; } = default!;
  public string List { get; set; } = default!;
  public string Dict { get; set; } = default!;
  public string Dictionary { get; set; } = default!;
  public string Param { get; set; } = default!;
  public string TypeParam { get; set; } = default!;

  internal static test_ModifierKindDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ModifierDecoder<TModifierKind>
{
  public TModifierKind ModifierKind { get; set; } = default!;
}

internal class test_OperationDecoder : NullDecoder<Itest_OperationObject>
{
  public ICollection<Itest_OpVariable> Variables { get; set; } = default!;
  public ICollection<Itest_OpDirective> Directives { get; set; } = default!;
  public ICollection<Itest_OpFragment> Fragments { get; set; } = default!;
  public Itest_OpResult Result { get; set; } = default!;
  public IDictionary<Itest_Path, ICollection<Itest_OpSelection>> Selections { get; set; } = default!;

  internal static test_OperationDecoder Factory(IDecoderRepository _) => new();
}

internal class test_PathDecoder : NullDecoder<Itest_Path>
{

  internal static test_PathDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpDirectivesDecoder : NullDecoder<Itest_OpDirectivesObject>
{
  public Itest_Identifier Name { get; set; } = default!;
  public ICollection<string> Description { get; set; } = default!;
  public ICollection<Itest_OpDirective> Directives { get; set; } = default!;

  internal static test_OpDirectivesDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpVariableDecoder : NullDecoder<Itest_OpVariableObject>
{
  public Itest_Identifier? Type { get; set; } = default!;
  public ICollection<Itest_Modifiers> Modifiers { get; set; } = default!;
  public GqlpValue? DefaultValue { get; set; } = default!;

  internal static test_OpVariableDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpDirectiveDecoder : NullDecoder<Itest_OpDirectiveObject>
{
  public Itest_Identifier Name { get; set; } = default!;
  public Itest_OpArgument? Argument { get; set; } = default!;

  internal static test_OpDirectiveDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpFragmentDecoder : NullDecoder<Itest_OpFragmentObject>
{
  public Itest_Identifier? Type { get; set; } = default!;

  internal static test_OpFragmentDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpResultDecoder : NullDecoder<Itest_OpResultObject>
{
  public Itest_Identifier? Domain { get; set; } = default!;
  public Itest_OpArgument? Argument { get; set; } = default!;

  internal static test_OpResultDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgumentDecoder : NullDecoder<Itest_OpArgumentObject>
{

  internal static test_OpArgumentDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgValueDecoder : NullDecoder<Itest_OpArgValueObject>
{
  public Itest_Identifier Variable { get; set; } = default!;

  internal static test_OpArgValueDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgListDecoder : NullDecoder<Itest_OpArgListObject>
{

  internal static test_OpArgListDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgMapDecoder : NullDecoder<Itest_OpArgMapObject>
{
  public Itest_OpArgValue Value { get; set; } = default!;
  public Itest_Identifier ByVariable { get; set; } = default!;

  internal static test_OpArgMapDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpSelectionDecoder : NullDecoder<Itest_OpSelectionObject>
{

  internal static test_OpSelectionDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpFieldDecoder : NullDecoder<Itest_OpFieldObject>
{
  public Itest_Identifier? FieldAlias { get; set; } = default!;
  public Itest_OpArgument? Argument { get; set; } = default!;
  public ICollection<Itest_Modifiers> Modifiers { get; set; } = default!;

  internal static test_OpFieldDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpInlineDecoder : NullDecoder<Itest_OpInlineObject>
{
  public Itest_Identifier? Type { get; set; } = default!;
  public ICollection<Itest_OpDirective> Directives { get; set; } = default!;

  internal static test_OpInlineDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpSpreadDecoder : NullDecoder<Itest_OpSpreadObject>
{
  public Itest_Identifier Fragment { get; set; } = default!;
  public ICollection<Itest_OpDirective> Directives { get; set; } = default!;

  internal static test_OpSpreadDecoder Factory(IDecoderRepository _) => new();
}

internal static class test__RequestDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__RequestDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_RequestObject>(test_RequestDecoder.Factory)
      .AddDecoder<Itest_Identifier>(test_IdentifierDecoder.Factory)
      .AddDecoder<Itest_CollectionsObject>(test_CollectionsDecoder.Factory)
      .AddDecoder<Itest_ModifiersObject>(test_ModifiersDecoder.Factory)
      .AddDecoder<test_ModifierKind>(test_ModifierKindDecoder.Factory)
      .AddDecoder<Itest_OperationObject>(test_OperationDecoder.Factory)
      .AddDecoder<Itest_Path>(test_PathDecoder.Factory)
      .AddDecoder<Itest_OpDirectivesObject>(test_OpDirectivesDecoder.Factory)
      .AddDecoder<Itest_OpVariableObject>(test_OpVariableDecoder.Factory)
      .AddDecoder<Itest_OpDirectiveObject>(test_OpDirectiveDecoder.Factory)
      .AddDecoder<Itest_OpFragmentObject>(test_OpFragmentDecoder.Factory)
      .AddDecoder<Itest_OpResultObject>(test_OpResultDecoder.Factory)
      .AddDecoder<Itest_OpArgumentObject>(test_OpArgumentDecoder.Factory)
      .AddDecoder<Itest_OpArgValueObject>(test_OpArgValueDecoder.Factory)
      .AddDecoder<Itest_OpArgListObject>(test_OpArgListDecoder.Factory)
      .AddDecoder<Itest_OpArgMapObject>(test_OpArgMapDecoder.Factory)
      .AddDecoder<Itest_OpSelectionObject>(test_OpSelectionDecoder.Factory)
      .AddDecoder<Itest_OpFieldObject>(test_OpFieldDecoder.Factory)
      .AddDecoder<Itest_OpInlineObject>(test_OpInlineDecoder.Factory)
      .AddDecoder<Itest_OpSpreadObject>(test_OpSpreadDecoder.Factory);
}
