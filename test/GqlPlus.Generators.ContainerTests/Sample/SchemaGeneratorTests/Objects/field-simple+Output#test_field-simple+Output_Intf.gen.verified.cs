//HintName: test_field-simple+Output_Intf.gen.cs
// Generated from {CurrentDirectory}field-simple+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_simple_Output;

public interface ItestFieldSmplOutp
  : IGqlpInterfaceBase
{
  ItestFieldSmplOutpObject? As_FieldSmplOutp { get; }
}

public interface ItestFieldSmplOutpObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}
