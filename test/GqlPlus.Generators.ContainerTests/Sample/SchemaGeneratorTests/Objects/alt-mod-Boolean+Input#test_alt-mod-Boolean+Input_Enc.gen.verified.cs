//HintName: test_alt-mod-Boolean+Input_Enc.gen.cs
// Generated from {CurrentDirectory}alt-mod-Boolean+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Input;

public class testAltModBoolInp
  : GqlpEncoderBase
  , ItestAltModBoolInp
{
  public IDictionary<bool, ItestAltAltModBoolInp>? AsAltAltModBoolInp { get; set; }
  public ItestAltModBoolInpObject? As_AltModBoolInp { get; set; }
}

public class testAltModBoolInpObject
  : GqlpEncoderBase
  , ItestAltModBoolInpObject
{

  public testAltModBoolInpObject
    ()
  {
  }
}

public class testAltAltModBoolInp
  : GqlpEncoderBase
  , ItestAltAltModBoolInp
{
  public string? AsString { get; set; }
  public ItestAltAltModBoolInpObject? As_AltAltModBoolInp { get; set; }
}

public class testAltAltModBoolInpObject
  : GqlpEncoderBase
  , ItestAltAltModBoolInpObject
{
  public decimal Alt { get; set; }

  public testAltAltModBoolInpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
