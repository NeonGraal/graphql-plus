//HintName: test_field-dual+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Output;

public interface ItestFieldDualOutp
  // No Base because it's Class
{
  ItestFieldDualOutpObject? As_FieldDualOutp { get; }
}

public interface ItestFieldDualOutpObject
  // No Base because it's Class
{
  ItestFldFieldDualOutp Field { get; }
}

public interface ItestFldFieldDualOutp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestFldFieldDualOutpObject? As_FldFieldDualOutp { get; }
}

public interface ItestFldFieldDualOutpObject
  // No Base because it's Class
{
  decimal Field { get; }
}
