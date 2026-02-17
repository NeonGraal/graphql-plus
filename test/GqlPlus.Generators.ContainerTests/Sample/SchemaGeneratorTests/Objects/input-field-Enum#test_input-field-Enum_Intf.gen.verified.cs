//HintName: test_input-field-Enum_Intf.gen.cs
// Generated from {CurrentDirectory}input-field-Enum.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_Enum;

public interface ItestInpFieldEnum
  : IGqlpModelImplementationBase
{
  ItestInpFieldEnumObject AsInpFieldEnum { get; }
}

public interface ItestInpFieldEnumObject
{
  testEnumInpFieldEnum Field { get; }
}
