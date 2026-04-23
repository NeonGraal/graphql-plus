//HintName: test_constraint-parent-dual-parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Input;

internal class testCnstPrntDualPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualPrntInpObject>
{
  private readonly IEncoder<ItestRefCnstPrntDualPrntInpObject<ItestAltCnstPrntDualPrntInp>> _itestRefCnstPrntDualPrntInp = encoders.EncoderFor<ItestRefCnstPrntDualPrntInpObject<ItestAltCnstPrntDualPrntInp>>();
  public Structured Encode(ItestCnstPrntDualPrntInpObject input)
    => _itestRefCnstPrntDualPrntInp.Encode(input);

  internal static testCnstPrntDualPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntDualPrntInpEncoder<TRef> : IEncoder<ItestRefCnstPrntDualPrntInpObject<TRef>>
{
  public Structured Encode(ItestRefCnstPrntDualPrntInpObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstPrntDualPrntInpEncoder : IEncoder<ItestPrntCnstPrntDualPrntInpObject>
{
  public Structured Encode(ItestPrntCnstPrntDualPrntInpObject input)
    => Structured.Empty();

  internal static testPrntCnstPrntDualPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstPrntDualPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualPrntInpObject>
{
  private readonly IEncoder<ItestPrntCnstPrntDualPrntInpObject> _itestPrntCnstPrntDualPrntInp = encoders.EncoderFor<ItestPrntCnstPrntDualPrntInpObject>();
  public Structured Encode(ItestAltCnstPrntDualPrntInpObject input)
    => _itestPrntCnstPrntDualPrntInp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstPrntDualPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_constraint_parent_dual_parent_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_parent_dual_parent_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstPrntDualPrntInpObject>(testCnstPrntDualPrntInpEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntDualPrntInpObject>(testPrntCnstPrntDualPrntInpEncoder.Factory)
      .AddEncoder<ItestAltCnstPrntDualPrntInpObject>(testAltCnstPrntDualPrntInpEncoder.Factory);
}
