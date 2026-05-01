//HintName: test_generic-parent-enum-child+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-child+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Output;

internal class testEnumGnrcPrntEnumChildOutpDecoder : IDecoder<testEnumGnrcPrntEnumChildOutp?>
{
  public IMessages Decode(IValue input, out testEnumGnrcPrntEnumChildOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcPrntEnumChildOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcPrntEnumChildOutp".AnError();
  }

  internal static testEnumGnrcPrntEnumChildOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentGnrcPrntEnumChildOutpDecoder : IDecoder<testParentGnrcPrntEnumChildOutp?>
{
  public IMessages Decode(IValue input, out testParentGnrcPrntEnumChildOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testParentGnrcPrntEnumChildOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testParentGnrcPrntEnumChildOutp".AnError();
  }

  internal static testParentGnrcPrntEnumChildOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_enum_child_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_enum_child_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumGnrcPrntEnumChildOutp?>(testEnumGnrcPrntEnumChildOutpDecoder.Factory)
      .AddDecoder<testParentGnrcPrntEnumChildOutp?>(testParentGnrcPrntEnumChildOutpDecoder.Factory);
}
