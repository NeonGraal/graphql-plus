//HintName: test_field-simple+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}field-simple+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_simple_Dual;

internal class testFieldSmplDualEncoder : IEncoder<ItestFieldSmplDualObject>
{
  public Structured Encode(ItestFieldSmplDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);

  internal static testFieldSmplDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_simple_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_simple_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFieldSmplDualObject>(testFieldSmplDualEncoder.Factory);
}
