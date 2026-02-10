//HintName: test_generic-parent-param-parent+Input_Impl.gen.cs
// Generated from generic-parent-param-parent+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Input;

public class testGnrcPrntParamPrntInp
  : testRefGnrcPrntParamPrntInp
  , ItestGnrcPrntParamPrntInp
{
  public ItestGnrcPrntParamPrntInpObject AsGnrcPrntParamPrntInp { get; set; }
}

public class testRefGnrcPrntParamPrntInp<Tref>
  : testref
  , ItestRefGnrcPrntParamPrntInp<Tref>
{
  public ItestRefGnrcPrntParamPrntInpObject AsRefGnrcPrntParamPrntInp { get; set; }
}

public class testAltGnrcPrntParamPrntInp
  : ItestAltGnrcPrntParamPrntInp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcPrntParamPrntInpObject AsAltGnrcPrntParamPrntInp { get; set; }
}
