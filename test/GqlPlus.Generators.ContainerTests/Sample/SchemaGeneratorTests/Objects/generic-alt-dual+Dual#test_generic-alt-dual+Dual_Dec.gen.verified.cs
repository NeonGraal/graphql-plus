//HintName: test_generic-alt-dual+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Dual;

public interface ItestGnrcAltDualDual
  // No Base because it's Class
{
  ItestRefGnrcAltDualDual<ItestAltGnrcAltDualDual>? AsRefGnrcAltDualDual { get; }
  ItestGnrcAltDualDualObject? As_GnrcAltDualDual { get; }
}

public interface ItestGnrcAltDualDualObject
  // No Base because it's Class
{
}

public interface ItestRefGnrcAltDualDual<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcAltDualDualObject<TRef>? As_RefGnrcAltDualDual { get; }
}

public interface ItestRefGnrcAltDualDualObject<TRef>
  // No Base because it's Class
{
}

public interface ItestAltGnrcAltDualDual
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltGnrcAltDualDualObject? As_AltGnrcAltDualDual { get; }
}

public interface ItestAltGnrcAltDualDualObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
