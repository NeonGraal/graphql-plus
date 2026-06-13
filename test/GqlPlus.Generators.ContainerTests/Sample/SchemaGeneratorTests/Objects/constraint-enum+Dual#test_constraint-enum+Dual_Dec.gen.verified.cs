//HintName: test_constraint-enum+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Dual;

internal class testCnstEnumDualDecoder : NullDecoder<ItestCnstEnumDualObject>
{

  internal static testCnstEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstEnumDualDecoder<TType>
{
  public TType Field { get; set; } = default!;
}

internal class testEnumCnstEnumDualDecoder : NullDecoder<testEnumCnstEnumDual>
{
  public string cnstEnumDual { get; set; } = default!;

  internal static testEnumCnstEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_enum_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_enum_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstEnumDualObject>(testCnstEnumDualDecoder.Factory)
      .AddDecoder<testEnumCnstEnumDual>(testEnumCnstEnumDualDecoder.Factory);
}
