//HintName: test_constraint-field-obj+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-field-obj+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Dual;

internal class testCnstFieldObjDualDecoder : IDecoder<ItestCnstFieldObjDualObject>
{

  public IMessages Decode(IValue input, out ItestCnstFieldObjDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstFieldObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstFieldObjDualDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testPrntCnstFieldObjDualDecoder : IDecoder<ItestPrntCnstFieldObjDualObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstFieldObjDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstFieldObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstFieldObjDualDecoder : IDecoder<ItestAltCnstFieldObjDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltCnstFieldObjDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltCnstFieldObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_field_obj_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_field_obj_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstFieldObjDualObject>(testCnstFieldObjDualDecoder.Factory)
      .AddDecoder<ItestPrntCnstFieldObjDualObject>(testPrntCnstFieldObjDualDecoder.Factory)
      .AddDecoder<ItestAltCnstFieldObjDualObject>(testAltCnstFieldObjDualDecoder.Factory);
}
