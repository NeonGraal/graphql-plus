//HintName: test_generic-alt-mod-param+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-mod-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_mod_param_Output;

public class testRefGnrcAltModParamOutp<TRef,TMod>
  : GqlpEncoderBase
  , ItestRefGnrcAltModParamOutp<TRef,TMod>
{
  public IDictionary<TMod, TRef>? Asref { get; set; }
  public ItestRefGnrcAltModParamOutpObject<TRef,TMod>? As_RefGnrcAltModParamOutp { get; set; }
}

public class testRefGnrcAltModParamOutpObject<TRef,TMod>
  : GqlpEncoderBase
  , ItestRefGnrcAltModParamOutpObject<TRef,TMod>
{

  public testRefGnrcAltModParamOutpObject
    ()
  {
  }
}
