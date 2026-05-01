//HintName: test_constraint-dom-enum+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Output;

internal class testEnumCnstDomEnumOutpDecoder : IDecoder<testEnumCnstDomEnumOutp?>
{
  public IMessages Decode(IValue input, out testEnumCnstDomEnumOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumCnstDomEnumOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumCnstDomEnumOutp".AnError();
  }

  internal static testEnumCnstDomEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testJustCnstDomEnumOutpDecoder : IDecoder<ItestJustCnstDomEnumOutp>
{
  public testEnumCnstDomEnumOutp? Value { get; set; }

  public IMessages Decode(IValue input, out ItestJustCnstDomEnumOutp? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testJustCnstDomEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_dom_enum_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_dom_enum_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumCnstDomEnumOutp?>(testEnumCnstDomEnumOutpDecoder.Factory)
      .AddDecoder<ItestJustCnstDomEnumOutp>(testJustCnstDomEnumOutpDecoder.Factory);
}
