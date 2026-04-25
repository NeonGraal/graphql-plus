//HintName: test_domain-bool-descr_Enc.gen.cs
// Generated from {CurrentDirectory}domain-bool-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_bool_descr;

internal class testDmnBoolDescrEncoder : IEncoder<ItestDmnBoolDescr>
{
  public Structured Encode(ItestDmnBoolDescr input)
    => input.Value!.Encode();

  internal static testDmnBoolDescrEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_bool_descrEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_bool_descrEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnBoolDescr>(testDmnBoolDescrEncoder.Factory);
}
