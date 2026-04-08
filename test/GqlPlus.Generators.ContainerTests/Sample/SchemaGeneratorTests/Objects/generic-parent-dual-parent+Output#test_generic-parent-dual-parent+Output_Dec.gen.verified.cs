//HintName: test_generic-parent-dual-parent+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Output;

public interface ItestGnrcPrntDualPrntOutp
  : ItestRefGnrcPrntDualPrntOutp<ItestAltGnrcPrntDualPrntOutp>
{
  ItestGnrcPrntDualPrntOutpObject? As_GnrcPrntDualPrntOutp { get; }
}

public interface ItestGnrcPrntDualPrntOutpObject
  : ItestRefGnrcPrntDualPrntOutpObject<ItestAltGnrcPrntDualPrntOutp>
{
}

public interface ItestRefGnrcPrntDualPrntOutp<TRef>
  // No Base because it's Class
{
  TRef? As_Parent { get; }
  ItestRefGnrcPrntDualPrntOutpObject<TRef>? As_RefGnrcPrntDualPrntOutp { get; }
}

public interface ItestRefGnrcPrntDualPrntOutpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestAltGnrcPrntDualPrntOutp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltGnrcPrntDualPrntOutpObject? As_AltGnrcPrntDualPrntOutp { get; }
}

public interface ItestAltGnrcPrntDualPrntOutpObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
