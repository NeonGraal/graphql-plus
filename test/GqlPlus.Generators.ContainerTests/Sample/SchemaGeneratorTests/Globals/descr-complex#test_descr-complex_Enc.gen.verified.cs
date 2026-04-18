//HintName: test_descr-complex_Enc.gen.cs
// Generated from {CurrentDirectory}descr-complex.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_descr_complex;

internal class testDescrCmplEncoder : IEncoder<ItestDescrCmplObject>
{
  public Structured Encode(ItestDescrCmplObject input)
    => Structured.Empty();

  internal static testDescrCmplEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_descr_complexEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_descr_complexEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDescrCmplObject>(testDescrCmplEncoder.Factory);
}
