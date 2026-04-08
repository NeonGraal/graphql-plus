//HintName: test_generic-parent-dual-parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Dual;

public interface ItestGnrcPrntDualPrntDual
  : ItestRefGnrcPrntDualPrntDual<ItestAltGnrcPrntDualPrntDual>
{
  ItestGnrcPrntDualPrntDualObject? As_GnrcPrntDualPrntDual { get; }
}

public interface ItestGnrcPrntDualPrntDualObject
  : ItestRefGnrcPrntDualPrntDualObject<ItestAltGnrcPrntDualPrntDual>
{
}

public interface ItestRefGnrcPrntDualPrntDual<TRef>
  // No Base because it's Class
{
  TRef? As_Parent { get; }
  ItestRefGnrcPrntDualPrntDualObject<TRef>? As_RefGnrcPrntDualPrntDual { get; }
}

public interface ItestRefGnrcPrntDualPrntDualObject<TRef>
  // No Base because it's Class
{
}

public interface ItestAltGnrcPrntDualPrntDual
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltGnrcPrntDualPrntDualObject? As_AltGnrcPrntDualPrntDual { get; }
}

public interface ItestAltGnrcPrntDualPrntDualObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
