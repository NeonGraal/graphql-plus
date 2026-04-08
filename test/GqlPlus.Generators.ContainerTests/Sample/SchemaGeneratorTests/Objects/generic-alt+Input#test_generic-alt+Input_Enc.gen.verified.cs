//HintName: test_generic-alt+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_Input;

public class testGnrcAltInp<TType>
  : GqlpEncoderBase
  , ItestGnrcAltInp<TType>
{
  public TType? Astype { get; set; }
  public ItestGnrcAltInpObject<TType>? As_GnrcAltInp { get; set; }
}

public class testGnrcAltInpObject<TType>
  : GqlpEncoderBase
  , ItestGnrcAltInpObject<TType>
{

  public testGnrcAltInpObject
    ()
  {
  }
}
