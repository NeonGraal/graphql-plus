//HintName: test_constraint-alt-dual+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Input;

internal class testCnstAltDualInpDecoder : IDecoder<ItestCnstAltDualInpObject>
{

  public IMessages Decode(IValue input, out ItestCnstAltDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstAltDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstAltDualInpDecoder<TRef>
{
}

internal class testPrntCnstAltDualInpDecoder : IDecoder<ItestPrntCnstAltDualInpObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstAltDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstAltDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstAltDualInpDecoder : IDecoder<ItestAltCnstAltDualInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltCnstAltDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltCnstAltDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_alt_dual_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_alt_dual_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstAltDualInpObject>(testCnstAltDualInpDecoder.Factory)
      .AddDecoder<ItestPrntCnstAltDualInpObject>(testPrntCnstAltDualInpDecoder.Factory)
      .AddDecoder<ItestAltCnstAltDualInpObject>(testAltCnstAltDualInpDecoder.Factory);
}
