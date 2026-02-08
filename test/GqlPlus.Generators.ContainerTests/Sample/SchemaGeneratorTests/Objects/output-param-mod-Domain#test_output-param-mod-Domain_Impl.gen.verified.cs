//HintName: test_output-param-mod-Domain_Impl.gen.cs
// Generated from output-param-mod-Domain.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_Domain;

public class testOutpParamModDmn
  : ItestOutpParamModDmn
{
  public ItestDomOutpParamModDmn Field { get; set; }
}

public class testInOutpParamModDmn
  : ItestInOutpParamModDmn
{
  public ItestNumber Param { get; set; }
  public ItestString AsString { get; set; }
}

public class testDomOutpParamModDmn
  : DomainNumber
  , ItestDomOutpParamModDmn
{
}
