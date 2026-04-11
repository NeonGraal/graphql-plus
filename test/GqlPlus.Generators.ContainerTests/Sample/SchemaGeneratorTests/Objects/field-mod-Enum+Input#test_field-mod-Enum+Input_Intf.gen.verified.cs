//HintName: test_field-mod-Enum+Input_Intf.gen.cs
// Generated from {CurrentDirectory}field-mod-Enum+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_Enum_Input;

public interface ItestFieldModEnumInp
  : IGqlpInterfaceBase
{
  ItestFieldModEnumInpObject? As_FieldModEnumInp { get; }
}

public interface ItestFieldModEnumInpObject
  : IGqlpInterfaceBase
{
  IDictionary<testEnumFieldModEnumInp, string> Field { get; }
}

public enum testEnumFieldModEnumInp
{
  value,
}
