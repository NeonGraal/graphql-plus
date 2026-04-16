//HintName: test_constraint-parent-dual-parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Input;

internal class testPrntCnstPrntDualPrntInpEncoder : IEncoder<ItestPrntCnstPrntDualPrntInpObject>
{
  public Structured Encode(ItestPrntCnstPrntDualPrntInpObject input)
    => Structured.Empty();

  internal static testPrntCnstPrntDualPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_constraint_parent_dual_parent_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_parent_dual_parent_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestPrntCnstPrntDualPrntInpObject>(testPrntCnstPrntDualPrntInpEncoder.Factory);
}
