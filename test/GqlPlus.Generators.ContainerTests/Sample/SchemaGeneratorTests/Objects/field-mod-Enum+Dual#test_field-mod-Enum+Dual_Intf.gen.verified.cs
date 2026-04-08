//HintName: test_field-mod-Enum+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}field-mod-Enum+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_Enum_Dual;

public interface ItestFieldModEnumDual
  : IGqlpInterfaceBase
{
  ItestFieldModEnumDualObject? As_FieldModEnumDual { get; }
}

public interface ItestFieldModEnumDualObject
  : IGqlpInterfaceBase
{
  IDictionary<testEnumFieldModEnumDual, string> Field { get; }
}

public enum testEnumFieldModEnumDual
{
  value,
}
