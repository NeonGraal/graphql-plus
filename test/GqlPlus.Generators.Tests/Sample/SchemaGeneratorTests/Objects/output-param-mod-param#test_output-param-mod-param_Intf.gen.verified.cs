//HintName: test_output-param-mod-param_Intf.gen.cs
// Generated from output-param-mod-param.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_param;

public interface ItestOutpParamModParam<Tmod>
{
  public testOutpParamModParam OutpParamModParam { get; set; }
}

public interface ItestOutpParamModParamField<Tmod>
{
  public testDomOutpParamModParam field { get; set; }
}

public interface ItestInOutpParamModParam
{
  public testString AsString { get; set; }
  public testInOutpParamModParam InOutpParamModParam { get; set; }
}

public interface ItestInOutpParamModParamField
{
  public testNumber param { get; set; }
}

public interface ItestDomOutpParamModParam
  : IDomainNumber
{
}
