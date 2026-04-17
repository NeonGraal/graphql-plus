//HintName: test_constraint-field-dual+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Dual;

internal class testCnstFieldDualDualDecoder
{

  internal static testCnstFieldDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstFieldDualDualDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testPrntCnstFieldDualDualDecoder
{

  internal static testPrntCnstFieldDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstFieldDualDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltCnstFieldDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_field_dual_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_field_dual_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstFieldDualDualObject>(testCnstFieldDualDualDecoder.Factory)
      .AddDecoder<ItestPrntCnstFieldDualDualObject>(testPrntCnstFieldDualDualDecoder.Factory)
      .AddDecoder<ItestAltCnstFieldDualDualObject>(testAltCnstFieldDualDualDecoder.Factory);
}
