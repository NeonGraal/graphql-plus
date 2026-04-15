//HintName: test_Full_Dec.gen.cs
// Generated from {CurrentDirectory}Full.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Full;

internal class test_RequestDecoder
{
  public Itest_Identifier? Category { get; set; }
  public Itest_Identifier? Operation { get; set; }
  public Itest_Operation Definition { get; set; }
  public Itest_Any? Parameters { get; set; }
}

internal class test_IdentifierDecoder
{
}

internal static class test_FullDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_FullDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_RequestObject>(_ => new test_RequestDecoder())
      .AddDecoder<Itest_Identifier>(_ => new test_IdentifierDecoder());
}
