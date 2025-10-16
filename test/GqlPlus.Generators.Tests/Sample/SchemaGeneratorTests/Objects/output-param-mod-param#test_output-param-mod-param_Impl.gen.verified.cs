//HintName: test_output-param-mod-param_Impl.gen.cs
// Generated from output-param-mod-param.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_param;

public class testOutpParamModParam<Tmod>
  : ItestOutpParamModParam<Tmod>
{
  public DomOutpParamModParam field { get; set; }
}

public class testInOutpParamModParam
  : ItestInOutpParamModParam
{
  public Number param { get; set; }
  public String AsString { get; set; }
}

public class testDomOutpParamModParam
  : ItestDomOutpParamModParam
{
}
