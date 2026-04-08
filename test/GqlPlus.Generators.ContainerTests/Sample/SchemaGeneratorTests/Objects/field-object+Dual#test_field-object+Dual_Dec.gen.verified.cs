//HintName: test_field-object+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-object+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Dual;

public interface ItestFieldObjDual
  // No Base because it's Class
{
  ItestFieldObjDualObject? As_FieldObjDual { get; }
}

public interface ItestFieldObjDualObject
  // No Base because it's Class
{
  ItestFldFieldObjDual Field { get; }
}

public interface ItestFldFieldObjDual
  // No Base because it's Class
{
  string? AsString { get; }
  ItestFldFieldObjDualObject? As_FldFieldObjDual { get; }
}

public interface ItestFldFieldObjDualObject
  // No Base because it's Class
{
  decimal Field { get; }
}
