//HintName: test_field-enum-parent+Output_Intf.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Output;

public interface ItestFieldEnumPrntOutp
  : IGqlpModelImplementationBase
{
  ItestFieldEnumPrntOutpObject? As_FieldEnumPrntOutp { get; }
}

public interface ItestFieldEnumPrntOutpObject
  : IGqlpModelImplementationBase
{
  testEnumFieldEnumPrntOutp Field { get; }
}
