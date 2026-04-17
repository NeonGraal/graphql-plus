//HintName: test_generic-alt-mod-String+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-mod-String+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_mod_String_Dual;

public interface ItestRefGnrcAltModStrDual<TRef>
  : IGqlpInterfaceBase
{
  IDictionary<string, TRef>? Asref { get; }
  ItestRefGnrcAltModStrDualObject<TRef>? As_RefGnrcAltModStrDual { get; }
}

public interface ItestRefGnrcAltModStrDualObject<TRef>
  : IGqlpInterfaceBase
{
}
