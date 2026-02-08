//HintName: test_generic-alt-param+Input_Intf.gen.cs
// Generated from generic-alt-param+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Input;

public interface ItestGnrcAltParamInp
{
  public ItestRefGnrcAltParamInp<ItestAltGnrcAltParamInp> AsRefGnrcAltParamInp { get; set; }
}

public interface ItestGnrcAltParamInpObject
{
}

public interface ItestRefGnrcAltParamInp<Tref>
{
  public Tref Asref { get; set; }
}

public interface ItestRefGnrcAltParamInpObject<Tref>
{
}

public interface ItestAltGnrcAltParamInp
{
  public ItestString AsString { get; set; }
}

public interface ItestAltGnrcAltParamInpObject
{
  public ItestNumber Alt { get; set; }
}
