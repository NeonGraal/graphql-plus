//HintName: test_descr_Enc.gen.cs
// Generated from {CurrentDirectory}descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_descr;

internal class testDescrEncoder : IEncoder<ItestDescrObject>
{
  public Structured Encode(ItestDescrObject input)
    => Structured.Empty();

  internal static testDescrEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_descrEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_descrEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDescrObject>(testDescrEncoder.Factory);
}
