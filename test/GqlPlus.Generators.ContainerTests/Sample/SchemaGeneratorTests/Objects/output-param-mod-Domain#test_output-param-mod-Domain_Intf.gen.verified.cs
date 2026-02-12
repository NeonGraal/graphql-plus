//HintName: test_output-param-mod-Domain_Intf.gen.cs
// Generated from output-param-mod-Domain.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_Domain;

public interface ItestOutpParamModDmn
{
  ItestOutpParamModDmnObject AsOutpParamModDmn { get; }
}

public interface ItestOutpParamModDmnObject
{
  ItestDomOutpParamModDmn Field { get; }
}

public interface ItestInOutpParamModDmn
{
  string AsString { get; }
  ItestInOutpParamModDmnObject AsInOutpParamModDmn { get; }
}

public interface ItestInOutpParamModDmnObject
{
  decimal Param { get; }
}

public interface ItestDomOutpParamModDmn
  : IGqlpDomainNumber
{
}
