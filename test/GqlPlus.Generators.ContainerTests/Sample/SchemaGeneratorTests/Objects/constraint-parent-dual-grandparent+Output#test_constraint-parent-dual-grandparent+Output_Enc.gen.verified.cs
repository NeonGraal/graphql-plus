//HintName: test_constraint-parent-dual-grandparent+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-grandparent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Output;

internal class testCnstPrntDualGrndOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualGrndOutpObject>
{
  private readonly IEncoder<ItestRefCnstPrntDualGrndOutpObject<ItestAltCnstPrntDualGrndOutp>> _itestRefCnstPrntDualGrndOutp = encoders.EncoderFor<ItestRefCnstPrntDualGrndOutpObject<ItestAltCnstPrntDualGrndOutp>>();
  public Structured Encode(ItestCnstPrntDualGrndOutpObject input)
    => _itestRefCnstPrntDualGrndOutp.Encode(input);

  internal static testCnstPrntDualGrndOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntDualGrndOutpEncoder<TRef> : IEncoder<ItestRefCnstPrntDualGrndOutpObject<TRef>>
{
  public Structured Encode(ItestRefCnstPrntDualGrndOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testGrndCnstPrntDualGrndOutpEncoder : IEncoder<ItestGrndCnstPrntDualGrndOutpObject>
{
  public Structured Encode(ItestGrndCnstPrntDualGrndOutpObject input)
    => Structured.Empty();

  internal static testGrndCnstPrntDualGrndOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntCnstPrntDualGrndOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntCnstPrntDualGrndOutpObject>
{
  private readonly IEncoder<ItestGrndCnstPrntDualGrndOutpObject> _itestGrndCnstPrntDualGrndOutp = encoders.EncoderFor<ItestGrndCnstPrntDualGrndOutpObject>();
  public Structured Encode(ItestPrntCnstPrntDualGrndOutpObject input)
    => _itestGrndCnstPrntDualGrndOutp.Encode(input);

  internal static testPrntCnstPrntDualGrndOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testAltCnstPrntDualGrndOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualGrndOutpObject>
{
  private readonly IEncoder<ItestPrntCnstPrntDualGrndOutpObject> _itestPrntCnstPrntDualGrndOutp = encoders.EncoderFor<ItestPrntCnstPrntDualGrndOutpObject>();
  public Structured Encode(ItestAltCnstPrntDualGrndOutpObject input)
    => _itestPrntCnstPrntDualGrndOutp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstPrntDualGrndOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_constraint_parent_dual_grandparent_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_parent_dual_grandparent_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstPrntDualGrndOutpObject>(testCnstPrntDualGrndOutpEncoder.Factory)
      .AddEncoder<ItestGrndCnstPrntDualGrndOutpObject>(testGrndCnstPrntDualGrndOutpEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntDualGrndOutpObject>(testPrntCnstPrntDualGrndOutpEncoder.Factory)
      .AddEncoder<ItestAltCnstPrntDualGrndOutpObject>(testAltCnstPrntDualGrndOutpEncoder.Factory);
}
