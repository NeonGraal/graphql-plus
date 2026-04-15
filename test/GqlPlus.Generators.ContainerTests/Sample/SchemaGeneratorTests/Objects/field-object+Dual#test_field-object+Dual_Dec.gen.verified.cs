//HintName: test_field-object+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-object+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Dual;

internal class testFieldObjDualDecoder
{
  public ItestFldFieldObjDual Field { get; set; }
}

internal class testFldFieldObjDualDecoder
{
  public decimal Field { get; set; }
}

internal static class test_field_object_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_object_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldObjDualObject>(_ => new testFieldObjDualDecoder())
      .AddDecoder<ItestFldFieldObjDualObject>(_ => new testFldFieldObjDualDecoder());
}
