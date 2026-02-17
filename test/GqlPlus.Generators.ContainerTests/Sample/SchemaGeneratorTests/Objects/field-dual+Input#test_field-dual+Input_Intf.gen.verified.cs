//HintName: test_field-dual+Input_Intf.gen.cs
// Generated from {CurrentDirectory}field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Input;

public interface ItestFieldDualInp
  : IGqlpModelImplementationBase
{
  ItestFieldDualInpObject? As_FieldDualInp { get; }
}

public interface ItestFieldDualInpObject
  : IGqlpModelImplementationBase
{
  ItestFldFieldDualInp Field { get; }
}

public interface ItestFldFieldDualInp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestFldFieldDualInpObject? As_FldFieldDualInp { get; }
}

public interface ItestFldFieldDualInpObject
  : IGqlpModelImplementationBase
{
  decimal Field { get; }
}
