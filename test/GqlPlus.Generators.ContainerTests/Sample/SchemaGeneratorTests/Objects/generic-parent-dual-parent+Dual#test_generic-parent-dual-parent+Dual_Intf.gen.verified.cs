//HintName: test_generic-parent-dual-parent+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Dual;

public interface ItestGnrcPrntDualPrntDual
  : ItestRefGnrcPrntDualPrntDual<ItestAltGnrcPrntDualPrntDual>
{
  ItestGnrcPrntDualPrntDualObject AsGnrcPrntDualPrntDual { get; }
}

public interface ItestGnrcPrntDualPrntDualObject
  : ItestRefGnrcPrntDualPrntDualObject<ItestAltGnrcPrntDualPrntDual>
{
}

public interface ItestRefGnrcPrntDualPrntDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef AsParent { get; }
  ItestRefGnrcPrntDualPrntDualObject<TRef> AsRefGnrcPrntDualPrntDual { get; }
}

public interface ItestRefGnrcPrntDualPrntDualObject<TRef>
{
}

public interface ItestAltGnrcPrntDualPrntDual
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltGnrcPrntDualPrntDualObject AsAltGnrcPrntDualPrntDual { get; }
}

public interface ItestAltGnrcPrntDualPrntDualObject
{
  decimal Alt { get; }
}
