//HintName: test_field-mod-Enum+Input_Intf.gen.cs
// Generated from {CurrentDirectory}field-mod-Enum+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_Enum_Input;

public interface ItestFieldModEnumInp
  : IGqlpModelImplementationBase
{
  ItestFieldModEnumInpObject? As_FieldModEnumInp { get; }
}

public interface ItestFieldModEnumInpObject
  : IGqlpModelImplementationBase
{
  IDictionary<testEnumFieldModEnumInp, string> Field { get; }
}
