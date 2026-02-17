//HintName: test_output-param-mod-Domain_Impl.gen.cs
// Generated from {CurrentDirectory}output-param-mod-Domain.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_Domain;

public class testOutpParamModDmn
  : ItestOutpParamModDmn
{
  public ItestDomOutpParamModDmn Field (IDictionary<ItestDomOutpParamModDmn, ItestInOutpParamModDmn>)
{ }
}

public class testInOutpParamModDmn
  : ItestInOutpParamModDmn
{
  public decimal Param { get; set; }
}

public class testDomOutpParamModDmn
  : GqlpDomainNumber
  , ItestDomOutpParamModDmn
{
}
