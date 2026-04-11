//HintName: test_alt-enum+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}alt-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_enum_Dual;

public interface ItestAltEnumDual
  : IGqlpInterfaceBase
{
  testEnumAltEnumDual? AsEnumAltEnumDualaltEnumDual { get; }
  ItestAltEnumDualObject? As_AltEnumDual { get; }
}

public interface ItestAltEnumDualObject
  : IGqlpInterfaceBase
{
}

public enum testEnumAltEnumDual
{
  altEnumDual,
}
