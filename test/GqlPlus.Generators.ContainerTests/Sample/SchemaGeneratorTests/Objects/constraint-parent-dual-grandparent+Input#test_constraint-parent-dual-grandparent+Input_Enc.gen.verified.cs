//HintName: test_constraint-parent-dual-grandparent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-grandparent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Input;

internal class testCnstPrntDualGrndInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualGrndInpObject>
{
  private readonly Encoder<ItestRefCnstPrntDualGrndInpObject<ItestAltCnstPrntDualGrndInp>> _itestRefCnstPrntDualGrndInp = encoders.EncoderFor<ItestRefCnstPrntDualGrndInpObject<ItestAltCnstPrntDualGrndInp>>();
  public IGqlpValue Encode(ItestCnstPrntDualGrndInpObject input)
    => _itestRefCnstPrntDualGrndInp.Encode(input);

  internal static testCnstPrntDualGrndInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntDualGrndInpEncoder<TRef> : IEncoder<ItestRefCnstPrntDualGrndInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefCnstPrntDualGrndInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testGrndCnstPrntDualGrndInpEncoder : IEncoder<ItestGrndCnstPrntDualGrndInpObject>
{
  public IGqlpValue Encode(ItestGrndCnstPrntDualGrndInpObject input)
    => new GqlpUnit();

  internal static testGrndCnstPrntDualGrndInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntCnstPrntDualGrndInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntCnstPrntDualGrndInpObject>
{
  private readonly Encoder<ItestGrndCnstPrntDualGrndInpObject> _itestGrndCnstPrntDualGrndInp = encoders.EncoderFor<ItestGrndCnstPrntDualGrndInpObject>();
  public IGqlpValue Encode(ItestPrntCnstPrntDualGrndInpObject input)
    => _itestGrndCnstPrntDualGrndInp.Encode(input);

  internal static testPrntCnstPrntDualGrndInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testAltCnstPrntDualGrndInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualGrndInpObject>
{
  private readonly Encoder<ItestPrntCnstPrntDualGrndInpObject> _itestPrntCnstPrntDualGrndInp = encoders.EncoderFor<ItestPrntCnstPrntDualGrndInpObject>();
  public IGqlpValue Encode(ItestAltCnstPrntDualGrndInpObject input)
    => _itestPrntCnstPrntDualGrndInp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstPrntDualGrndInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_constraint_parent_dual_grandparent_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_parent_dual_grandparent_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstPrntDualGrndInpObject>(testCnstPrntDualGrndInpEncoder.Factory)
      .AddEncoder<ItestGrndCnstPrntDualGrndInpObject>(testGrndCnstPrntDualGrndInpEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntDualGrndInpObject>(testPrntCnstPrntDualGrndInpEncoder.Factory)
      .AddEncoder<ItestAltCnstPrntDualGrndInpObject>(testAltCnstPrntDualGrndInpEncoder.Factory);
}
