//HintName: test_alt-mod-param+Input_Enc.gen.cs
// Generated from {CurrentDirectory}alt-mod-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Input;

public class testAltModParamInp<TMod>
  : GqlpEncoderBase
  , ItestAltModParamInp<TMod>
{
  public IDictionary<TMod, ItestAltAltModParamInp>? AsAltAltModParamInp { get; set; }
  public ItestAltModParamInpObject<TMod>? As_AltModParamInp { get; set; }
}

public class testAltModParamInpObject<TMod>
  : GqlpEncoderBase
  , ItestAltModParamInpObject<TMod>
{

  public testAltModParamInpObject
    ()
  {
  }
}

public class testAltAltModParamInp
  : GqlpEncoderBase
  , ItestAltAltModParamInp
{
  public string? AsString { get; set; }
  public ItestAltAltModParamInpObject? As_AltAltModParamInp { get; set; }
}

public class testAltAltModParamInpObject
  : GqlpEncoderBase
  , ItestAltAltModParamInpObject
{
  public decimal Alt { get; set; }

  public testAltAltModParamInpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
