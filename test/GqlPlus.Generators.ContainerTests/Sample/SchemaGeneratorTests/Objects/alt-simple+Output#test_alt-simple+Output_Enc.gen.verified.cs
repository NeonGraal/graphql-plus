//HintName: test_alt-simple+Output_Enc.gen.cs
// Generated from {CurrentDirectory}alt-simple+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_simple_Output;

public class testAltSmplOutp
  : GqlpEncoderBase
  , ItestAltSmplOutp
{
  public string? AsString { get; set; }
  public ItestAltSmplOutpObject? As_AltSmplOutp { get; set; }
}

public class testAltSmplOutpObject
  : GqlpEncoderBase
  , ItestAltSmplOutpObject
{

  public testAltSmplOutpObject
    ()
  {
  }
}
