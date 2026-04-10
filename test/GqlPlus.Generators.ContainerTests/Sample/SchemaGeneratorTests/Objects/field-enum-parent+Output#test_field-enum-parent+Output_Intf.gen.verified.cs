//HintName: test_field-enum-parent+Output_Intf.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Output;

public interface ItestFieldEnumPrntOutp
  : IGqlpInterfaceBase
{
  ItestFieldEnumPrntOutpObject? As_FieldEnumPrntOutp { get; }
}

public interface ItestFieldEnumPrntOutpObject
  : IGqlpInterfaceBase
{
  testEnumFieldEnumPrntOutp Field { get; }
}

public enum testEnumFieldEnumPrntOutp
{
  prnt_fieldEnumPrntOutp = testPrntFieldEnumPrntOutp.prnt_fieldEnumPrntOutp,
  fieldEnumPrntOutp,
}

public enum testPrntFieldEnumPrntOutp
{
  prnt_fieldEnumPrntOutp,
}
