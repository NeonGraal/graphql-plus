//HintName: test_field-value-descr+Output_Intf.gen.cs
// Generated from {CurrentDirectory}field-value-descr+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_descr_Output;

public interface ItestFieldValueDescrOutp
  : IGqlpInterfaceBase
{
  ItestFieldValueDescrOutpObject? As_FieldValueDescrOutp { get; }
}

public interface ItestFieldValueDescrOutpObject
  : IGqlpInterfaceBase
{
  testEnumFieldValueDescrOutp Field { get; }
}

public enum testEnumFieldValueDescrOutp
{
  fieldValueDescrOutp,
}
