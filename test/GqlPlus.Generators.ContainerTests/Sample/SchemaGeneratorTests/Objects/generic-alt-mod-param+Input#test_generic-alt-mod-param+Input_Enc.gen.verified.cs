//HintName: test_generic-alt-mod-param+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-mod-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_mod_param_Input;

public class testRefGnrcAltModParamInp<TRef,TMod>
  : GqlpEncoderBase
  , ItestRefGnrcAltModParamInp<TRef,TMod>
{
  public IDictionary<TMod, TRef>? Asref { get; set; }
  public ItestRefGnrcAltModParamInpObject<TRef,TMod>? As_RefGnrcAltModParamInp { get; set; }
}

public class testRefGnrcAltModParamInpObject<TRef,TMod>
  : GqlpEncoderBase
  , ItestRefGnrcAltModParamInpObject<TRef,TMod>
{

  public testRefGnrcAltModParamInpObject
    ()
  {
  }
}
