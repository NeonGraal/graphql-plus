//HintName: test_generic-alt-dual+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Dual;

public interface ItestGnrcAltDualDual
  : IGqlpModelImplementationBase
{
  ItestRefGnrcAltDualDual<ItestAltGnrcAltDualDual>? AsRefGnrcAltDualDual { get; }
  ItestGnrcAltDualDualObject? As_GnrcAltDualDual { get; }
}

public interface ItestGnrcAltDualDualObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefGnrcAltDualDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltDualDualObject<TRef>? As_RefGnrcAltDualDual { get; }
}

public interface ItestRefGnrcAltDualDualObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestAltGnrcAltDualDual
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestAltGnrcAltDualDualObject? As_AltGnrcAltDualDual { get; }
}

public interface ItestAltGnrcAltDualDualObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}
