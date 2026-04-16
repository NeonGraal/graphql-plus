//HintName: test_field-simple+Output_Enc.gen.cs
// Generated from {CurrentDirectory}field-simple+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_simple_Output;

internal class testFieldSmplOutpEncoder : IEncoder<ItestFieldSmplOutpObject>
{
  public Structured Encode(ItestFieldSmplOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);

  internal static testFieldSmplOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_simple_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_simple_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFieldSmplOutpObject>(testFieldSmplOutpEncoder.Factory);
}
