//HintName: test_generic-alt-mod-param+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-mod-param+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_mod_param_Input;

public interface ItestRefGnrcAltModParamInp<TRef,TMod>
  : IGqlpInterfaceBase
{
  IDictionary<TMod, TRef>? Asref { get; }
  ItestRefGnrcAltModParamInpObject<TRef,TMod>? As_RefGnrcAltModParamInp { get; }
}

public interface ItestRefGnrcAltModParamInpObject<TRef,TMod>
  : IGqlpInterfaceBase
{
}
