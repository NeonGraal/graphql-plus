//HintName: test_generic-alt-arg+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Input;

public class testGnrcAltArgInp<TType>
  : GqlpEncoderBase
  , ItestGnrcAltArgInp<TType>
{
  public ItestRefGnrcAltArgInp<TType>? AsRefGnrcAltArgInp { get; set; }
  public ItestGnrcAltArgInpObject<TType>? As_GnrcAltArgInp { get; set; }
}

public class testGnrcAltArgInpObject<TType>
  : GqlpEncoderBase
  , ItestGnrcAltArgInpObject<TType>
{

  public testGnrcAltArgInpObject
    ()
  {
  }
}

public class testRefGnrcAltArgInp<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltArgInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltArgInpObject<TRef>? As_RefGnrcAltArgInp { get; set; }
}

public class testRefGnrcAltArgInpObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltArgInpObject<TRef>
{

  public testRefGnrcAltArgInpObject
    ()
  {
  }
}
