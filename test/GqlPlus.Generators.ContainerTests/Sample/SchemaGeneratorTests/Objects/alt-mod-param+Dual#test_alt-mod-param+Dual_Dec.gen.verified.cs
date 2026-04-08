//HintName: test_alt-mod-param+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}alt-mod-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Dual;

public interface ItestAltModParamDual<TMod>
  // No Base because it's Class
{
  IDictionary<TMod, ItestAltAltModParamDual>? AsAltAltModParamDual { get; }
  ItestAltModParamDualObject<TMod>? As_AltModParamDual { get; }
}

public interface ItestAltModParamDualObject<TMod>
  // No Base because it's Class
{
}

public interface ItestAltAltModParamDual
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltAltModParamDualObject? As_AltAltModParamDual { get; }
}

public interface ItestAltAltModParamDualObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
