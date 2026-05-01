//HintName: test_generic-parent-enum-dom+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Dual;

internal class testGnrcPrntEnumDomDualDecoder : IDecoder<ItestGnrcPrntEnumDomDualObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntEnumDomDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntEnumDomDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntEnumDomDualDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testEnumGnrcPrntEnumDomDualDecoder : IDecoder<testEnumGnrcPrntEnumDomDual?>
{
  public IMessages Decode(IValue input, out testEnumGnrcPrntEnumDomDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcPrntEnumDomDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcPrntEnumDomDual".AnError();
  }

  internal static testEnumGnrcPrntEnumDomDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testDomGnrcPrntEnumDomDualDecoder : IDecoder<ItestDomGnrcPrntEnumDomDual>
{
  public testEnumGnrcPrntEnumDomDual? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDomGnrcPrntEnumDomDual? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDomGnrcPrntEnumDomDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_enum_dom_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_enum_dom_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntEnumDomDualObject>(testGnrcPrntEnumDomDualDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntEnumDomDual?>(testEnumGnrcPrntEnumDomDualDecoder.Factory)
      .AddDecoder<ItestDomGnrcPrntEnumDomDual>(testDomGnrcPrntEnumDomDualDecoder.Factory);
}
