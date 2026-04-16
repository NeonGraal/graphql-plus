//HintName: test_domain-number-descr_Enc.gen.cs
// Generated from {CurrentDirectory}domain-number-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_number_descr;

internal class testDmnNmbrDescrEncoder : IEncoder<ItestDmnNmbrDescr>
{
  public Structured Encode(ItestDmnNmbrDescr input)
    => new(input.Value);

  internal static testDmnNmbrDescrEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_number_descrEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_number_descrEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnNmbrDescr>(testDmnNmbrDescrEncoder.Factory);
}
