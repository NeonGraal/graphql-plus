//HintName: test_generic-parent-enum-dom+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Input;

internal class testGnrcPrntEnumDomInpDecoder : IDecoder<ItestGnrcPrntEnumDomInpObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntEnumDomInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntEnumDomInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntEnumDomInpDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testEnumGnrcPrntEnumDomInpDecoder : IDecoder<testEnumGnrcPrntEnumDomInp?>
{
  public IMessages Decode(IValue input, out testEnumGnrcPrntEnumDomInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcPrntEnumDomInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcPrntEnumDomInp".AnError();
  }

  internal static testEnumGnrcPrntEnumDomInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testDomGnrcPrntEnumDomInpDecoder : IDecoder<ItestDomGnrcPrntEnumDomInp>
{
  public testEnumGnrcPrntEnumDomInp? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDomGnrcPrntEnumDomInp? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDomGnrcPrntEnumDomInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_enum_dom_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_enum_dom_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntEnumDomInpObject>(testGnrcPrntEnumDomInpDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntEnumDomInp?>(testEnumGnrcPrntEnumDomInpDecoder.Factory)
      .AddDecoder<ItestDomGnrcPrntEnumDomInp>(testDomGnrcPrntEnumDomInpDecoder.Factory);
}
