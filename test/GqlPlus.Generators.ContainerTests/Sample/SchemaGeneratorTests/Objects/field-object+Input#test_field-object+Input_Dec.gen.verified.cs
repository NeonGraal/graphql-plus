//HintName: test_field-object+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-object+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Input;

public interface ItestFieldObjInp
  // No Base because it's Class
{
  ItestFieldObjInpObject? As_FieldObjInp { get; }
}

public interface ItestFieldObjInpObject
  // No Base because it's Class
{
  ItestFldFieldObjInp Field { get; }
}

public interface ItestFldFieldObjInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestFldFieldObjInpObject? As_FldFieldObjInp { get; }
}

public interface ItestFldFieldObjInpObject
  // No Base because it's Class
{
  decimal Field { get; }
}
