//HintName: test_output-param-mod-param_Impl.gen.cs
// Generated from {CurrentDirectory}output-param-mod-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_param;

public class testOutpParamModParam<TMod>
  : ItestOutpParamModParam<TMod>
{
  public ItestDomOutpParamModParam Field (IDictionary<TMod, ItestInOutpParamModParam>)
{ }
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
