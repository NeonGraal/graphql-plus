//HintName: test_alt+Output_Dec.gen.cs
// Generated from {CurrentDirectory}alt+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Output;

public interface ItestAltOutp
  // No Base because it's Class
{
  ItestAltAltOutp? AsAltAltOutp { get; }
  ItestAltOutpObject? As_AltOutp { get; }
}

public interface ItestAltOutpObject
  // No Base because it's Class
{
}

public interface ItestAltAltOutp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltAltOutpObject? As_AltAltOutp { get; }
}

public interface ItestAltAltOutpObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
