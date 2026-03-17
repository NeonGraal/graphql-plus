//HintName: test_output-param-mod-param_Model.gen.cs
// Generated from {CurrentDirectory}output-param-mod-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_param;

public class testOutpParamModParam<TMod>
  : GqlpModelImplementationBase
  , ItestOutpParamModParam<TMod>
{
  public ItestOutpParamModParamObject<TMod>? As_OutpParamModParam { get; set; }
}

public class testOutpParamModParamObject<TMod>
  : GqlpModelImplementationBase
  , ItestOutpParamModParamObject<TMod>
{
  public ItestDomOutpParamModParam? Field(IDictionary<TMod, ItestInOutpParamModParam> parameter)
    => null;
}

public class testInOutpParamModParam
  : GqlpModelImplementationBase
  , ItestInOutpParamModParam
{
  public string? AsString { get; set; }
  public ItestInOutpParamModParamObject? As_InOutpParamModParam { get; set; }
}

public class testInOutpParamModParamObject
  : GqlpModelImplementationBase
  , ItestInOutpParamModParamObject
{
  public decimal Param { get; set; }

  public testInOutpParamModParamObject
    ( decimal param
    )
  {
    Param = param;
  }
}

public class testDomOutpParamModParam
  : GqlpDomainNumber
  , ItestDomOutpParamModParam
{
}
