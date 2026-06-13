//HintName: test_input-field-String_Enc.gen.cs
// Generated from {CurrentDirectory}input-field-String.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_String;

internal class testInpFieldStrEncoder : IEncoder<ItestInpFieldStrObject>
{
  public Structured Encode(ItestInpFieldStrObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testInpFieldStrEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_input_field_StringEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_input_field_StringEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestInpFieldStrObject>(testInpFieldStrEncoder.Factory);
}
