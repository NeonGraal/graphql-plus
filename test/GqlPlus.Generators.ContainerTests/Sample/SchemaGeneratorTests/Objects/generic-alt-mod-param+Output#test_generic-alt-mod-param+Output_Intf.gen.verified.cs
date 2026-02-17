//HintName: test_generic-alt-mod-param+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-mod-param+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_mod_param_Output;

public interface ItestRefGnrcAltModParamOutp<TRef,TMod>
  : IGqlpModelImplementationBase
{
  IDictionary<TMod, TRef> Asref { get; }
  ItestRefGnrcAltModParamOutpObject<TRef,TMod> AsRefGnrcAltModParamOutp { get; }
}

public interface ItestRefGnrcAltModParamOutpObject<TRef,TMod>
{
}
