//HintName: test_constraint-alt-obj+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Dual;

internal class testCnstAltObjDualDecoder
{
}

internal class testRefCnstAltObjDualDecoder<TRef>
{
}

internal class testPrntCnstAltObjDualDecoder
{
}

internal class testAltCnstAltObjDualDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_constraint_alt_obj_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_alt_obj_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstAltObjDualObject>(_ => new testCnstAltObjDualDecoder())
      .AddDecoder<ItestPrntCnstAltObjDualObject>(_ => new testPrntCnstAltObjDualDecoder())
      .AddDecoder<ItestAltCnstAltObjDualObject>(r => new testAltCnstAltObjDualDecoder(r));
}
