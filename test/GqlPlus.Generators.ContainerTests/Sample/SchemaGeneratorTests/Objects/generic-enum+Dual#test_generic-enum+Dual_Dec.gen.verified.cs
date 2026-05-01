//HintName: test_generic-enum+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Dual;

internal class testGnrcEnumDualDecoder : IDecoder<ItestGnrcEnumDualObject>
{

  public IMessages Decode(IValue input, out ItestGnrcEnumDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcEnumDualDecoder<TType>
{
  public TType? Field { get; set; }
}

internal class testEnumGnrcEnumDualDecoder : IDecoder<testEnumGnrcEnumDual?>
{
  public IMessages Decode(IValue input, out testEnumGnrcEnumDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcEnumDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcEnumDual".AnError();
  }

  internal static testEnumGnrcEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_enum_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_enum_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcEnumDualObject>(testGnrcEnumDualDecoder.Factory)
      .AddDecoder<testEnumGnrcEnumDual?>(testEnumGnrcEnumDualDecoder.Factory);
}
