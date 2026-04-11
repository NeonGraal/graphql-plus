//HintName: test_field-dual+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Dual;

public interface ItestFieldDualDual
  : IGqlpInterfaceBase
{
  ItestFieldDualDualObject? As_FieldDualDual { get; }
}

public interface ItestFieldDualDualObject
  : IGqlpInterfaceBase
{
  ItestFldFieldDualDual Field { get; }
}

public interface ItestFldFieldDualDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestFldFieldDualDualObject? As_FldFieldDualDual { get; }
}

public interface ItestFldFieldDualDualObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}
