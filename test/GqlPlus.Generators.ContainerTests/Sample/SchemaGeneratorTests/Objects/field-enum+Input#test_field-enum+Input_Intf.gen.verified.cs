//HintName: test_field-enum+Input_Intf.gen.cs
// Generated from {CurrentDirectory}field-enum+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Input;

public interface ItestFieldEnumInp
  : IGqlpModelImplementationBase
{
  ItestFieldEnumInpObject? As_FieldEnumInp { get; }
}

public interface ItestFieldEnumInpObject
  : IGqlpModelImplementationBase
{
  testEnumFieldEnumInp Field { get; }
}

public enum testEnumFieldEnumInp
{
  fieldEnumInp,
}
