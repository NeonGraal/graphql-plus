//HintName: test_alt-dual+Input_Dec.gen.cs
// Generated from {CurrentDirectory}alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Input;

public interface ItestAltDualInp
  // No Base because it's Class
{
  ItestObjDualAltDualInp? AsObjDualAltDualInp { get; }
  ItestAltDualInpObject? As_AltDualInp { get; }
}

public interface ItestAltDualInpObject
  // No Base because it's Class
{
}

public interface ItestObjDualAltDualInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestObjDualAltDualInpObject? As_ObjDualAltDualInp { get; }
}

public interface ItestObjDualAltDualInpObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
