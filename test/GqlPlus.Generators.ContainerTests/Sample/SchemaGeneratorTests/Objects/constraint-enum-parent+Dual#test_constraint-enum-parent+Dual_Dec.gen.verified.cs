//HintName: test_constraint-enum-parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Dual;

internal class testCnstEnumPrntDualDecoder
{
}

internal class testRefCnstEnumPrntDualDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumCnstEnumPrntDualDecoder
{
  public string parentCnstEnumPrntDual { get; set; }
  public string cnstEnumPrntDual { get; set; }
}

internal class testParentCnstEnumPrntDualDecoder
{
  public string parentCnstEnumPrntDual { get; set; }
}

internal static class test_constraint_enum_parent_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_enum_parent_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstEnumPrntDualObject>(_ => new testCnstEnumPrntDualDecoder())
      .AddDecoder<testEnumCnstEnumPrntDual>(_ => new testEnumCnstEnumPrntDualDecoder())
      .AddDecoder<testParentCnstEnumPrntDual>(_ => new testParentCnstEnumPrntDualDecoder());
}
