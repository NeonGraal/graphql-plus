//HintName: test_alt-enum+Output_Enc.gen.cs
// Generated from {CurrentDirectory}alt-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_enum_Output;

public class testAltEnumOutp
  : GqlpEncoderBase
  , ItestAltEnumOutp
{
  public testEnumAltEnumOutp? AsEnumAltEnumOutpaltEnumOutp { get; set; }
  public ItestAltEnumOutpObject? As_AltEnumOutp { get; set; }
}

public class testAltEnumOutpObject
  : GqlpEncoderBase
  , ItestAltEnumOutpObject
{

  public testAltEnumOutpObject
    ()
  {
  }
}

public enum testEnumAltEnumOutp
{
  altEnumOutp,
}
