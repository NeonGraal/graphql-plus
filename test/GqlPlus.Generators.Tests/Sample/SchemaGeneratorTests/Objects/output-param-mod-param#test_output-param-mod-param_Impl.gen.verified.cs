//HintName: test_output-param-mod-param_Impl.gen.cs
// Generated from output-param-mod-param.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_param;

public class testOutpParamModParam<Tmod>
  : ItestOutpParamModParam<Tmod>
{
  public testDomOutpParamModParam field { get; set; }
  public testOutpParamModParam OutpParamModParam { get; set; }
}

public class testInOutpParamModParam
  : ItestInOutpParamModParam
{
  public testNumber param { get; set; }
  public testString AsString { get; set; }
  public testInOutpParamModParam InOutpParamModParam { get; set; }
}

public class testDomOutpParamModParam
  : DomainNumber
  , ItestDomOutpParamModParam
{
}
