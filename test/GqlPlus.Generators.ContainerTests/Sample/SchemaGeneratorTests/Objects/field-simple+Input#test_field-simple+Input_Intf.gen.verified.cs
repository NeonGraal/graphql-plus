//HintName: test_field-simple+Input_Intf.gen.cs
// Generated from {CurrentDirectory}field-simple+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_simple_Input;

public interface ItestFieldSmplInp
  : IGqlpInterfaceBase
{
  ItestFieldSmplInpObject? As_FieldSmplInp { get; }
}

public interface ItestFieldSmplInpObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}
