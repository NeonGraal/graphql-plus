//HintName: test_field-mod-Enum+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-mod-Enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_Enum_Input;

internal class testFieldModEnumInpDecoder : IDecoder<ItestFieldModEnumInpObject>
{
  public IDictionary<testEnumFieldModEnumInp, string>? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldModEnumInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldModEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldModEnumInpDecoder : IDecoder<testEnumFieldModEnumInp?>
{
  public IMessages Decode(IValue input, out testEnumFieldModEnumInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldModEnumInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldModEnumInp".AnError();
  }

  internal static testEnumFieldModEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_mod_Enum_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_mod_Enum_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldModEnumInpObject>(testFieldModEnumInpDecoder.Factory)
      .AddDecoder<testEnumFieldModEnumInp?>(testEnumFieldModEnumInpDecoder.Factory);
}
