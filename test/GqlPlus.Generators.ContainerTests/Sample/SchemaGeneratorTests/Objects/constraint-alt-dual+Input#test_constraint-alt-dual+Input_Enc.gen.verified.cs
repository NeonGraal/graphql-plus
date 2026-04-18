//HintName: test_constraint-alt-dual+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Input;

internal class testPrntCnstAltDualInpEncoder : IEncoder<ItestPrntCnstAltDualInpObject>
{
  public Structured Encode(ItestPrntCnstAltDualInpObject input)
    => Structured.Empty();

  internal static testPrntCnstAltDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_constraint_alt_dual_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_alt_dual_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestPrntCnstAltDualInpObject>(testPrntCnstAltDualInpEncoder.Factory);
}
