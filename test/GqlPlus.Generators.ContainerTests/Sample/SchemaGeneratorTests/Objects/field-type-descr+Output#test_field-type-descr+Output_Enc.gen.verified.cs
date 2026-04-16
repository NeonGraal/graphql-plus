//HintName: test_field-type-descr+Output_Enc.gen.cs
// Generated from {CurrentDirectory}field-type-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_type_descr_Output;

internal class testFieldTypeDescrOutpEncoder : IEncoder<ItestFieldTypeDescrOutpObject>
{
  public Structured Encode(ItestFieldTypeDescrOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);

  internal static testFieldTypeDescrOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_type_descr_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_type_descr_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFieldTypeDescrOutpObject>(testFieldTypeDescrOutpEncoder.Factory);
}
