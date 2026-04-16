//HintName: test_Result_Dec.gen.cs
// Generated from {CurrentDirectory}Result.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Result;

internal class test_OpResultDecoder
{
  public Itest_Identifier? Domain { get; set; }
  public Itest_OpArgument? Argument { get; set; }
  public ICollection<Itest_OpObject> Body { get; set; }

  internal static test_OpResultDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpObjectDecoder
{

  internal static test_OpObjectDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpFieldDecoder
{
  public Itest_Identifier? Alias { get; set; }
  public Itest_Identifier Field { get; set; }
  public Itest_OpArgument? Argument { get; set; }
  public ICollection<Itest_Modifier> Modifiers { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
  public string Body { get; set; }

  internal static test_OpFieldDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpInlineDecoder
{
  public Itest_Identifier? Type { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
  public string Body { get; set; }

  internal static test_OpInlineDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpSpreadDecoder
{
  public Itest_Identifier Fragment { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }

  internal static test_OpSpreadDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_ResultDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_ResultDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_OpResultObject>(test_OpResultDecoder.Factory)
      .AddDecoder<Itest_OpObjectObject>(test_OpObjectDecoder.Factory)
      .AddDecoder<Itest_OpFieldObject>(test_OpFieldDecoder.Factory)
      .AddDecoder<Itest_OpInlineObject>(test_OpInlineDecoder.Factory)
      .AddDecoder<Itest_OpSpreadObject>(test_OpSpreadDecoder.Factory);
}
