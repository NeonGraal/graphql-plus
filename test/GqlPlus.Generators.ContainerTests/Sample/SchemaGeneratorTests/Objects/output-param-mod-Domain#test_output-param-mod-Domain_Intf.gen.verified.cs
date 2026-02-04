//HintName: test_output-param-mod-Domain_Intf.gen.cs
// Generated from output-param-mod-Domain.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_Domain;

public interface ItestOutpParamModDmn
{
  public testOutpParamModDmn OutpParamModDmn { get; set; }
}

public interface ItestOutpParamModDmnObject
{
  public testDomOutpParamModDmn field { get; set; }
}

public interface ItestInOutpParamModDmn
{
  public testString AsString { get; set; }
  public testInOutpParamModDmn InOutpParamModDmn { get; set; }
}

public interface ItestInOutpParamModDmnObject
{
  public testNumber param { get; set; }
}

public interface ItestDomOutpParamModDmn
  : IDomainNumber
{
}
