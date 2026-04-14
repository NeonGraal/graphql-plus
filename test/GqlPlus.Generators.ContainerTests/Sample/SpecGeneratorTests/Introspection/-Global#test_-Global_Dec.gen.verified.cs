//HintName: test_-Global_Dec.gen.cs
// Generated from {CurrentDirectory}-Global.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Global;

internal class test_ResolutionDecoder
{
  public string Parallel { get; set; }
  public string Sequential { get; set; }
  public string Single { get; set; }
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

internal static class test__GlobalDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__GlobalDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<test_Resolution>(_ => new test_ResolutionDecoder())
      .AddDecoder<test_Location>(_ => new test_LocationDecoder());
}
