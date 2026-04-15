//HintName: test_input-field-null_Enc.gen.cs
// Generated from {CurrentDirectory}input-field-null.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_null;

internal class testFldInpFieldNullEncoder : IEncoder<ItestFldInpFieldNullObject>
{
  public Structured Encode(ItestFldInpFieldNullObject input)
    => Structured.Empty();

  internal static testFldInpFieldNullEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_input_field_nullEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_input_field_nullEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFldInpFieldNullObject>(testFldInpFieldNullEncoder.Factory);
}
