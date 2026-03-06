//HintName: test_field-simple+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}field-simple+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_simple_Dual;

public interface ItestFieldSmplDual
  : IGqlpModelImplementationBase
{
  ItestFieldSmplDualObject? As_FieldSmplDual { get; }
}

public interface ItestFieldSmplDualObject
  : IGqlpModelImplementationBase
{
  decimal Field { get; }
}
