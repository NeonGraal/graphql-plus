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
}

internal class test_OpObjectDecoder
{
}

internal class test_OpFieldDecoder
{
  public Itest_Identifier? Alias { get; set; }
  public Itest_Identifier Field { get; set; }
  public Itest_OpArgument? Argument { get; set; }
  public ICollection<Itest_Modifier> Modifiers { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
  public string Body { get; set; }
}

internal class test_OpInlineDecoder
{
  public Itest_Identifier? Type { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
  public string Body { get; set; }
}

internal class test_OpSpreadDecoder
{
  public Itest_Identifier Fragment { get; set; }
  public ICollection<Itest_OpDirective> Directives { get; set; }
}

internal static class test_ResultDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_ResultDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_OpResultObject>(_ => new test_OpResultDecoder())
      .AddDecoder<Itest_OpObjectObject>(_ => new test_OpObjectDecoder())
      .AddDecoder<Itest_OpFieldObject>(_ => new test_OpFieldDecoder())
      .AddDecoder<Itest_OpInlineObject>(_ => new test_OpInlineDecoder())
      .AddDecoder<Itest_OpSpreadObject>(_ => new test_OpSpreadDecoder());
}
