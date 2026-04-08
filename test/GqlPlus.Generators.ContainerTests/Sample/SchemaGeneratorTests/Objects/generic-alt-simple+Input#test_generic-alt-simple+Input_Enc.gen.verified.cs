//HintName: test_generic-alt-simple+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Input;

public class testGnrcAltSmplInp
  : GqlpEncoderBase
  , ItestGnrcAltSmplInp
{
  public ItestRefGnrcAltSmplInp<string>? AsRefGnrcAltSmplInp { get; set; }
  public ItestGnrcAltSmplInpObject? As_GnrcAltSmplInp { get; set; }
}

public class testGnrcAltSmplInpObject
  : GqlpEncoderBase
  , ItestGnrcAltSmplInpObject
{

  public testGnrcAltSmplInpObject
    ()
  {
  }
}

public class testRefGnrcAltSmplInp<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltSmplInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltSmplInpObject<TRef>? As_RefGnrcAltSmplInp { get; set; }
}

public class testRefGnrcAltSmplInpObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltSmplInpObject<TRef>
{

  public testRefGnrcAltSmplInpObject
    ()
  {
  }
}
