//HintName: test_constraint-field-dual+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Input;

internal class testPrntCnstFieldDualInpEncoder : IEncoder<ItestPrntCnstFieldDualInpObject>
{
  public Structured Encode(ItestPrntCnstFieldDualInpObject input)
    => Structured.Empty();
}

internal static class test_constraint_field_dual_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_field_dual_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestPrntCnstFieldDualInpObject>(_ => new testPrntCnstFieldDualInpEncoder());
}
