//HintName: test_constraint-field-obj+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-field-obj+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Dual;

internal class testCnstFieldObjDualDecoder
{
}

internal class testRefCnstFieldObjDualDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testPrntCnstFieldObjDualDecoder
{
}

internal class testAltCnstFieldObjDualDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_constraint_field_obj_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_field_obj_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstFieldObjDualObject>(_ => new testCnstFieldObjDualDecoder())
      .AddDecoder<ItestPrntCnstFieldObjDualObject>(_ => new testPrntCnstFieldObjDualDecoder())
      .AddDecoder<ItestAltCnstFieldObjDualObject>(_ => new testAltCnstFieldObjDualDecoder());
}
