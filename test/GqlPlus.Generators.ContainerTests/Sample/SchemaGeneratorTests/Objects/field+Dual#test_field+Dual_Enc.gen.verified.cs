//HintName: test_field+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}field+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_Dual;

internal class testFieldDualEncoder : IEncoder<ItestFieldDualObject>
{
  public Structured Encode(ItestFieldDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);

  internal static testFieldDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFieldDualObject>(testFieldDualEncoder.Factory);
}
