//HintName: test_domain-string-descr_Enc.gen.cs
// Generated from {CurrentDirectory}domain-string-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_string_descr;

internal class testDmnStrDescrEncoder : IEncoder<ItestDmnStrDescr>
{
  public Structured Encode(ItestDmnStrDescr input)
    => input.Value!.Encode();

  internal static testDmnStrDescrEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_string_descrEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_string_descrEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnStrDescr>(testDmnStrDescrEncoder.Factory);
}
