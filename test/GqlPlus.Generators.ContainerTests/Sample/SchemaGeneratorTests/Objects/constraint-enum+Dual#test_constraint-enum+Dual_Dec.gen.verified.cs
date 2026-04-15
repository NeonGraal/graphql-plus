//HintName: test_constraint-enum+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Dual;

internal class testCnstEnumDualDecoder
{
}

internal class testRefCnstEnumDualDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumCnstEnumDualDecoder
{
  public string cnstEnumDual { get; set; }
}

internal static class test_constraint_enum_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_enum_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstEnumDualObject>(_ => new testCnstEnumDualDecoder())
      .AddDecoder<testEnumCnstEnumDual>(_ => new testEnumCnstEnumDualDecoder());
}
