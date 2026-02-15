//HintName: test_output-param-mod-param_Impl.gen.cs
// Generated from output-param-mod-param.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_param;

public class testOutpParamModParam<TMod>
  : ItestOutpParamModParam<TMod>
{
  public ItestDomOutpParamModParam Field { get; set; }
}

public class testInOutpParamModParam
  : ItestInOutpParamModParam
{
  public decimal Param { get; set; }
}

public class testDomOutpParamModParam
  : GqlpDomainNumber
  , ItestDomOutpParamModParam
{
}
