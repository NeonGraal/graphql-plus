//HintName: test_field-type-descr+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-type-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_type_descr_Input;

internal class testFieldTypeDescrInpEncoder : IEncoder<ItestFieldTypeDescrInpObject>
{
  public Structured Encode(ItestFieldTypeDescrInpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFieldTypeDescrInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_type_descr_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_type_descr_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFieldTypeDescrInpObject>(testFieldTypeDescrInpEncoder.Factory);
}
