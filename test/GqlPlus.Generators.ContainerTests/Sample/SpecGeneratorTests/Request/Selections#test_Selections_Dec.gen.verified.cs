//HintName: test_Selections_Dec.gen.cs
// Generated from {CurrentDirectory}Selections.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Selections;

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

internal static class test_SelectionsDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_SelectionsDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_OpSelectionObject>(test_OpSelectionDecoder.Factory)
      .AddDecoder<Itest_OpFieldObject>(test_OpFieldDecoder.Factory)
      .AddDecoder<Itest_OpInlineObject>(test_OpInlineDecoder.Factory)
      .AddDecoder<Itest_OpSpreadObject>(test_OpSpreadDecoder.Factory);
}
