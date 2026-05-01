//HintName: test_field-mod-Enum+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-mod-Enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_Enum_Dual;

internal class testFieldModEnumDualDecoder : IDecoder<ItestFieldModEnumDualObject>
{
  public IDictionary<testEnumFieldModEnumDual, string>? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldModEnumDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldModEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldModEnumDualDecoder : IDecoder<testEnumFieldModEnumDual?>
{
  public IMessages Decode(IValue input, out testEnumFieldModEnumDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldModEnumDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldModEnumDual".AnError();
  }

  internal static testEnumFieldModEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_mod_Enum_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_mod_Enum_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldModEnumDualObject>(testFieldModEnumDualDecoder.Factory)
      .AddDecoder<testEnumFieldModEnumDual?>(testEnumFieldModEnumDualDecoder.Factory);
}
