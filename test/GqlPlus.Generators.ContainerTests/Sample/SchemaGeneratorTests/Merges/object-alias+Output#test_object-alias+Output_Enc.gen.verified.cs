//HintName: test_object-alias+Output_Enc.gen.cs
// Generated from {CurrentDirectory}object-alias+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alias_Output;

internal class testObjAliasOutpEncoder : IEncoder<ItestObjAliasOutpObject>
{
  public Structured Encode(ItestObjAliasOutpObject input)
    => Structured.Empty();

  internal static testObjAliasOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_object_alias_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_alias_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjAliasOutpObject>(testObjAliasOutpEncoder.Factory);
}
