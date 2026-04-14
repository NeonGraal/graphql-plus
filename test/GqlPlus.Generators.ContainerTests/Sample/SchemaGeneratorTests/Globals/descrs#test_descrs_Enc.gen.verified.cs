//HintName: test_descrs_Enc.gen.cs
// Generated from {CurrentDirectory}descrs.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_descrs;

internal class testDscrsEncoder : IEncoder<ItestDscrsObject>
{
  public Structured Encode(ItestDscrsObject input)
    => Structured.Empty();
}

internal static class test_descrsEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_descrsEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDscrsObject>(_ => new testDscrsEncoder());
}
