//HintName: test_alt+Input_Dec.gen.cs
// Generated from {CurrentDirectory}alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Input;

public interface ItestAltInp
  // No Base because it's Class
{
  ItestAltAltInp? AsAltAltInp { get; }
  ItestAltInpObject? As_AltInp { get; }
}

public interface ItestAltInpObject
  // No Base because it's Class
{
}

public interface ItestAltAltInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltAltInpObject? As_AltAltInp { get; }
}

public interface ItestAltAltInpObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
