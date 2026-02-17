//HintName: test_field-simple+Input_Intf.gen.cs
// Generated from {CurrentDirectory}field-simple+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_simple_Input;

public interface ItestFieldSmplInp
  : IGqlpModelImplementationBase
{
  ItestFieldSmplInpObject? As_FieldSmplInp { get; }
}

public interface ItestFieldSmplInpObject
  : IGqlpModelImplementationBase
{
  decimal Field { get; }
}
