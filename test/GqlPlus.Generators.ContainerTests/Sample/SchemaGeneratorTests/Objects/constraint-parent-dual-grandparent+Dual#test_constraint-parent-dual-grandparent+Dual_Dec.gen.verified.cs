//HintName: test_constraint-parent-dual-grandparent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-grandparent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Dual;

internal class testCnstPrntDualGrndDualDecoder : IDecoder<ItestCnstPrntDualGrndDualObject>
{

  public IMessages Decode(IValue input, out ItestCnstPrntDualGrndDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstPrntDualGrndDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntDualGrndDualDecoder<TRef>
{
}

internal class testGrndCnstPrntDualGrndDualDecoder : IDecoder<ItestGrndCnstPrntDualGrndDualObject>
{

  public IMessages Decode(IValue input, out ItestGrndCnstPrntDualGrndDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGrndCnstPrntDualGrndDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntCnstPrntDualGrndDualDecoder : IDecoder<ItestPrntCnstPrntDualGrndDualObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstPrntDualGrndDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstPrntDualGrndDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstPrntDualGrndDualDecoder : IDecoder<ItestAltCnstPrntDualGrndDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltCnstPrntDualGrndDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltCnstPrntDualGrndDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_parent_dual_grandparent_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_parent_dual_grandparent_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstPrntDualGrndDualObject>(testCnstPrntDualGrndDualDecoder.Factory)
      .AddDecoder<ItestGrndCnstPrntDualGrndDualObject>(testGrndCnstPrntDualGrndDualDecoder.Factory)
      .AddDecoder<ItestPrntCnstPrntDualGrndDualObject>(testPrntCnstPrntDualGrndDualDecoder.Factory)
      .AddDecoder<ItestAltCnstPrntDualGrndDualObject>(testAltCnstPrntDualGrndDualDecoder.Factory);
}
