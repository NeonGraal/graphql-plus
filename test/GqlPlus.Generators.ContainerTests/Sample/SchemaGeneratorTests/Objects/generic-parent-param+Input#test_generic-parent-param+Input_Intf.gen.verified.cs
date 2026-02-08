//HintName: test_generic-parent-param+Input_Intf.gen.cs
// Generated from generic-parent-param+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Input;

public interface ItestGnrcPrntParamInp
  : ItestRefGnrcPrntParamInp
{
  public ItestGnrcPrntParamInpObject AsGnrcPrntParamInp { get; set; }
}

public interface ItestGnrcPrntParamInpObject
  : ItestRefGnrcPrntParamInpObject
{
}

public interface ItestRefGnrcPrntParamInp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcPrntParamInpObject AsRefGnrcPrntParamInp { get; set; }
}

public interface ItestRefGnrcPrntParamInpObject<Tref>
{
}

public interface ItestAltGnrcPrntParamInp
{
  public ItestString AsString { get; set; }
  public ItestAltGnrcPrntParamInpObject AsAltGnrcPrntParamInp { get; set; }
}

public interface ItestAltGnrcPrntParamInpObject
{
  public ItestNumber Alt { get; set; }
}
