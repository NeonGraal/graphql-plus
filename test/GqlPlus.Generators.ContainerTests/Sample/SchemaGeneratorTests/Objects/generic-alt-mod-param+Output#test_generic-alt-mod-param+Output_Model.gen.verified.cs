//HintName: test_generic-alt-mod-param+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-mod-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_mod_param_Output;

public class testRefGnrcAltModParamOutp<TRef,TMod>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltModParamOutp<TRef,TMod>
{
  public IDictionary<TMod, TRef>? Asref { get; set; }
  public ItestRefGnrcAltModParamOutpObject<TRef,TMod>? As_RefGnrcAltModParamOutp { get; set; }
}

public class testRefGnrcAltModParamOutpObject<TRef,TMod>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltModParamOutpObject<TRef,TMod>
{

  public testRefGnrcAltModParamOutpObject
    ()
  {
  }
}
