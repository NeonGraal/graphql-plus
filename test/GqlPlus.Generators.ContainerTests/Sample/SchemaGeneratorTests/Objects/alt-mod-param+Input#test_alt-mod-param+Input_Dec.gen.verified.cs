//HintName: test_alt-mod-param+Input_Dec.gen.cs
// Generated from {CurrentDirectory}alt-mod-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Input;

public interface ItestAltModParamInp<TMod>
  // No Base because it's Class
{
  IDictionary<TMod, ItestAltAltModParamInp>? AsAltAltModParamInp { get; }
  ItestAltModParamInpObject<TMod>? As_AltModParamInp { get; }
}

public interface ItestAltModParamInpObject<TMod>
  // No Base because it's Class
{
}

public interface ItestAltAltModParamInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltAltModParamInpObject? As_AltAltModParamInp { get; }
}

public interface ItestAltAltModParamInpObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
