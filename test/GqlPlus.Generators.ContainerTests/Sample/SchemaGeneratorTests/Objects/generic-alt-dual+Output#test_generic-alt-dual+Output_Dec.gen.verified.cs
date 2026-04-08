//HintName: test_generic-alt-dual+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Output;

public interface ItestGnrcAltDualOutp
  // No Base because it's Class
{
  ItestRefGnrcAltDualOutp<ItestAltGnrcAltDualOutp>? AsRefGnrcAltDualOutp { get; }
  ItestGnrcAltDualOutpObject? As_GnrcAltDualOutp { get; }
}

public interface ItestGnrcAltDualOutpObject
  // No Base because it's Class
{
}

public interface ItestRefGnrcAltDualOutp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcAltDualOutpObject<TRef>? As_RefGnrcAltDualOutp { get; }
}

public interface ItestRefGnrcAltDualOutpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestAltGnrcAltDualOutp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltGnrcAltDualOutpObject? As_AltGnrcAltDualOutp { get; }
}

public interface ItestAltGnrcAltDualOutpObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
