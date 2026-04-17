//HintName: test_domain-string-parent-descr_Enc.gen.cs
// Generated from {CurrentDirectory}domain-string-parent-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_string_parent_descr;

internal class testDmnStrPrntDescrEncoder : IEncoder<ItestDmnStrPrntDescr>
{
  public Structured Encode(ItestDmnStrPrntDescr input)
    => new(input.Value);

  internal static testDmnStrPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnStrPrntDescrEncoder : IEncoder<ItestPrntDmnStrPrntDescr>
{
  public Structured Encode(ItestPrntDmnStrPrntDescr input)
    => new(input.Value);

  internal static testPrntDmnStrPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_string_parent_descrEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_string_parent_descrEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnStrPrntDescr>(testDmnStrPrntDescrEncoder.Factory)
      .AddEncoder<ItestPrntDmnStrPrntDescr>(testPrntDmnStrPrntDescrEncoder.Factory);
}
