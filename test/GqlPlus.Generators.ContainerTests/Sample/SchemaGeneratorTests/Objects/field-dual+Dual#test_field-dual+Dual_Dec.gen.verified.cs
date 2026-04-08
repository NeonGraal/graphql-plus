//HintName: test_field-dual+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Dual;

public interface ItestFieldDualDual
  // No Base because it's Class
{
  ItestFieldDualDualObject? As_FieldDualDual { get; }
}

public interface ItestFieldDualDualObject
  // No Base because it's Class
{
  ItestFldFieldDualDual Field { get; }
}

public interface ItestFldFieldDualDual
  // No Base because it's Class
{
  string? AsString { get; }
  ItestFldFieldDualDualObject? As_FldFieldDualDual { get; }
}

public interface ItestFldFieldDualDualObject
  // No Base because it's Class
{
  decimal Field { get; }
}
