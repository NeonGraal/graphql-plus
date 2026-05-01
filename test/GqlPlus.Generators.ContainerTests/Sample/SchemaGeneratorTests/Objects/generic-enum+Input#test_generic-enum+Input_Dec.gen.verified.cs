//HintName: test_generic-enum+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Input;

internal class testGnrcEnumInpDecoder : IDecoder<ItestGnrcEnumInpObject>
{

  public IMessages Decode(IValue input, out ItestGnrcEnumInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcEnumInpDecoder<TType>
{
  public TType? Field { get; set; }
}

internal class testEnumGnrcEnumInpDecoder : IDecoder<testEnumGnrcEnumInp?>
{
  public IMessages Decode(IValue input, out testEnumGnrcEnumInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcEnumInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcEnumInp".AnError();
  }

  internal static testEnumGnrcEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_enum_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_enum_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcEnumInpObject>(testGnrcEnumInpDecoder.Factory)
      .AddDecoder<testEnumGnrcEnumInp?>(testEnumGnrcEnumInpDecoder.Factory);
}
