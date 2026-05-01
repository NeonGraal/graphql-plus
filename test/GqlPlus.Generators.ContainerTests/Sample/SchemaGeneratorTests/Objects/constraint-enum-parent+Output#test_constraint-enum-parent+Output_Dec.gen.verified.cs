//HintName: test_constraint-enum-parent+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Output;

internal class testEnumCnstEnumPrntOutpDecoder : IDecoder<testEnumCnstEnumPrntOutp?>
{
  public IMessages Decode(IValue input, out testEnumCnstEnumPrntOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumCnstEnumPrntOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumCnstEnumPrntOutp".AnError();
  }

  internal static testEnumCnstEnumPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentCnstEnumPrntOutpDecoder : IDecoder<testParentCnstEnumPrntOutp?>
{
  public IMessages Decode(IValue input, out testParentCnstEnumPrntOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testParentCnstEnumPrntOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testParentCnstEnumPrntOutp".AnError();
  }

  internal static testParentCnstEnumPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_enum_parent_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_enum_parent_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumCnstEnumPrntOutp?>(testEnumCnstEnumPrntOutpDecoder.Factory)
      .AddDecoder<testParentCnstEnumPrntOutp?>(testParentCnstEnumPrntOutpDecoder.Factory);
}
