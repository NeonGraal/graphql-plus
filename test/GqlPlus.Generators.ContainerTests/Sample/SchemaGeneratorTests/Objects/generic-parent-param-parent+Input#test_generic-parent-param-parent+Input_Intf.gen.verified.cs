//HintName: test_generic-parent-param-parent+Input_Intf.gen.cs
// Generated from generic-parent-param-parent+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Input;

public interface ItestGnrcPrntParamPrntInp
  : ItestRefGnrcPrntParamPrntInp
{
  public ItestGnrcPrntParamPrntInpObject AsGnrcPrntParamPrntInp { get; set; }
}

public interface ItestGnrcPrntParamPrntInpObject
  : ItestRefGnrcPrntParamPrntInpObject
{
}

public interface ItestRefGnrcPrntParamPrntInp<Tref>
  : Itestref
{
  public ItestRefGnrcPrntParamPrntInpObject AsRefGnrcPrntParamPrntInp { get; set; }
}

public interface ItestRefGnrcPrntParamPrntInpObject<Tref>
  : ItestrefObject
{
}

public interface ItestAltGnrcPrntParamPrntInp
{
  public string AsString { get; set; }
  public ItestAltGnrcPrntParamPrntInpObject AsAltGnrcPrntParamPrntInp { get; set; }
}

public interface ItestAltGnrcPrntParamPrntInpObject
{
  public decimal Alt { get; set; }
}
