//HintName: Gqlp_output-param-mod-param_Impl.gen.cs
// Generated from output-param-mod-param.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_output_param_mod_param;
public class OutputOutpParamModParam<Tmod>
  : IOutpParamModParam<Tmod>
{
  public DomOutpParamModParam field { get; set; }
}
public class InputInOutpParamModParam
  : IInOutpParamModParam
{
  public Number param { get; set; }
  public String AsString { get; set; }
}
public class DomainDomOutpParamModParam
  : IDomOutpParamModParam
{
}
