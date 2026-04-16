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

  internal static testDmnStrPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnStrPrntEncoder : IEncoder<ItestPrntDmnStrPrnt>
{
  public Structured Encode(ItestPrntDmnStrPrnt input)
    => new(input.Value);

  internal static testPrntDmnStrPrntEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_string_parentEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_string_parentEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnStrPrnt>(testDmnStrPrntEncoder.Factory)
      .AddEncoder<ItestPrntDmnStrPrnt>(testPrntDmnStrPrntEncoder.Factory);
}
