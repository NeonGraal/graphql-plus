//HintName: test_generic-alt-param+Input_Intf.gen.cs
// Generated from generic-alt-param+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Input;

public interface ItestGnrcAltParamInp
{
  ItestRefGnrcAltParamInp<ItestAltGnrcAltParamInp> AsRefGnrcAltParamInp { get; }
  ItestGnrcAltParamInpObject AsGnrcAltParamInp { get; }
}

public interface ItestGnrcAltParamInpObject
{
}

public interface ItestRefGnrcAltParamInp<Tref>
{
  Tref Asref { get; }
  ItestRefGnrcAltParamInpObject AsRefGnrcAltParamInp { get; }
}

public interface ItestRefGnrcAltParamInpObject<Tref>
{
}

public interface ItestAltGnrcAltParamInp
{
  string AsString { get; }
  ItestAltGnrcAltParamInpObject AsAltGnrcAltParamInp { get; }
}

public interface ItestAltGnrcAltParamInpObject
{
  decimal Alt { get; }
}
