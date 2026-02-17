//HintName: test_field-value+Input_Intf.gen.cs
// Generated from {CurrentDirectory}field-value+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Input;

public interface ItestFieldValueInp
  : IGqlpModelImplementationBase
{
  ItestFieldValueInpObject AsFieldValueInp { get; }
}

public interface ItestFieldValueInpObject
{
  testEnumFieldValueInp Field { get; }
}
