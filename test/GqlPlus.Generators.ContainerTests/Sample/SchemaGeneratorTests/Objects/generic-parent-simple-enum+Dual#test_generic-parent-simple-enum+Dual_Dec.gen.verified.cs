//HintName: test_generic-parent-simple-enum+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-simple-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Dual;

internal class testGnrcPrntSmplEnumDualDecoder : IDecoder<ItestGnrcPrntSmplEnumDualObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntSmplEnumDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntSmplEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntSmplEnumDualDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testEnumGnrcPrntSmplEnumDualDecoder : IDecoder<testEnumGnrcPrntSmplEnumDual?>
{
  public IMessages Decode(IValue input, out testEnumGnrcPrntSmplEnumDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcPrntSmplEnumDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcPrntSmplEnumDual".AnError();
  }

  internal static testEnumGnrcPrntSmplEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_simple_enum_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_simple_enum_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntSmplEnumDualObject>(testGnrcPrntSmplEnumDualDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntSmplEnumDual?>(testEnumGnrcPrntSmplEnumDualDecoder.Factory);
}
