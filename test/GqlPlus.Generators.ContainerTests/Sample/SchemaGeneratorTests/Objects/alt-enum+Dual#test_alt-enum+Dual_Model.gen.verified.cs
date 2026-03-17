//HintName: test_alt-enum+Dual_Model.gen.cs
// Generated from {CurrentDirectory}alt-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_enum_Dual;

public class testAltEnumDual
  : GqlpModelImplementationBase
  , ItestAltEnumDual
{
  public testEnumAltEnumDual? AsEnumAltEnumDualaltEnumDual { get; set; }
  public ItestAltEnumDualObject? As_AltEnumDual { get; set; }
}

public class testAltEnumDualObject
  : GqlpModelImplementationBase
  , ItestAltEnumDualObject
{
}
