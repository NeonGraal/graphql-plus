//HintName: test_generic-alt-mod-String+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-mod-String+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_mod_String_Dual;

public interface ItestRefGnrcAltModStrDual<TRef>
  : IGqlpModelImplementationBase
{
  IDictionary<string, TRef>? Asref { get; }
  ItestRefGnrcAltModStrDualObject<TRef>? As_RefGnrcAltModStrDual { get; }
}

public interface ItestRefGnrcAltModStrDualObject<TRef>
  : IGqlpModelImplementationBase
{
}
