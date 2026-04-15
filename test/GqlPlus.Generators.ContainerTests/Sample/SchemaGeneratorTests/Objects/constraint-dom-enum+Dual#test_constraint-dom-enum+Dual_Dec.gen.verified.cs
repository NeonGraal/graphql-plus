//HintName: test_constraint-dom-enum+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Dual;

internal class testCnstDomEnumDualDecoder
{
}

internal class testRefCnstDomEnumDualDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumCnstDomEnumDualDecoder
{
  public string cnstDomEnumDual { get; set; }
  public string other { get; set; }
}

internal class testJustCnstDomEnumDualDecoder
{
}

internal static class test_constraint_dom_enum_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_dom_enum_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstDomEnumDualObject>(_ => new testCnstDomEnumDualDecoder())
      .AddDecoder<testEnumCnstDomEnumDual>(_ => new testEnumCnstDomEnumDualDecoder())
      .AddDecoder<ItestJustCnstDomEnumDual>(_ => new testJustCnstDomEnumDualDecoder());
}
