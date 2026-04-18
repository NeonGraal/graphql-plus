//HintName: test_generic-alt-mod-param+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-mod-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_mod_param_Output;

public class testRefGnrcAltModParamOutp<TRef,TMod>
  : GqlpModelBase
  , ItestRefGnrcAltModParamOutp<TRef,TMod>
{
  public IDictionary<TMod, TRef>? Asref { get; set; }
  public ItestRefGnrcAltModParamOutpObject<TRef,TMod>? As_RefGnrcAltModParamOutp { get; set; }
}

public class testRefGnrcAltModParamOutpObject<TRef,TMod>
  : GqlpModelBase
  , ItestRefGnrcAltModParamOutpObject<TRef,TMod>
{

  public testRefGnrcAltModParamOutpObject
    ()
  {
  }
}
