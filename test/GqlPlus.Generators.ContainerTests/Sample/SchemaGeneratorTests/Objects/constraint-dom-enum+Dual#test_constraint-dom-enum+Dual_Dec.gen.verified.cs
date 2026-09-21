//HintName: test_constraint-dom-enum+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Dual;

internal class testCnstDomEnumDualDecoder : NullDecoder<ItestCnstDomEnumDualObject>
{

  internal static testCnstDomEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstDomEnumDualDecoder<TType>
{
  public TType Field { get; set; } = default!;
}

internal class testEnumCnstDomEnumDualDecoder : NullDecoder<testEnumCnstDomEnumDual>
{
  public string cnstDomEnumDual { get; set; } = default!;
  public string other { get; set; } = default!;

  internal static testEnumCnstDomEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testJustCnstDomEnumDualDecoder : NullDecoder<ItestJustCnstDomEnumDual>
{

  internal static testJustCnstDomEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_dom_enum_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_dom_enum_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstDomEnumDualObject>(testCnstDomEnumDualDecoder.Factory)
      .AddDecoder<testEnumCnstDomEnumDual>(testEnumCnstDomEnumDualDecoder.Factory)
      .AddDecoder<ItestJustCnstDomEnumDual>(testJustCnstDomEnumDualDecoder.Factory);
}
