//HintName: test_input-field-Enum_Intf.gen.cs
// Generated from {CurrentDirectory}input-field-Enum.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_Enum;

public interface ItestInpFieldEnum
  : IGqlpInterfaceBase
{
  ItestInpFieldEnumObject? As_InpFieldEnum { get; }
}

public interface ItestInpFieldEnumObject
  : IGqlpInterfaceBase
{
  testEnumInpFieldEnum Field { get; }
}

public enum testEnumInpFieldEnum
{
  inpFieldEnum,
}
