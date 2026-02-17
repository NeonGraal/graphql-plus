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
  ItestRefGnrcAltDualDual<ItestAltGnrcAltDualDual> AsRefGnrcAltDualDual { get; }
  ItestGnrcAltDualDualObject AsGnrcAltDualDual { get; }
}

public interface ItestGnrcAltDualDualObject
{
}

public interface ItestRefGnrcAltDualDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcAltDualDualObject<TRef> AsRefGnrcAltDualDual { get; }
}

public interface ItestRefGnrcAltDualDualObject<TRef>
{
}

public interface ItestAltGnrcAltDualDual
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltGnrcAltDualDualObject AsAltGnrcAltDualDual { get; }
}

public interface ItestAltGnrcAltDualDualObject
{
  decimal Alt { get; }
}
