//HintName: test_generic-alt-mod-param+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-mod-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_mod_param_Dual;

public class testRefGnrcAltModParamDual<TRef,TMod>
  : GqlpModelBase
  , ItestRefGnrcAltModParamDual<TRef,TMod>
{
  public IDictionary<TMod, TRef>? Asref { get; set; }
  public ItestRefGnrcAltModParamDualObject<TRef,TMod>? As_RefGnrcAltModParamDual { get; set; }
}

public class testRefGnrcAltModParamDualObject<TRef,TMod>
  : GqlpModelBase
  , ItestRefGnrcAltModParamDualObject<TRef,TMod>
{

  public testRefGnrcAltModParamDualObject
    ()
  {
  }
}
