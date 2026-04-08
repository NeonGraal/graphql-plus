//HintName: test_output-param-mod-Domain_Dec.gen.cs
// Generated from {CurrentDirectory}output-param-mod-Domain.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_Domain;

public interface ItestOutpParamModDmn
  // No Base because it's Class
{
  ItestOutpParamModDmnObject? As_OutpParamModDmn { get; }
}

public interface ItestOutpParamModDmnObject
  // No Base because it's Class
{
  ItestDomOutpParamModDmn? Field(IDictionary<ItestDomOutpParamModDmn, ItestInOutpParamModDmn> parameter);
}

public interface ItestInOutpParamModDmn
  // No Base because it's Class
{
  string? AsString { get; }
  ItestInOutpParamModDmnObject? As_InOutpParamModDmn { get; }
}

public interface ItestInOutpParamModDmnObject
  // No Base because it's Class
{
  decimal Param { get; }
}

public interface ItestDomOutpParamModDmn
  : IGqlpDomainNumber
{
}
