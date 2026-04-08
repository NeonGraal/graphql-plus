//HintName: test_alt-enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}alt-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_enum_Input;

public class testAltEnumInp
  : GqlpEncoderBase
  , ItestAltEnumInp
{
  public testEnumAltEnumInp? AsEnumAltEnumInpaltEnumInp { get; set; }
  public ItestAltEnumInpObject? As_AltEnumInp { get; set; }
}

public class testAltEnumInpObject
  : GqlpEncoderBase
  , ItestAltEnumInpObject
{

  public testAltEnumInpObject
    ()
  {
  }
}

public enum testEnumAltEnumInp
{
  altEnumInp,
}
