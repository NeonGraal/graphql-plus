//HintName: test_alt-enum+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}alt-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_enum_Dual;

public interface ItestAltEnumDual
  : IGqlpModelImplementationBase
{
  testEnumAltEnumDual? AsEnumAltEnumDualaltEnumDual { get; }
  ItestAltEnumDualObject? As_AltEnumDual { get; }
}

public interface ItestAltEnumDualObject
  : IGqlpModelImplementationBase
{
}

public enum testEnumAltEnumDual
{
  altEnumDual,
}
