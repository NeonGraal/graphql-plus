//HintName: test_generic-parent-enum-child+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-child+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Input;

internal class testGnrcPrntEnumChildInpDecoder : IDecoder<ItestGnrcPrntEnumChildInpObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntEnumChildInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntEnumChildInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntEnumChildInpDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testEnumGnrcPrntEnumChildInpDecoder : IDecoder<testEnumGnrcPrntEnumChildInp?>
{
  public IMessages Decode(IValue input, out testEnumGnrcPrntEnumChildInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcPrntEnumChildInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcPrntEnumChildInp".AnError();
  }

  internal static testEnumGnrcPrntEnumChildInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentGnrcPrntEnumChildInpDecoder : IDecoder<testParentGnrcPrntEnumChildInp?>
{
  public IMessages Decode(IValue input, out testParentGnrcPrntEnumChildInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testParentGnrcPrntEnumChildInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testParentGnrcPrntEnumChildInp".AnError();
  }

  internal static testParentGnrcPrntEnumChildInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_enum_child_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_enum_child_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntEnumChildInpObject>(testGnrcPrntEnumChildInpDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntEnumChildInp?>(testEnumGnrcPrntEnumChildInpDecoder.Factory)
      .AddDecoder<testParentGnrcPrntEnumChildInp?>(testParentGnrcPrntEnumChildInpDecoder.Factory);
}
