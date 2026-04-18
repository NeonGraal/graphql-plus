//HintName: test_descr-single_Enc.gen.cs
// Generated from {CurrentDirectory}descr-single.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_descr_single;

internal class testDescrSnglEncoder : IEncoder<ItestDescrSnglObject>
{
  public Structured Encode(ItestDescrSnglObject input)
    => Structured.Empty();

  internal static testDescrSnglEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_descr_singleEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_descr_singleEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDescrSnglObject>(testDescrSnglEncoder.Factory);
}
