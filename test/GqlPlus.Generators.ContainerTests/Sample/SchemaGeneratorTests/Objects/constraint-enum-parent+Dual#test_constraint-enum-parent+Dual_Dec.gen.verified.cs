//HintName: test_constraint-enum-parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Dual;

internal class testCnstEnumPrntDualDecoder : IDecoder<ItestCnstEnumPrntDualObject>
{

  public IMessages Decode(IValue input, out ItestCnstEnumPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstEnumPrntDualDecoder<TType>
{
  public TType? Field { get; set; }
}

internal class testEnumCnstEnumPrntDualDecoder : IDecoder<testEnumCnstEnumPrntDual?>
{
  public IMessages Decode(IValue input, out testEnumCnstEnumPrntDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumCnstEnumPrntDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumCnstEnumPrntDual".AnError();
  }

  internal static testEnumCnstEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentCnstEnumPrntDualDecoder : IDecoder<testParentCnstEnumPrntDual?>
{
  public IMessages Decode(IValue input, out testParentCnstEnumPrntDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testParentCnstEnumPrntDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testParentCnstEnumPrntDual".AnError();
  }

  internal static testParentCnstEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_enum_parent_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_enum_parent_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstEnumPrntDualObject>(testCnstEnumPrntDualDecoder.Factory)
      .AddDecoder<testEnumCnstEnumPrntDual?>(testEnumCnstEnumPrntDualDecoder.Factory)
      .AddDecoder<testParentCnstEnumPrntDual?>(testParentCnstEnumPrntDualDecoder.Factory);
}
