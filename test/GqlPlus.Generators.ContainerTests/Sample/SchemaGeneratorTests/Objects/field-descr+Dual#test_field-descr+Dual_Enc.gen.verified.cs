//HintName: test_field-descr+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}field-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_descr_Dual;

internal class testFieldDescrDualEncoder : IEncoder<ItestFieldDescrDualObject>
{
  public Structured Encode(ItestFieldDescrDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);

  internal static testFieldDescrDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_descr_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_descr_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFieldDescrDualObject>(testFieldDescrDualEncoder.Factory);
}
