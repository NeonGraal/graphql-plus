//HintName: test_generic-alt-mod-param+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-mod-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_mod_param_Input;

public interface ItestRefGnrcAltModParamInp<TRef,TMod>
  // No Base because it's Class
{
  IDictionary<TMod, TRef>? Asref { get; }
  ItestRefGnrcAltModParamInpObject<TRef,TMod>? As_RefGnrcAltModParamInp { get; }
}

public interface ItestRefGnrcAltModParamInpObject<TRef,TMod>
  // No Base because it's Class
{
}
