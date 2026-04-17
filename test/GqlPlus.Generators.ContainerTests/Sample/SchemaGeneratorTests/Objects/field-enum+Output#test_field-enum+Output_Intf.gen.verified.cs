//HintName: test_field-enum+Output_Intf.gen.cs
// Generated from {CurrentDirectory}field-enum+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Output;

public interface ItestFieldEnumOutp
  : IGqlpInterfaceBase
{
  ItestFieldEnumOutpObject? As_FieldEnumOutp { get; }
}

public interface ItestFieldEnumOutpObject
  : IGqlpInterfaceBase
{
  testEnumFieldEnumOutp Field { get; }
}

public enum testEnumFieldEnumOutp
{
  fieldEnumOutp,
}
