//HintName: test_field-simple+Output_Intf.gen.cs
// Generated from {CurrentDirectory}field-simple+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_simple_Output;

public interface ItestFieldSmplOutp
  : IGqlpModelImplementationBase
{
  ItestFieldSmplOutpObject? As_FieldSmplOutp { get; }
}

public interface ItestFieldSmplOutpObject
  : IGqlpModelImplementationBase
{
  decimal Field { get; }
}
