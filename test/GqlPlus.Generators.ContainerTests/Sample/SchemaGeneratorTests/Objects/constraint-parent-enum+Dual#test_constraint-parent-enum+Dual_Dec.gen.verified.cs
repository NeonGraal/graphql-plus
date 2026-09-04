//HintName: test_constraint-parent-enum+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Dual;

internal class testCnstPrntEnumDualDecoder : NullDecoder<ItestCnstPrntEnumDualObject>
{

  internal static testCnstPrntEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntEnumDualDecoder<TType>
{
  public TType Field { get; set; } = default!;
}

internal class testEnumCnstPrntEnumDualDecoder : NullDecoder<testEnumCnstPrntEnumDual>
{
  public string parentCnstPrntEnumDual { get; set; } = default!;
  public string cnstPrntEnumDual { get; set; } = default!;

  internal static testEnumCnstPrntEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentCnstPrntEnumDualDecoder : NullDecoder<testParentCnstPrntEnumDual>
{
  public string parentCnstPrntEnumDual { get; set; } = default!;

  internal static testParentCnstPrntEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_parent_enum_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_parent_enum_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstPrntEnumDualObject>(testCnstPrntEnumDualDecoder.Factory)
      .AddDecoder<testEnumCnstPrntEnumDual>(testEnumCnstPrntEnumDualDecoder.Factory)
      .AddDecoder<testParentCnstPrntEnumDual>(testParentCnstPrntEnumDualDecoder.Factory);
}
