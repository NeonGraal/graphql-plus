//HintName: test_field+Output_Enc.gen.cs
// Generated from {CurrentDirectory}field+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_Output;

internal class testFieldOutpEncoder : IEncoder<ItestFieldOutpObject>
{
  public Structured Encode(ItestFieldOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFieldOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFieldOutpObject>(testFieldOutpEncoder.Factory);
}
