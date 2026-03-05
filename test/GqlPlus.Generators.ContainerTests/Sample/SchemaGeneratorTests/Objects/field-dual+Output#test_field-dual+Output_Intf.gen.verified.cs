//HintName: test_field-dual+Output_Intf.gen.cs
// Generated from {CurrentDirectory}field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Output;

public interface ItestFieldDualOutp
  : IGqlpModelImplementationBase
{
  ItestFieldDualOutpObject? As_FieldDualOutp { get; }
}

public interface ItestFieldDualOutpObject
  : IGqlpModelImplementationBase
{
  ItestFldFieldDualOutp Field { get; }
}

public interface ItestFldFieldDualOutp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestFldFieldDualOutpObject? As_FldFieldDualOutp { get; }
}

public interface ItestFldFieldDualOutpObject
  : IGqlpModelImplementationBase
{
  decimal Field { get; }
}
