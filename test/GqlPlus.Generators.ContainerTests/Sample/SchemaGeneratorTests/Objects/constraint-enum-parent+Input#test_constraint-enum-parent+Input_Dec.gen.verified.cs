//HintName: test_constraint-enum-parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Input;

internal class testCnstEnumPrntInpDecoder : IDecoder<ItestCnstEnumPrntInpObject>
{

  public IMessages Decode(IValue input, out ItestCnstEnumPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstEnumPrntInpDecoder<TType>
{
  public TType? Field { get; set; }
}

internal class testEnumCnstEnumPrntInpDecoder : IDecoder<testEnumCnstEnumPrntInp?>
{
  public IMessages Decode(IValue input, out testEnumCnstEnumPrntInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumCnstEnumPrntInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumCnstEnumPrntInp".AnError();
  }

  internal static testEnumCnstEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentCnstEnumPrntInpDecoder : IDecoder<testParentCnstEnumPrntInp?>
{
  public IMessages Decode(IValue input, out testParentCnstEnumPrntInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testParentCnstEnumPrntInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testParentCnstEnumPrntInp".AnError();
  }

  internal static testParentCnstEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_enum_parent_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_enum_parent_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstEnumPrntInpObject>(testCnstEnumPrntInpDecoder.Factory)
      .AddDecoder<testEnumCnstEnumPrntInp?>(testEnumCnstEnumPrntInpDecoder.Factory)
      .AddDecoder<testParentCnstEnumPrntInp?>(testParentCnstEnumPrntInpDecoder.Factory);
}
