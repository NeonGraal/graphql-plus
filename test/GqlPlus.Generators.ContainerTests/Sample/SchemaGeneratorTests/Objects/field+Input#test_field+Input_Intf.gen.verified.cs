//HintName: test_field+Input_Intf.gen.cs
// Generated from {CurrentDirectory}field+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_Input;

public interface ItestFieldInp
  : IGqlpInterfaceBase
{
  ItestFieldInpObject? As_FieldInp { get; }
}

public interface ItestFieldInpObject
  : IGqlpInterfaceBase
{
  string Field { get; }
}
