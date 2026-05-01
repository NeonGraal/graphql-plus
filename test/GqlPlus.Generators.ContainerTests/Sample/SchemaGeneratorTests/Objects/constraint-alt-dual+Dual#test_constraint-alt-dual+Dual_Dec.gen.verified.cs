//HintName: test_constraint-alt-dual+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Dual;

internal class testCnstAltDualDualDecoder : IDecoder<ItestCnstAltDualDualObject>
{

  public IMessages Decode(IValue input, out ItestCnstAltDualDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstAltDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstAltDualDualDecoder<TRef>
{
}

internal class testPrntCnstAltDualDualDecoder : IDecoder<ItestPrntCnstAltDualDualObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstAltDualDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstAltDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstAltDualDualDecoder : IDecoder<ItestAltCnstAltDualDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltCnstAltDualDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltCnstAltDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_alt_dual_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_alt_dual_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstAltDualDualObject>(testCnstAltDualDualDecoder.Factory)
      .AddDecoder<ItestPrntCnstAltDualDualObject>(testPrntCnstAltDualDualDecoder.Factory)
      .AddDecoder<ItestAltCnstAltDualDualObject>(testAltCnstAltDualDualDecoder.Factory);
}
