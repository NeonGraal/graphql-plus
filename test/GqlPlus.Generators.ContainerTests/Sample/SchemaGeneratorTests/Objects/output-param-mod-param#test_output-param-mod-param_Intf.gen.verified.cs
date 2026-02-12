//HintName: test_output-param-mod-param_Intf.gen.cs
// Generated from output-param-mod-param.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_param;

public interface ItestOutpParamModParam<TMod>
{
  ItestOutpParamModParamObject<TMod> AsOutpParamModParam { get; }
}

public interface ItestOutpParamModParamObject<TMod>
{
  ItestDomOutpParamModParam Field { get; }
}

public interface ItestInOutpParamModParam
{
  string AsString { get; }
  ItestInOutpParamModParamObject AsInOutpParamModParam { get; }
}

public interface ItestInOutpParamModParamObject
{
  decimal Param { get; }
}

public interface ItestDomOutpParamModParam
  : IDomainNumber
{
}
