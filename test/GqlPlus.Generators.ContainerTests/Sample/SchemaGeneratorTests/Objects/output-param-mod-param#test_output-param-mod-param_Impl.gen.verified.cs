//HintName: test_output-param-mod-param_Impl.gen.cs
// Generated from output-param-mod-param.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_param;

public class testOutpParamModParam<Tmod>
  : ItestOutpParamModParam<Tmod>
{
  public ItestDomOutpParamModParam Field { get; set; }
  public ItestOutpParamModParamObject AsOutpParamModParam { get; set; }
}

public class testInOutpParamModParam
  : ItestInOutpParamModParam
{
  public decimal Param { get; set; }
  public string AsString { get; set; }
  public ItestInOutpParamModParamObject AsInOutpParamModParam { get; set; }
}

public class testDomOutpParamModParam
  : DomainNumber
  , ItestDomOutpParamModParam
{
}
