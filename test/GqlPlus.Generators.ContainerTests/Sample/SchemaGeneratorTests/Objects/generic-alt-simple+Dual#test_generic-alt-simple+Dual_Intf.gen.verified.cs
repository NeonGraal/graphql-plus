//HintName: test_generic-alt-simple+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Dual;

public interface ItestGnrcAltSmplDual
  : IGqlpModelImplementationBase
{
  ItestRefGnrcAltSmplDual<string>? AsRefGnrcAltSmplDual { get; }
  ItestGnrcAltSmplDualObject? As_GnrcAltSmplDual { get; }
}

public interface ItestGnrcAltSmplDualObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefGnrcAltSmplDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltSmplDualObject<TRef>? As_RefGnrcAltSmplDual { get; }
}

public interface ItestRefGnrcAltSmplDualObject<TRef>
  : IGqlpModelImplementationBase
{
}
