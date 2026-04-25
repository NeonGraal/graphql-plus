//HintName: test_domain-bool-parent-descr_Enc.gen.cs
// Generated from {CurrentDirectory}domain-bool-parent-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_bool_parent_descr;

internal class testDmnBoolPrntDescrEncoder : IEncoder<ItestDmnBoolPrntDescr>
{
  public Structured Encode(ItestDmnBoolPrntDescr input)
    => input.Value!.Encode();

  internal static testDmnBoolPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnBoolPrntDescrEncoder : IEncoder<ItestPrntDmnBoolPrntDescr>
{
  public Structured Encode(ItestPrntDmnBoolPrntDescr input)
    => input.Value!.Encode();

  internal static testPrntDmnBoolPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_bool_parent_descrEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_bool_parent_descrEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnBoolPrntDescr>(testDmnBoolPrntDescrEncoder.Factory)
      .AddEncoder<ItestPrntDmnBoolPrntDescr>(testPrntDmnBoolPrntDescrEncoder.Factory);
}
