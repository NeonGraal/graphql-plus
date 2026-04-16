//HintName: test_descr-between_Enc.gen.cs
// Generated from {CurrentDirectory}descr-between.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_descr_between;

internal class testDescrBtwnEncoder : IEncoder<ItestDescrBtwnObject>
{
  public Structured Encode(ItestDescrBtwnObject input)
    => Structured.Empty();

  internal static testDescrBtwnEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_descr_betweenEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_descr_betweenEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDescrBtwnObject>(testDescrBtwnEncoder.Factory);
}
