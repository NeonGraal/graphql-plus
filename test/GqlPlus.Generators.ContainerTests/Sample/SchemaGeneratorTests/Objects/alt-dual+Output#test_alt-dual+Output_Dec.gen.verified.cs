//HintName: test_alt-dual+Output_Dec.gen.cs
// Generated from {CurrentDirectory}alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Output;

public interface ItestAltDualOutp
  // No Base because it's Class
{
  ItestObjDualAltDualOutp? AsObjDualAltDualOutp { get; }
  ItestAltDualOutpObject? As_AltDualOutp { get; }
}

public interface ItestAltDualOutpObject
  // No Base because it's Class
{
}

public interface ItestObjDualAltDualOutp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestObjDualAltDualOutpObject? As_ObjDualAltDualOutp { get; }
}

public interface ItestObjDualAltDualOutpObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
