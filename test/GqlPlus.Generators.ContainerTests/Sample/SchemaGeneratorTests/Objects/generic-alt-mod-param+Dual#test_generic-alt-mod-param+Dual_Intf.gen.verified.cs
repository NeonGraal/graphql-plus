//HintName: test_generic-alt-mod-param+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-mod-param+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_mod_param_Dual;

public interface ItestRefGnrcAltModParamDual<TRef,TMod>
  : IGqlpInterfaceBase
{
  IDictionary<TMod, TRef>? Asref { get; }
  ItestRefGnrcAltModParamDualObject<TRef,TMod>? As_RefGnrcAltModParamDual { get; }
}

public interface ItestRefGnrcAltModParamDualObject<TRef,TMod>
  : IGqlpInterfaceBase
{
}
