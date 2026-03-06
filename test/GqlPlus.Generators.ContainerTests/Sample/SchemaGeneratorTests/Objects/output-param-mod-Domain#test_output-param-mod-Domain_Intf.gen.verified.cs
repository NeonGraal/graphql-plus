//HintName: test_output-param-mod-Domain_Intf.gen.cs
// Generated from {CurrentDirectory}output-param-mod-Domain.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_Domain;

public interface ItestOutpParamModDmn
  : IGqlpModelImplementationBase
{
  ItestOutpParamModDmnObject? As_OutpParamModDmn { get; }
}

public interface ItestOutpParamModDmnObject
  : IGqlpModelImplementationBase
{
  ItestDomOutpParamModDmn? Field(IDictionary<ItestDomOutpParamModDmn, ItestInOutpParamModDmn> parameter);
}

public interface ItestInOutpParamModDmn
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestInOutpParamModDmnObject? As_InOutpParamModDmn { get; }
}

public interface ItestInOutpParamModDmnObject
  : IGqlpModelImplementationBase
{
  decimal Param { get; }
}

public interface ItestDomOutpParamModDmn
  : IGqlpDomainNumber
{
}
