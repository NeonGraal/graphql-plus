//HintName: test_generic-parent-param+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Input;

public class testGnrcPrntParamInp
  : testRefGnrcPrntParamInp<ItestAltGnrcPrntParamInp>
  , ItestGnrcPrntParamInp
{
  public ItestGnrcPrntParamInpObject? As_GnrcPrntParamInp { get; set; }
}

public class testGnrcPrntParamInpObject
  : testRefGnrcPrntParamInpObject<ItestAltGnrcPrntParamInp>
  , ItestGnrcPrntParamInpObject
{

  public testGnrcPrntParamInpObject
    ()
  {
  }
}

public class testRefGnrcPrntParamInp<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcPrntParamInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcPrntParamInpObject<TRef>? As_RefGnrcPrntParamInp { get; set; }
}

public class testRefGnrcPrntParamInpObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcPrntParamInpObject<TRef>
{

  public testRefGnrcPrntParamInpObject
    ()
  {
  }
}

public class testAltGnrcPrntParamInp
  : GqlpEncoderBase
  , ItestAltGnrcPrntParamInp
{
  public string? AsString { get; set; }
  public ItestAltGnrcPrntParamInpObject? As_AltGnrcPrntParamInp { get; set; }
}

public class testAltGnrcPrntParamInpObject
  : GqlpEncoderBase
  , ItestAltGnrcPrntParamInpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcPrntParamInpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
