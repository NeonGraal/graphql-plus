//HintName: test_field-enum+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Dual;

internal class testFieldEnumDualDecoder : IDecoder<ItestFieldEnumDualObject>
{
  public testEnumFieldEnumDual? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldEnumDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldEnumDualDecoder : IDecoder<testEnumFieldEnumDual?>
{
  public IMessages Decode(IValue input, out testEnumFieldEnumDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldEnumDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldEnumDual".AnError();
  }

  internal static testEnumFieldEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_enum_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_enum_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldEnumDualObject>(testFieldEnumDualDecoder.Factory)
      .AddDecoder<testEnumFieldEnumDual?>(testEnumFieldEnumDualDecoder.Factory);
}
