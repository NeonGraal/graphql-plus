//HintName: test_field-value+Input_Intf.gen.cs
// Generated from {CurrentDirectory}field-value+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Input;

public interface ItestFieldValueInp
  : IGqlpInterfaceBase
{
  ItestFieldValueInpObject? As_FieldValueInp { get; }
}

public interface ItestFieldValueInpObject
  : IGqlpInterfaceBase
{
  testEnumFieldValueInp Field { get; }
}

public enum testEnumFieldValueInp
{
  fieldValueInp,
}
