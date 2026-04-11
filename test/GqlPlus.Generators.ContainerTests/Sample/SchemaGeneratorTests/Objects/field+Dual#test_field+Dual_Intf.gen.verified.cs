//HintName: test_field+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}field+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_Dual;

public interface ItestFieldDual
  : IGqlpInterfaceBase
{
  ItestFieldDualObject? As_FieldDual { get; }
}

public interface ItestFieldDualObject
  : IGqlpInterfaceBase
{
  string Field { get; }
}
