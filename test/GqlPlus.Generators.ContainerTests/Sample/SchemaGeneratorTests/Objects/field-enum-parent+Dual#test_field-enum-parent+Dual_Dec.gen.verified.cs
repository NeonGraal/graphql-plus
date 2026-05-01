//HintName: test_field-enum-parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Dual;

internal class testFieldEnumPrntDualDecoder : IDecoder<ItestFieldEnumPrntDualObject>
{
  public testEnumFieldEnumPrntDual? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldEnumPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldEnumPrntDualDecoder : IDecoder<testEnumFieldEnumPrntDual?>
{
  public IMessages Decode(IValue input, out testEnumFieldEnumPrntDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldEnumPrntDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldEnumPrntDual".AnError();
  }

  internal static testEnumFieldEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntFieldEnumPrntDualDecoder : IDecoder<testPrntFieldEnumPrntDual?>
{
  public IMessages Decode(IValue input, out testPrntFieldEnumPrntDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntFieldEnumPrntDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntFieldEnumPrntDual".AnError();
  }

  internal static testPrntFieldEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_enum_parent_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_enum_parent_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldEnumPrntDualObject>(testFieldEnumPrntDualDecoder.Factory)
      .AddDecoder<testEnumFieldEnumPrntDual?>(testEnumFieldEnumPrntDualDecoder.Factory)
      .AddDecoder<testPrntFieldEnumPrntDual?>(testPrntFieldEnumPrntDualDecoder.Factory);
}
