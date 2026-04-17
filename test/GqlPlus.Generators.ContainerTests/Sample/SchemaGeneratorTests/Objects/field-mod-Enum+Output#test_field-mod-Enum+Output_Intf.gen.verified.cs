//HintName: test_field-mod-Enum+Output_Intf.gen.cs
// Generated from {CurrentDirectory}field-mod-Enum+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_Enum_Output;

public interface ItestFieldModEnumOutp
  : IGqlpInterfaceBase
{
  ItestFieldModEnumOutpObject? As_FieldModEnumOutp { get; }
}

public interface ItestFieldModEnumOutpObject
  : IGqlpInterfaceBase
{
  IDictionary<testEnumFieldModEnumOutp, string> Field { get; }
}

public enum testEnumFieldModEnumOutp
{
  value,
}
