//HintName: test_operation-domain-mods_Enc.gen.cs
// Generated from {CurrentDirectory}operation-domain-mods.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_domain_mods;

internal class testCatOprDmnModsEncoder : IEncoder<ItestCatOprDmnModsObject>
{
  public Structured Encode(ItestCatOprDmnModsObject input)
    => Structured.Empty();

  internal static testCatOprDmnModsEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_operation_domain_modsEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_operation_domain_modsEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCatOprDmnModsObject>(testCatOprDmnModsEncoder.Factory);
}
