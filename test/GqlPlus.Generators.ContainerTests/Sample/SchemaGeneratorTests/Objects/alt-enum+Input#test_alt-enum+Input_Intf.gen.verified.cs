//HintName: test_alt-enum+Input_Intf.gen.cs
// Generated from {CurrentDirectory}alt-enum+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_enum_Input;

public interface ItestAltEnumInp
  : IGqlpInterfaceBase
{
  testEnumAltEnumInp? AsEnumAltEnumInpaltEnumInp { get; }
  ItestAltEnumInpObject? As_AltEnumInp { get; }
}

public interface ItestAltEnumInpObject
  : IGqlpInterfaceBase
{
}

public enum testEnumAltEnumInp
{
  altEnumInp,
}
