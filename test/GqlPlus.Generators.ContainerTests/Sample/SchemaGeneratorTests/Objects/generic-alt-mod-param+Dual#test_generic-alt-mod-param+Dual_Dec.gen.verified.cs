//HintName: test_generic-alt-mod-param+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-mod-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_mod_param_Dual;

public interface ItestRefGnrcAltModParamDual<TRef,TMod>
  // No Base because it's Class
{
  IDictionary<TMod, TRef>? Asref { get; }
  ItestRefGnrcAltModParamDualObject<TRef,TMod>? As_RefGnrcAltModParamDual { get; }
}

public interface ItestRefGnrcAltModParamDualObject<TRef,TMod>
  // No Base because it's Class
{
}
