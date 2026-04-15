//HintName: test_constraint-dom-enum+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Input;

internal class testCnstDomEnumInpDecoder
{
}

internal class testRefCnstDomEnumInpDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumCnstDomEnumInpDecoder
{
  public string cnstDomEnumInp { get; set; }
  public string other { get; set; }
}

internal class testJustCnstDomEnumInpDecoder
{
}

internal static class test_constraint_dom_enum_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_dom_enum_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstDomEnumInpObject>(_ => new testCnstDomEnumInpDecoder())
      .AddDecoder<testEnumCnstDomEnumInp>(_ => new testEnumCnstDomEnumInpDecoder())
      .AddDecoder<ItestJustCnstDomEnumInp>(_ => new testJustCnstDomEnumInpDecoder());
}
