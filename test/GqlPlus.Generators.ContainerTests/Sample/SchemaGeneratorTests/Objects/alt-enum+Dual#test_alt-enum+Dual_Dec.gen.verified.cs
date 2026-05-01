//HintName: test_alt-enum+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}alt-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_enum_Dual;

internal class testAltEnumDualDecoder : IDecoder<ItestAltEnumDualObject>
{

  public IMessages Decode(IValue input, out ItestAltEnumDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumAltEnumDualDecoder : IDecoder<testEnumAltEnumDual?>
{
  public IMessages Decode(IValue input, out testEnumAltEnumDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumAltEnumDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumAltEnumDual".AnError();
  }

  internal static testEnumAltEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_alt_enum_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_enum_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltEnumDualObject>(testAltEnumDualDecoder.Factory)
      .AddDecoder<testEnumAltEnumDual?>(testEnumAltEnumDualDecoder.Factory);
}
