//HintName: test_output-param-mod-param_Intf.gen.cs
// Generated from output-param-mod-param.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_param;

public interface ItestOutpParamModParam<Tmod>
{
}

public interface ItestOutpParamModParamObject<Tmod>
{
  public ItestDomOutpParamModParam Field { get; set; }
}

public interface ItestInOutpParamModParam
{
  public ItestString AsString { get; set; }
}

public interface ItestInOutpParamModParamObject
{
  public ItestNumber Param { get; set; }
}

public interface ItestDomOutpParamModParam
  : IDomainNumber
{
}
