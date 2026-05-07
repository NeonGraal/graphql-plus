//HintName: test_constraint-alt-dual+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Input;

internal class testCnstAltDualInpEncoder : IEncoder<ItestCnstAltDualInpObject>
{
  public Structured Encode(ItestCnstAltDualInpObject input)
    => Structured.Empty();

  internal static testCnstAltDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltDualInpEncoder<TRef> : IEncoder<ItestRefCnstAltDualInpObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltDualInpObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstAltDualInpEncoder : IEncoder<ItestPrntCnstAltDualInpObject>
{
  public Structured Encode(ItestPrntCnstAltDualInpObject input)
    => Structured.Empty();

  internal static testPrntCnstAltDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstAltDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltDualInpObject>
{
  private readonly IEncoder<ItestPrntCnstAltDualInpObject> _itestPrntCnstAltDualInp = encoders.EncoderFor<ItestPrntCnstAltDualInpObject>();
  public Structured Encode(ItestAltCnstAltDualInpObject input)
    => _itestPrntCnstAltDualInp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstAltDualInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_constraint_alt_dual_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_alt_dual_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstAltDualInpObject>(testCnstAltDualInpEncoder.Factory)
      .AddEncoder<ItestPrntCnstAltDualInpObject>(testPrntCnstAltDualInpEncoder.Factory)
      .AddEncoder<ItestAltCnstAltDualInpObject>(testAltCnstAltDualInpEncoder.Factory);
}
