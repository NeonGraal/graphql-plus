//HintName: test_generic-alt-param+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Dual;

public interface ItestGnrcAltParamDual
  // No Base because it's Class
{
  ItestRefGnrcAltParamDual<ItestAltGnrcAltParamDual>? AsRefGnrcAltParamDual { get; }
  ItestGnrcAltParamDualObject? As_GnrcAltParamDual { get; }
}

public interface ItestGnrcAltParamDualObject
  // No Base because it's Class
{
}

public interface ItestRefGnrcAltParamDual<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcAltParamDualObject<TRef>? As_RefGnrcAltParamDual { get; }
}

public interface ItestRefGnrcAltParamDualObject<TRef>
  // No Base because it's Class
{
}

public interface ItestAltGnrcAltParamDual
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltGnrcAltParamDualObject? As_AltGnrcAltParamDual { get; }
}

public interface ItestAltGnrcAltParamDualObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
