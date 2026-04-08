//HintName: test_field-value+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}field-value+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Dual;

public interface ItestFieldValueDual
  : IGqlpInterfaceBase
{
  ItestFieldValueDualObject? As_FieldValueDual { get; }
}

public interface ItestFieldValueDualObject
  : IGqlpInterfaceBase
{
  testEnumFieldValueDual Field { get; }
}

public enum testEnumFieldValueDual
{
  fieldValueDual,
}
