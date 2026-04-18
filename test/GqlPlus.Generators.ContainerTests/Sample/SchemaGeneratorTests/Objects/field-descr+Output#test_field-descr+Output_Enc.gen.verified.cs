//HintName: test_field-descr+Output_Enc.gen.cs
// Generated from {CurrentDirectory}field-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_descr_Output;

internal class testFieldDescrOutpEncoder : IEncoder<ItestFieldDescrOutpObject>
{
  public Structured Encode(ItestFieldDescrOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);

  internal static testFieldDescrOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_descr_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_descr_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFieldDescrOutpObject>(testFieldDescrOutpEncoder.Factory);
}
