//HintName: test_descr-backslash_Enc.gen.cs
// Generated from {CurrentDirectory}descr-backslash.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_descr_backslash;

internal class testDescrBcksEncoder : IEncoder<ItestDescrBcksObject>
{
  public Structured Encode(ItestDescrBcksObject input)
    => Structured.Empty();

  internal static testDescrBcksEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_descr_backslashEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_descr_backslashEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDescrBcksObject>(testDescrBcksEncoder.Factory);
}
