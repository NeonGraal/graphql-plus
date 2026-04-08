//HintName: test_alt-mod-param+Output_Dec.gen.cs
// Generated from {CurrentDirectory}alt-mod-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Output;

public interface ItestAltModParamOutp<TMod>
  // No Base because it's Class
{
  IDictionary<TMod, ItestAltAltModParamOutp>? AsAltAltModParamOutp { get; }
  ItestAltModParamOutpObject<TMod>? As_AltModParamOutp { get; }
}

public interface ItestAltModParamOutpObject<TMod>
  // No Base because it's Class
{
}

public interface ItestAltAltModParamOutp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltAltModParamOutpObject? As_AltAltModParamOutp { get; }
}

public interface ItestAltAltModParamOutpObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
