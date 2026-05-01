//HintName: test_generic-value+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-value+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Output;

internal class testEnumGnrcValueOutpDecoder : IDecoder<testEnumGnrcValueOutp?>
{
  public IMessages Decode(IValue input, out testEnumGnrcValueOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcValueOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcValueOutp".AnError();
  }

  internal static testEnumGnrcValueOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_value_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_value_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumGnrcValueOutp?>(testEnumGnrcValueOutpDecoder.Factory);
}
