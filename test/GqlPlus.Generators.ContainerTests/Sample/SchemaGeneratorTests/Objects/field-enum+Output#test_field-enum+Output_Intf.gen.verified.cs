//HintName: test_field-enum+Output_Intf.gen.cs
// Generated from {CurrentDirectory}field-enum+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Output;

public interface ItestFieldEnumOutp
  : IGqlpModelImplementationBase
{
  ItestFieldEnumOutpObject? As_FieldEnumOutp { get; }
}

public interface ItestFieldEnumOutpObject
  : IGqlpModelImplementationBase
{
  testEnumFieldEnumOutp Field { get; }
}
