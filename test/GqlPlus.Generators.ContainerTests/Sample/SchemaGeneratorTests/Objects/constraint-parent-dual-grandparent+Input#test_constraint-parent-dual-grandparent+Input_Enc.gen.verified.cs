//HintName: test_constraint-parent-dual-grandparent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-grandparent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Input;

internal class testGrndCnstPrntDualGrndInpEncoder : IEncoder<ItestGrndCnstPrntDualGrndInpObject>
{
  public Structured Encode(ItestGrndCnstPrntDualGrndInpObject input)
    => Structured.Empty();

  internal static testGrndCnstPrntDualGrndInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntCnstPrntDualGrndInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntCnstPrntDualGrndInpObject>
{
  private readonly IEncoder<ItestGrndCnstPrntDualGrndInpObject> _itestGrndCnstPrntDualGrndInp = encoders.EncoderFor<ItestGrndCnstPrntDualGrndInpObject>();
  public Structured Encode(ItestPrntCnstPrntDualGrndInpObject input)
    => _itestGrndCnstPrntDualGrndInp.Encode(input);

  internal static testPrntCnstPrntDualGrndInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_constraint_parent_dual_grandparent_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_parent_dual_grandparent_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGrndCnstPrntDualGrndInpObject>(testGrndCnstPrntDualGrndInpEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntDualGrndInpObject>(testPrntCnstPrntDualGrndInpEncoder.Factory);
}
