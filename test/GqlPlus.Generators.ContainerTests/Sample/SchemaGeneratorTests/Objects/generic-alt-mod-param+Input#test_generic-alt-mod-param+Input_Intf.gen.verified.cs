//HintName: test_generic-alt-mod-param+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-mod-param+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_mod_param_Input;

public interface ItestRefGnrcAltModParamInp<TRef,TMod>
  : IGqlpModelImplementationBase
{
  IDictionary<TMod, TRef> Asref { get; }
  ItestRefGnrcAltModParamInpObject<TRef,TMod> AsRefGnrcAltModParamInp { get; }
}

public interface ItestRefGnrcAltModParamInpObject<TRef,TMod>
{
}
