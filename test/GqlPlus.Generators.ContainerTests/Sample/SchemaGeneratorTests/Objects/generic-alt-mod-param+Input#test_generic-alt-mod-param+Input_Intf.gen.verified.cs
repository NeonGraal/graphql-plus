//HintName: test_generic-alt-mod-param+Input_Intf.gen.cs
// Generated from generic-alt-mod-param+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_mod_param_Input;

public interface ItestRefGnrcAltModParamInp<TRef,TMod>
{
  IDictionary<TMod, TRef> Asref { get; }
  ItestRefGnrcAltModParamInpObject<TRef,TMod> AsRefGnrcAltModParamInp { get; }
}

public interface ItestRefGnrcAltModParamInpObject<TRef,TMod>
{
}
