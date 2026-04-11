//HintName: test_field-value+Output_Intf.gen.cs
// Generated from {CurrentDirectory}field-value+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Output;

public interface ItestFieldValueOutp
  : IGqlpInterfaceBase
{
  ItestFieldValueOutpObject? As_FieldValueOutp { get; }
}

public interface ItestFieldValueOutpObject
  : IGqlpInterfaceBase
{
  testEnumFieldValueOutp Field { get; }
}

public enum testEnumFieldValueOutp
{
  fieldValueOutp,
}
