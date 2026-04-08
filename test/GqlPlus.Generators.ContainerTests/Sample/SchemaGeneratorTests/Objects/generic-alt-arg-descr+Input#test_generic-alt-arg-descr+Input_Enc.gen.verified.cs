//HintName: test_generic-alt-arg-descr+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Input;

public class testGnrcAltArgDescrInp<TType>
  : GqlpEncoderBase
  , ItestGnrcAltArgDescrInp<TType>
{
  public ItestRefGnrcAltArgDescrInp<TType>? AsRefGnrcAltArgDescrInp { get; set; }
  public ItestGnrcAltArgDescrInpObject<TType>? As_GnrcAltArgDescrInp { get; set; }
}

public class testGnrcAltArgDescrInpObject<TType>
  : GqlpEncoderBase
  , ItestGnrcAltArgDescrInpObject<TType>
{

  public testGnrcAltArgDescrInpObject
    ()
  {
  }
}

public class testRefGnrcAltArgDescrInp<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltArgDescrInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltArgDescrInpObject<TRef>? As_RefGnrcAltArgDescrInp { get; set; }
}

public class testRefGnrcAltArgDescrInpObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltArgDescrInpObject<TRef>
{

  public testRefGnrcAltArgDescrInpObject
    ()
  {
  }
}
