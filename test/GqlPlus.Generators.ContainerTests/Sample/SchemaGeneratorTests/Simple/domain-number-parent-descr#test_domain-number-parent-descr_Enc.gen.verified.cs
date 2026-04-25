//HintName: test_domain-number-parent-descr_Enc.gen.cs
// Generated from {CurrentDirectory}domain-number-parent-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_number_parent_descr;

internal class testDmnNmbrPrntDescrEncoder : IEncoder<ItestDmnNmbrPrntDescr>
{
  public Structured Encode(ItestDmnNmbrPrntDescr input)
    => input.Value!.Encode();

  internal static testDmnNmbrPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnNmbrPrntDescrEncoder : IEncoder<ItestPrntDmnNmbrPrntDescr>
{
  public Structured Encode(ItestPrntDmnNmbrPrntDescr input)
    => input.Value!.Encode();

  internal static testPrntDmnNmbrPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_number_parent_descrEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_number_parent_descrEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnNmbrPrntDescr>(testDmnNmbrPrntDescrEncoder.Factory)
      .AddEncoder<ItestPrntDmnNmbrPrntDescr>(testPrntDmnNmbrPrntDescrEncoder.Factory);
}
