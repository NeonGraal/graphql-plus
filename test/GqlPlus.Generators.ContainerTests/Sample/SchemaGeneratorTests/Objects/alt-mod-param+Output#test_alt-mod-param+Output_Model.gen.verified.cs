//HintName: test_alt-mod-param+Output_Model.gen.cs
// Generated from {CurrentDirectory}alt-mod-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Output;

public class testAltModParamOutp<TMod>
  : GqlpModelBase
  , ItestAltModParamOutp<TMod>
{
  public IDictionary<TMod, ItestAltAltModParamOutp>? AsAltAltModParamOutp { get; set; }
  public ItestAltModParamOutpObject<TMod>? As_AltModParamOutp { get; set; }
}

public class testAltModParamOutpObject<TMod>
  : GqlpModelBase
  , ItestAltModParamOutpObject<TMod>
{

  public testAltModParamOutpObject
    ()
  {
  }
}

public class testAltAltModParamOutp
  : GqlpModelBase
  , ItestAltAltModParamOutp
{
  public string? AsString { get; set; }
  public ItestAltAltModParamOutpObject? As_AltAltModParamOutp { get; set; }
}

public class testAltAltModParamOutpObject
  : GqlpModelBase
  , ItestAltAltModParamOutpObject
{
  public decimal Alt { get; set; }

  public testAltAltModParamOutpObject
    ( decimal palt
    )
  {
    Alt = palt;
  }
}
