//HintName: test_input-field-Number_Enc.gen.cs
// Generated from {CurrentDirectory}input-field-Number.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_Number;

internal class testInpFieldNmbrEncoder : IEncoder<ItestInpFieldNmbrObject>
{
  public Structured Encode(ItestInpFieldNmbrObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testInpFieldNmbrEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_input_field_NumberEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_input_field_NumberEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestInpFieldNmbrObject>(testInpFieldNmbrEncoder.Factory);
}
