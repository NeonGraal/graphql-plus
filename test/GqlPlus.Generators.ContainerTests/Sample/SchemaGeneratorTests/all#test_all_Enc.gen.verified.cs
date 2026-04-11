//HintName: test_all_Enc.gen.cs
// Generated from {CurrentDirectory}all.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_all;

internal class testGuidEncoder
{
}

internal class testOneEncoder
{
  public string Two { get; set; }
  public string Three { get; set; }
}

internal class testManyEncoder
{
  public Guid AsGuid { get; set; }
  public Number AsNumber { get; set; }
}

internal class testFieldEncoder
{
  public ICollection<string> Strings { get; set; }
}

internal class testParamEncoder
{
  public ItestMany? AfterId { get; set; }
  public ItestMany BeforeId { get; set; }
}

internal class testAllEncoder
{
  public ItestField? Items(ItestParam? parameter)
    => null;
}
