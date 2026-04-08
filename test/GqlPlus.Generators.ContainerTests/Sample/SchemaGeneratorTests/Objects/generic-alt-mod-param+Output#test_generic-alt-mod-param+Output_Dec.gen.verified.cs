//HintName: test_generic-alt-mod-param+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-mod-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_mod_param_Output;

public interface ItestRefGnrcAltModParamOutp<TRef,TMod>
  // No Base because it's Class
{
  IDictionary<TMod, TRef>? Asref { get; }
  ItestRefGnrcAltModParamOutpObject<TRef,TMod>? As_RefGnrcAltModParamOutp { get; }
}

public interface ItestRefGnrcAltModParamOutpObject<TRef,TMod>
  // No Base because it's Class
{
}
