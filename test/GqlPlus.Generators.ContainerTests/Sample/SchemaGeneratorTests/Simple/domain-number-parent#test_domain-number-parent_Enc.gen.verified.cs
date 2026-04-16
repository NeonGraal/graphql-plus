//HintName: test_domain-number-parent_Enc.gen.cs
// Generated from {CurrentDirectory}domain-number-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_number_parent;

internal class testDmnNmbrPrntEncoder : IEncoder<ItestDmnNmbrPrnt>
{
  public Structured Encode(ItestDmnNmbrPrnt input)
    => new(input.Value);

  internal static testDmnNmbrPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnNmbrPrntEncoder : IEncoder<ItestPrntDmnNmbrPrnt>
{
  public Structured Encode(ItestPrntDmnNmbrPrnt input)
    => new(input.Value);

  internal static testPrntDmnNmbrPrntEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_number_parentEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_number_parentEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnNmbrPrnt>(testDmnNmbrPrntEncoder.Factory)
      .AddEncoder<ItestPrntDmnNmbrPrnt>(testPrntDmnNmbrPrntEncoder.Factory);
}
