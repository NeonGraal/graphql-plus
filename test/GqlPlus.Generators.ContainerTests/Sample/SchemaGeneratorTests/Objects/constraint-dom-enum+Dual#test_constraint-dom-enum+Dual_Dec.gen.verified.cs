//HintName: test_constraint-dom-enum+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Dual;

internal class testCnstDomEnumDualDecoder : IDecoder<ItestCnstDomEnumDualObject>
{

  public IMessages Decode(IValue input, out ItestCnstDomEnumDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstDomEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstDomEnumDualDecoder<TType>
{
  public TType? Field { get; set; }
}

internal class testEnumCnstDomEnumDualDecoder : IDecoder<testEnumCnstDomEnumDual?>
{
  public IMessages Decode(IValue input, out testEnumCnstDomEnumDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumCnstDomEnumDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumCnstDomEnumDual".AnError();
  }

  internal static testEnumCnstDomEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testJustCnstDomEnumDualDecoder : IDecoder<ItestJustCnstDomEnumDual>
{
  public testEnumCnstDomEnumDual? Value { get; set; }

  public IMessages Decode(IValue input, out ItestJustCnstDomEnumDual? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testJustCnstDomEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_dom_enum_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_dom_enum_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstDomEnumDualObject>(testCnstDomEnumDualDecoder.Factory)
      .AddDecoder<testEnumCnstDomEnumDual?>(testEnumCnstDomEnumDualDecoder.Factory)
      .AddDecoder<ItestJustCnstDomEnumDual>(testJustCnstDomEnumDualDecoder.Factory);
}
