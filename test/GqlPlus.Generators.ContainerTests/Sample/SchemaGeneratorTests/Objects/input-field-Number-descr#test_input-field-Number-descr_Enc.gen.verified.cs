//HintName: test_input-field-Number-descr_Enc.gen.cs
// Generated from {CurrentDirectory}input-field-Number-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_Number_descr;

internal class testInpFieldNmbrDescrEncoder : IEncoder<ItestInpFieldNmbrDescrObject>
{
  public Structured Encode(ItestInpFieldNmbrDescrObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testInpFieldNmbrDescrEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_input_field_Number_descrEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_input_field_Number_descrEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestInpFieldNmbrDescrObject>(testInpFieldNmbrDescrEncoder.Factory);
}
