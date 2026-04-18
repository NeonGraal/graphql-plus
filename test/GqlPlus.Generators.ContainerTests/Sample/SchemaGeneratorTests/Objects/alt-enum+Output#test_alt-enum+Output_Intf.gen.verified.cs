//HintName: test_alt-enum+Output_Intf.gen.cs
// Generated from {CurrentDirectory}alt-enum+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_enum_Output;

public interface ItestAltEnumOutp
  : IGqlpInterfaceBase
{
  testEnumAltEnumOutp? AsEnumAltEnumOutpaltEnumOutp { get; }
  ItestAltEnumOutpObject? As_AltEnumOutp { get; }
}

public interface ItestAltEnumOutpObject
  : IGqlpInterfaceBase
{
}

public enum testEnumAltEnumOutp
{
  altEnumOutp,
}
