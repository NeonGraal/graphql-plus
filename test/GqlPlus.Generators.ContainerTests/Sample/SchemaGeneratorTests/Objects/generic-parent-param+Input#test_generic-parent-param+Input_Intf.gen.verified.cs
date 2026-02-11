//HintName: test_generic-parent-param+Input_Intf.gen.cs
// Generated from generic-parent-param+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Input;

public interface ItestGnrcPrntParamInp
  : ItestRefGnrcPrntParamInp
{
  ItestGnrcPrntParamInpObject AsGnrcPrntParamInp { get; }
}

public interface ItestGnrcPrntParamInpObject
  : ItestRefGnrcPrntParamInpObject
{
}

public interface ItestRefGnrcPrntParamInp<Tref>
{
  Tref Asref { get; }
  ItestRefGnrcPrntParamInpObject AsRefGnrcPrntParamInp { get; }
}

public interface ItestRefGnrcPrntParamInpObject<Tref>
{
}

public interface ItestAltGnrcPrntParamInp
{
  string AsString { get; }
  ItestAltGnrcPrntParamInpObject AsAltGnrcPrntParamInp { get; }
}

public interface ItestAltGnrcPrntParamInpObject
{
  decimal Alt { get; }
}
