//HintName: test_alt-mod-param+Dual_Model.gen.cs
// Generated from {CurrentDirectory}alt-mod-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Dual;

public class testAltModParamDual<TMod>
  : GqlpModelBase
  , ItestAltModParamDual<TMod>
{
  public IDictionary<TMod, ItestAltAltModParamDual>? AsAltAltModParamDual { get; set; }
  public ItestAltModParamDualObject<TMod>? As_AltModParamDual { get; set; }
}

public class testAltModParamDualObject<TMod>
  : GqlpModelBase
  , ItestAltModParamDualObject<TMod>
{

  public testAltModParamDualObject
    ()
  {
  }
}

public class testAltAltModParamDual
  : GqlpModelBase
  , ItestAltAltModParamDual
{
  public string? AsString { get; set; }
  public ItestAltAltModParamDualObject? As_AltAltModParamDual { get; set; }
}

public class testAltAltModParamDualObject
  : GqlpModelBase
  , ItestAltAltModParamDualObject
{
  public decimal Alt { get; set; }

  public testAltAltModParamDualObject
    ( decimal palt
    )
  {
    Alt = palt;
  }
}
