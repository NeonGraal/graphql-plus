//HintName: test_constraint-dom-enum+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Input;

internal class testCnstDomEnumInpDecoder : IDecoder<ItestCnstDomEnumInpObject>
{

  public IMessages Decode(IValue input, out ItestCnstDomEnumInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstDomEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstDomEnumInpDecoder<TType>
{
  public TType? Field { get; set; }
}

internal class testEnumCnstDomEnumInpDecoder : IDecoder<testEnumCnstDomEnumInp?>
{
  public IMessages Decode(IValue input, out testEnumCnstDomEnumInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumCnstDomEnumInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumCnstDomEnumInp".AnError();
  }

  internal static testEnumCnstDomEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testJustCnstDomEnumInpDecoder : IDecoder<ItestJustCnstDomEnumInp>
{
  public testEnumCnstDomEnumInp? Value { get; set; }

  public IMessages Decode(IValue input, out ItestJustCnstDomEnumInp? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testJustCnstDomEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_dom_enum_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_dom_enum_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstDomEnumInpObject>(testCnstDomEnumInpDecoder.Factory)
      .AddDecoder<testEnumCnstDomEnumInp?>(testEnumCnstDomEnumInpDecoder.Factory)
      .AddDecoder<ItestJustCnstDomEnumInp>(testJustCnstDomEnumInpDecoder.Factory);
}
