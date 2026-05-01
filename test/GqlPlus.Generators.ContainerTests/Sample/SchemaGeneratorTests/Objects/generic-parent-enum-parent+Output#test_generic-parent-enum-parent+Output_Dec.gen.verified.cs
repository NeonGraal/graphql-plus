//HintName: test_generic-parent-enum-parent+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Output;

internal class testEnumGnrcPrntEnumPrntOutpDecoder : IDecoder<testEnumGnrcPrntEnumPrntOutp?>
{
  public IMessages Decode(IValue input, out testEnumGnrcPrntEnumPrntOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcPrntEnumPrntOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcPrntEnumPrntOutp".AnError();
  }

  internal static testEnumGnrcPrntEnumPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentGnrcPrntEnumPrntOutpDecoder : IDecoder<testParentGnrcPrntEnumPrntOutp?>
{
  public IMessages Decode(IValue input, out testParentGnrcPrntEnumPrntOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testParentGnrcPrntEnumPrntOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testParentGnrcPrntEnumPrntOutp".AnError();
  }

  internal static testParentGnrcPrntEnumPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_enum_parent_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_enum_parent_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumGnrcPrntEnumPrntOutp?>(testEnumGnrcPrntEnumPrntOutpDecoder.Factory)
      .AddDecoder<testParentGnrcPrntEnumPrntOutp?>(testParentGnrcPrntEnumPrntOutpDecoder.Factory);
}
