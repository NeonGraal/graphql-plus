//HintName: test_field-object+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-object+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Output;

public interface ItestFieldObjOutp
  // No Base because it's Class
{
  ItestFieldObjOutpObject? As_FieldObjOutp { get; }
}

public interface ItestFieldObjOutpObject
  // No Base because it's Class
{
  ItestFldFieldObjOutp Field { get; }
}

public interface ItestFldFieldObjOutp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestFldFieldObjOutpObject? As_FldFieldObjOutp { get; }
}

public interface ItestFldFieldObjOutpObject
  // No Base because it's Class
{
  decimal Field { get; }
}
