//HintName: test_generic-parent-simple-enum+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-simple-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Output;

internal class testEnumGnrcPrntSmplEnumOutpDecoder : IDecoder<testEnumGnrcPrntSmplEnumOutp?>
{
  public IMessages Decode(IValue input, out testEnumGnrcPrntSmplEnumOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcPrntSmplEnumOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcPrntSmplEnumOutp".AnError();
  }

  internal static testEnumGnrcPrntSmplEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_simple_enum_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_simple_enum_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumGnrcPrntSmplEnumOutp?>(testEnumGnrcPrntSmplEnumOutpDecoder.Factory);
}
