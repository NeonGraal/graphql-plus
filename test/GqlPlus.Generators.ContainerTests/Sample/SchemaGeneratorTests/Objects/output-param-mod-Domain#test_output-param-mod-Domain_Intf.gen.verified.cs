//HintName: test_output-param-mod-Domain_Intf.gen.cs
// Generated from output-param-mod-Domain.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_Domain;

public interface ItestOutpParamModDmn
{
  public ItestOutpParamModDmnObject AsOutpParamModDmn { get; set; }
}

public interface ItestOutpParamModDmnObject
{
  public ItestDomOutpParamModDmn Field { get; set; }
}

public interface ItestInOutpParamModDmn
{
  public ItestString AsString { get; set; }
  public ItestInOutpParamModDmnObject AsInOutpParamModDmn { get; set; }
}

public interface ItestInOutpParamModDmnObject
{
  public ItestNumber Param { get; set; }
}

public interface ItestDomOutpParamModDmn
  : IDomainNumber
{
}
