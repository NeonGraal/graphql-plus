//HintName: test_field-simple+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}field-simple+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_simple_Dual;

public interface ItestFieldSmplDual
  : IGqlpInterfaceBase
{
  ItestFieldSmplDualObject? As_FieldSmplDual { get; }
}

public interface ItestFieldSmplDualObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}
