//HintName: test_generic-parent-dual+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Dual;

public interface ItestGnrcPrntDualDual
  : ItestRefGnrcPrntDualDual<ItestAltGnrcPrntDualDual>
{
  ItestGnrcPrntDualDualObject? As_GnrcPrntDualDual { get; }
}

public interface ItestGnrcPrntDualDualObject
  : ItestRefGnrcPrntDualDualObject<ItestAltGnrcPrntDualDual>
{
}

public interface ItestRefGnrcPrntDualDual<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcPrntDualDualObject<TRef>? As_RefGnrcPrntDualDual { get; }
}

public interface ItestRefGnrcPrntDualDualObject<TRef>
  // No Base because it's Class
{
}

public interface ItestAltGnrcPrntDualDual
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltGnrcPrntDualDualObject? As_AltGnrcPrntDualDual { get; }
}

public interface ItestAltGnrcPrntDualDualObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
