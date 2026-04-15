//HintName: test_domain-string-parent_Enc.gen.cs
// Generated from {CurrentDirectory}domain-string-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_string_parent;

internal class testDmnStrPrntEncoder : IEncoder<ItestDmnStrPrnt>
{
  public Structured Encode(ItestDmnStrPrnt input)
    => new(input.Value);
}

internal class testPrntDmnStrPrntEncoder : IEncoder<ItestPrntDmnStrPrnt>
{
  public Structured Encode(ItestPrntDmnStrPrnt input)
    => new(input.Value);
}

internal static class test_domain_string_parentEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_string_parentEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnStrPrnt>(_ => new testDmnStrPrntEncoder())
      .AddEncoder<ItestPrntDmnStrPrnt>(_ => new testPrntDmnStrPrntEncoder());
}
