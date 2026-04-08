//HintName: test_output-param-mod-param_Dec.gen.cs
// Generated from {CurrentDirectory}output-param-mod-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_param;

public interface ItestOutpParamModParam<TMod>
  // No Base because it's Class
{
  ItestOutpParamModParamObject<TMod>? As_OutpParamModParam { get; }
}

public interface ItestOutpParamModParamObject<TMod>
  // No Base because it's Class
{
  ItestDomOutpParamModParam? Field(IDictionary<TMod, ItestInOutpParamModParam> parameter);
}

public interface ItestInOutpParamModParam
  // No Base because it's Class
{
  string? AsString { get; }
  ItestInOutpParamModParamObject? As_InOutpParamModParam { get; }
}

public interface ItestInOutpParamModParamObject
  // No Base because it's Class
{
  decimal Param { get; }
}

public interface ItestDomOutpParamModParam
  : IGqlpDomainNumber
{
}
