//HintName: test_field-value+Output_Intf.gen.cs
// Generated from {CurrentDirectory}field-value+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Output;

public interface ItestFieldValueOutp
  : IGqlpModelImplementationBase
{
  ItestFieldValueOutpObject AsFieldValueOutp { get; }
}

public interface ItestFieldValueOutpObject
{
  testEnumFieldValueOutp Field { get; }
}
