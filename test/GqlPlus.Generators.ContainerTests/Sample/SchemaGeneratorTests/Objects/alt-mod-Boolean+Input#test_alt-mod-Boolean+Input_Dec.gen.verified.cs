//HintName: test_alt-mod-Boolean+Input_Dec.gen.cs
// Generated from {CurrentDirectory}alt-mod-Boolean+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Input;

public interface ItestAltModBoolInp
  // No Base because it's Class
{
  IDictionary<bool, ItestAltAltModBoolInp>? AsAltAltModBoolInp { get; }
  ItestAltModBoolInpObject? As_AltModBoolInp { get; }
}

public interface ItestAltModBoolInpObject
  // No Base because it's Class
{
}

public interface ItestAltAltModBoolInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltAltModBoolInpObject? As_AltAltModBoolInp { get; }
}

public interface ItestAltAltModBoolInpObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
