//HintName: test_all_Dec.gen.cs
// Generated from {CurrentDirectory}all.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_all;

internal class testGuidDecoder
{
}

internal class testOneDecoder
{
  public string Two { get; set; }
  public string Three { get; set; }
}

internal class testManyDecoder
{
  public Guid AsGuid { get; set; }
  public Number AsNumber { get; set; }
}

internal class testFieldDecoder
{
  public ICollection<string> Strings { get; set; }
}

internal class testParamDecoder
{
  public ItestMany? AfterId { get; set; }
  public ItestMany BeforeId { get; set; }
}

internal class testAllDecoder
{
  public ItestField? Items(ItestParam? parameter)
    => null;
  public ItestField? Items()
    => null;
}
