//HintName: test_alt-mod-param+Input_Model.gen.cs
// Generated from {CurrentDirectory}alt-mod-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Input;

public class testAltModParamInp<TMod>
  : GqlpModelBase
  , ItestAltModParamInp<TMod>
{
  public IDictionary<TMod, ItestAltAltModParamInp>? AsAltAltModParamInp { get; set; }
  public ItestAltModParamInpObject<TMod>? As_AltModParamInp { get; set; }
}

public class testAltModParamInpObject<TMod>
  : GqlpModelBase
  , ItestAltModParamInpObject<TMod>
{

  public testAltModParamInpObject
    ()
  {
  }
}

public class testAltAltModParamInp
  : GqlpModelBase
  , ItestAltAltModParamInp
{
  public string? AsString { get; set; }
  public ItestAltAltModParamInpObject? As_AltAltModParamInp { get; set; }
}

public class testAltAltModParamInpObject
  : GqlpModelBase
  , ItestAltAltModParamInpObject
{
  public decimal Alt { get; set; }

  public testAltAltModParamInpObject
    ( decimal palt
    )
  {
    Alt = palt;
  }
}
