//HintName: test_constraint-dom-enum+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Output;

internal class testEnumCnstDomEnumOutpDecoder : IDecoder<testEnumCnstDomEnumOutp?>
{
  public IMessages Decoder(IValue input, out testEnumCnstDomEnumOutp? output)
    => input.DecodeEnum("EnumCnstDomEnumOutp", out output);

  internal static testEnumCnstDomEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testJustCnstDomEnumOutpDecoder
{

  internal static testJustCnstDomEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_dom_enum_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_dom_enum_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumCnstDomEnumOutp?>(testEnumCnstDomEnumOutpDecoder.Factory)
      .AddDecoder<ItestJustCnstDomEnumOutp>(testJustCnstDomEnumOutpDecoder.Factory);
}
