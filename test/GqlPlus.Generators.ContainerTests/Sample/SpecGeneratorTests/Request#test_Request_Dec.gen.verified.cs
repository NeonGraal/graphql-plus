//HintName: test_Request_Dec.gen.cs
// Generated from {CurrentDirectory}Request.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Request;

internal class test_RequestDecoder
{
  public Itest_Identifier? Category { get; set; }
  public Itest_Identifier? Operation { get; set; }
  public Itest_Operation Definition { get; set; }
  public object? Parameters { get; set; }

  internal static test_RequestDecoder Factory(IDecoderRepository _) => new();
}

internal class test_IdentifierDecoder
{

  internal static test_IdentifierDecoder Factory(IDecoderRepository _) => new();
}

internal class test_CollectionsDecoder
{

  internal static test_CollectionsDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ModifierKeyedDecoder<TModifierKind>
{
  public Itest_Identifier By { get; set; }
  public bool IsOptional { get; set; }
}

internal class test_ModifiersDecoder
{

  internal static test_ModifiersDecoder Factory(IDecoderRepository _) => new();
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

  internal static test_ModifierKindDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ModifierDecoder<TModifierKind>
{
  public TModifierKind ModifierKind { get; set; }
}

internal class test_OperationDecoder
{
  public ICollection<Itest_OpVariable> Variables { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
  public ICollection<Itest_OpFragment> Fragments { get; set; }
  public Itest_OpResult Result { get; set; }
  public IDictionary<Itest_Path, ICollection<Itest_OpSelection>> Selections { get; set; }

  internal static test_OperationDecoder Factory(IDecoderRepository _) => new();
}

internal class test_PathDecoder
{

  internal static test_PathDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpDirectivesDecoder
{
  public Itest_Identifier Name { get; set; }
  public ICollection<string> Description { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }

  internal static test_OpDirectivesDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpVariableDecoder
{
  public Itest_Identifier? Type { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
  public GqlpValue? DefaultValue { get; set; }

  internal static test_OpVariableDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpDirectiveDecoder
{
  public Itest_Identifier Name { get; set; }
  public Itest_OpArgument? Argument { get; set; }

  internal static test_OpDirectiveDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpFragmentDecoder
{
  public Itest_Identifier? Type { get; set; }

  internal static test_OpFragmentDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpResultDecoder
{
  public Itest_Identifier? Domain { get; set; }
  public Itest_OpArgument? Argument { get; set; }

  internal static test_OpResultDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgumentDecoder
{

  internal static test_OpArgumentDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgValueDecoder
{
  public Itest_Identifier Variable { get; set; }

  internal static test_OpArgValueDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgListDecoder
{

  internal static test_OpArgListDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgMapDecoder
{
  public Itest_OpArgValue Value { get; set; }
  public Itest_Identifier ByVariable { get; set; }

  internal static test_OpArgMapDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpSelectionDecoder
{

  internal static test_OpSelectionDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpFieldDecoder
{
  public Itest_Identifier? FieldAlias { get; set; }
  public Itest_OpArgument? Argument { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }

  internal static test_OpFieldDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpInlineDecoder
{
  public Itest_Identifier? Type { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }

  internal static test_OpInlineDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpSpreadDecoder
{
  public Itest_Identifier Fragment { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }

  internal static test_OpSpreadDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_RequestDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_RequestDecoders(this IDecoderRepositoryBuilder builder)
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
