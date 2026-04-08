//HintName: test_generic-parent-param-parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-param-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Input;

public class testGnrcPrntParamPrntInp
  : testRefGnrcPrntParamPrntInp<ItestAltGnrcPrntParamPrntInp>
  , ItestGnrcPrntParamPrntInp
{
  public ItestGnrcPrntParamPrntInpObject? As_GnrcPrntParamPrntInp { get; set; }
}

public class testGnrcPrntParamPrntInpObject
  : testRefGnrcPrntParamPrntInpObject<ItestAltGnrcPrntParamPrntInp>
  , ItestGnrcPrntParamPrntInpObject
{

  public testGnrcPrntParamPrntInpObject
    ()
  {
  }
}

public class testRefGnrcPrntParamPrntInp<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcPrntParamPrntInp<TRef>
{
  public TRef? As_Parent { get; set; }
  public ItestRefGnrcPrntParamPrntInpObject<TRef>? As_RefGnrcPrntParamPrntInp { get; set; }
}

public class testRefGnrcPrntParamPrntInpObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcPrntParamPrntInpObject<TRef>
{

  public testRefGnrcPrntParamPrntInpObject
    ()
  {
  }
}

public class testAltGnrcPrntParamPrntInp
  : GqlpEncoderBase
  , ItestAltGnrcPrntParamPrntInp
{
  public string? AsString { get; set; }
  public ItestAltGnrcPrntParamPrntInpObject? As_AltGnrcPrntParamPrntInp { get; set; }
}

public class testAltGnrcPrntParamPrntInpObject
  : GqlpEncoderBase
  , ItestAltGnrcPrntParamPrntInpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcPrntParamPrntInpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
