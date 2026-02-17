//HintName: test_generic-alt-mod-param+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-mod-param+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_mod_param_Dual;

public interface ItestRefGnrcAltModParamDual<TRef,TMod>
  : IGqlpModelImplementationBase
{
  IDictionary<TMod, TRef> Asref { get; }
  ItestRefGnrcAltModParamDualObject<TRef,TMod> AsRefGnrcAltModParamDual { get; }
}

public interface ItestRefGnrcAltModParamDualObject<TRef,TMod>
{
}
