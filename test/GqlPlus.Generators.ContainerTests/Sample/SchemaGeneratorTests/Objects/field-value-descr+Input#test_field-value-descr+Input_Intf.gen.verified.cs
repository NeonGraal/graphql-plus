//HintName: test_field-value-descr+Input_Intf.gen.cs
// Generated from {CurrentDirectory}field-value-descr+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_descr_Input;

public interface ItestFieldValueDescrInp
  : IGqlpInterfaceBase
{
  ItestFieldValueDescrInpObject? As_FieldValueDescrInp { get; }
}

public interface ItestFieldValueDescrInpObject
  : IGqlpInterfaceBase
{
  testEnumFieldValueDescrInp Field { get; }
}

public enum testEnumFieldValueDescrInp
{
  fieldValueDescrInp,
}
