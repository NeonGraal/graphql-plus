//HintName: test_alt+Input_Enc.gen.cs
// Generated from {CurrentDirectory}alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Input;

public class testAltInp
  : GqlpEncoderBase
  , ItestAltInp
{
  public ItestAltAltInp? AsAltAltInp { get; set; }
  public ItestAltInpObject? As_AltInp { get; set; }
}

public class testAltInpObject
  : GqlpEncoderBase
  , ItestAltInpObject
{

  public testAltInpObject
    ()
  {
  }
}

public class testAltAltInp
  : GqlpEncoderBase
  , ItestAltAltInp
{
  public string? AsString { get; set; }
  public ItestAltAltInpObject? As_AltAltInp { get; set; }
}

public class testAltAltInpObject
  : GqlpEncoderBase
  , ItestAltAltInpObject
{
  public decimal Alt { get; set; }

  public testAltAltInpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
