//HintName: test_generic-parent-dual+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Output;

public interface ItestGnrcPrntDualOutp
  : ItestRefGnrcPrntDualOutp<ItestAltGnrcPrntDualOutp>
{
  ItestGnrcPrntDualOutpObject? As_GnrcPrntDualOutp { get; }
}

public interface ItestGnrcPrntDualOutpObject
  : ItestRefGnrcPrntDualOutpObject<ItestAltGnrcPrntDualOutp>
{
}

public interface ItestRefGnrcPrntDualOutp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcPrntDualOutpObject<TRef>? As_RefGnrcPrntDualOutp { get; }
}

public interface ItestRefGnrcPrntDualOutpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestAltGnrcPrntDualOutp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltGnrcPrntDualOutpObject? As_AltGnrcPrntDualOutp { get; }
}

public interface ItestAltGnrcPrntDualOutpObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
