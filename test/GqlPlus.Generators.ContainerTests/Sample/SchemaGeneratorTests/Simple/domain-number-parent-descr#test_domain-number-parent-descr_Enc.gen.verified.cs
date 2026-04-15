//HintName: test_domain-number-parent-descr_Enc.gen.cs
// Generated from {CurrentDirectory}domain-number-parent-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_number_parent_descr;

internal class testDmnNmbrPrntDescrEncoder : IEncoder<ItestDmnNmbrPrntDescr>
{
  public Structured Encode(ItestDmnNmbrPrntDescr input)
    => new(input.Value);
}

internal class testPrntDmnNmbrPrntDescrEncoder : IEncoder<ItestPrntDmnNmbrPrntDescr>
{
  public Structured Encode(ItestPrntDmnNmbrPrntDescr input)
    => new(input.Value);
}

internal static class test_domain_number_parent_descrEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_number_parent_descrEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnNmbrPrntDescr>(_ => new testDmnNmbrPrntDescrEncoder())
      .AddEncoder<ItestPrntDmnNmbrPrntDescr>(_ => new testPrntDmnNmbrPrntDescrEncoder());
}
