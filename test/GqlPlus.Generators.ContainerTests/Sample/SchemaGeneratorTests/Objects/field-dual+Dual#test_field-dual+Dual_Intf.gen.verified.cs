//HintName: test_field-dual+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Dual;

public interface ItestFieldDualDual
  : IGqlpModelImplementationBase
{
  ItestFieldDualDualObject? As_FieldDualDual { get; }
}

public interface ItestFieldDualDualObject
  : IGqlpModelImplementationBase
{
  ItestFldFieldDualDual Field { get; }
}

public interface ItestFldFieldDualDual
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestFldFieldDualDualObject? As_FldFieldDualDual { get; }
}

public interface ItestFldFieldDualDualObject
  : IGqlpModelImplementationBase
{
  decimal Field { get; }
}
