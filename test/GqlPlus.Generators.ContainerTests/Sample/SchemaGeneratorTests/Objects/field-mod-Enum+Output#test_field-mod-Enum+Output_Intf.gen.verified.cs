//HintName: test_field-mod-Enum+Output_Intf.gen.cs
// Generated from {CurrentDirectory}field-mod-Enum+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_Enum_Output;

public interface ItestFieldModEnumOutp
  : IGqlpModelImplementationBase
{
  ItestFieldModEnumOutpObject AsFieldModEnumOutp { get; }
}

public interface ItestFieldModEnumOutpObject
{
  IDictionary<testEnumFieldModEnumOutp, string> Field { get; }
}
