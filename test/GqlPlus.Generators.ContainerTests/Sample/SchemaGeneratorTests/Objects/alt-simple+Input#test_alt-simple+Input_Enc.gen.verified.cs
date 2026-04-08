//HintName: test_alt-simple+Input_Enc.gen.cs
// Generated from {CurrentDirectory}alt-simple+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_simple_Input;

public class testAltSmplInp
  : GqlpEncoderBase
  , ItestAltSmplInp
{
  public string? AsString { get; set; }
  public ItestAltSmplInpObject? As_AltSmplInp { get; set; }
}

public class testAltSmplInpObject
  : GqlpEncoderBase
  , ItestAltSmplInpObject
{

  public testAltSmplInpObject
    ()
  {
  }
}
