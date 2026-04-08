//HintName: test_field-dual+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Input;

public interface ItestFieldDualInp
  // No Base because it's Class
{
  ItestFieldDualInpObject? As_FieldDualInp { get; }
}

public interface ItestFieldDualInpObject
  // No Base because it's Class
{
  ItestFldFieldDualInp Field { get; }
}

public interface ItestFldFieldDualInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestFldFieldDualInpObject? As_FldFieldDualInp { get; }
}

public interface ItestFldFieldDualInpObject
  // No Base because it's Class
{
  decimal Field { get; }
}
