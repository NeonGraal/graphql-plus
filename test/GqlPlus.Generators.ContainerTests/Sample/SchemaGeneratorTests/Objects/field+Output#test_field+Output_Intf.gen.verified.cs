//HintName: test_field+Output_Intf.gen.cs
// Generated from {CurrentDirectory}field+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_Output;

public interface ItestFieldOutp
  : IGqlpModelImplementationBase
{
  ItestFieldOutpObject? As_FieldOutp { get; }
}

public interface ItestFieldOutpObject
  : IGqlpModelImplementationBase
{
  string Field { get; }
}
