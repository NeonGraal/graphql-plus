//HintName: test_alt-descr+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}alt-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_descr_Dual;

internal class testAltDescrDualEncoder : IEncoder<ItestAltDescrDualObject>
{
  public Structured Encode(ItestAltDescrDualObject input)
    => Structured.Empty();

  internal static testAltDescrDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_alt_descr_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_descr_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltDescrDualObject>(testAltDescrDualEncoder.Factory);
}
