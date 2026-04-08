//HintName: test_alt-enum+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}alt-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_enum_Dual;

public class testAltEnumDual
  : GqlpEncoderBase
  , ItestAltEnumDual
{
  public testEnumAltEnumDual? AsEnumAltEnumDualaltEnumDual { get; set; }
  public ItestAltEnumDualObject? As_AltEnumDual { get; set; }
}

public class testAltEnumDualObject
  : GqlpEncoderBase
  , ItestAltEnumDualObject
{

  public testAltEnumDualObject
    ()
  {
  }
}

public enum testEnumAltEnumDual
{
  altEnumDual,
}
