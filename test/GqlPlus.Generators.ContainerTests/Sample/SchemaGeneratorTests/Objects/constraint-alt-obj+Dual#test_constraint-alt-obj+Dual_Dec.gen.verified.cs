//HintName: test_constraint-alt-obj+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Dual;

internal class testCnstAltObjDualDecoder : IDecoder<ItestCnstAltObjDualObject>
{

  public IMessages Decode(IValue input, out ItestCnstAltObjDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstAltObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstAltObjDualDecoder<TRef>
{
}

internal class testPrntCnstAltObjDualDecoder : IDecoder<ItestPrntCnstAltObjDualObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstAltObjDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstAltObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstAltObjDualDecoder : IDecoder<ItestAltCnstAltObjDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltCnstAltObjDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltCnstAltObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_alt_obj_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_alt_obj_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstAltObjDualObject>(testCnstAltObjDualDecoder.Factory)
      .AddDecoder<ItestPrntCnstAltObjDualObject>(testPrntCnstAltObjDualDecoder.Factory)
      .AddDecoder<ItestAltCnstAltObjDualObject>(testAltCnstAltObjDualDecoder.Factory);
}
