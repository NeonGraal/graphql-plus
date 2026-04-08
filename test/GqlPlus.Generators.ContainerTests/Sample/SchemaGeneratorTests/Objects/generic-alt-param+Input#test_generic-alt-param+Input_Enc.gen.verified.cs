//HintName: test_generic-alt-param+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Input;

public class testGnrcAltParamInp
  : GqlpEncoderBase
  , ItestGnrcAltParamInp
{
  public ItestRefGnrcAltParamInp<ItestAltGnrcAltParamInp>? AsRefGnrcAltParamInp { get; set; }
  public ItestGnrcAltParamInpObject? As_GnrcAltParamInp { get; set; }
}

public class testGnrcAltParamInpObject
  : GqlpEncoderBase
  , ItestGnrcAltParamInpObject
{

  public testGnrcAltParamInpObject
    ()
  {
  }
}

public class testRefGnrcAltParamInp<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltParamInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltParamInpObject<TRef>? As_RefGnrcAltParamInp { get; set; }
}

public class testRefGnrcAltParamInpObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltParamInpObject<TRef>
{

  public testRefGnrcAltParamInpObject
    ()
  {
  }
}

public class testAltGnrcAltParamInp
  : GqlpEncoderBase
  , ItestAltGnrcAltParamInp
{
  public string? AsString { get; set; }
  public ItestAltGnrcAltParamInpObject? As_AltGnrcAltParamInp { get; set; }
}

public class testAltGnrcAltParamInpObject
  : GqlpEncoderBase
  , ItestAltGnrcAltParamInpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcAltParamInpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
