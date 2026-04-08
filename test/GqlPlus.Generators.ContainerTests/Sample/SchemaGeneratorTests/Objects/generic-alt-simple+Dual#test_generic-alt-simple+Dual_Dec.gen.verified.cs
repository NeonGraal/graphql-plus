//HintName: test_generic-alt-simple+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Dual;

public interface ItestGnrcAltSmplDual
  // No Base because it's Class
{
  ItestRefGnrcAltSmplDual<string>? AsRefGnrcAltSmplDual { get; }
  ItestGnrcAltSmplDualObject? As_GnrcAltSmplDual { get; }
}

public interface ItestGnrcAltSmplDualObject
  // No Base because it's Class
{
}

public interface ItestRefGnrcAltSmplDual<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcAltSmplDualObject<TRef>? As_RefGnrcAltSmplDual { get; }
}

public interface ItestRefGnrcAltSmplDualObject<TRef>
  // No Base because it's Class
{
}
