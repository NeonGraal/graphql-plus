//HintName: test_output-param-mod-param_Intf.gen.cs
// Generated from {CurrentDirectory}output-param-mod-param.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_param;

public interface ItestOutpParamModParam<TMod>
  : IGqlpModelImplementationBase
{
  ItestOutpParamModParamObject<TMod>? As_OutpParamModParam { get; }
}

public interface ItestOutpParamModParamObject<TMod>
  : IGqlpModelImplementationBase
{
  ItestDomOutpParamModParam? Field(IDictionary<TMod, ItestInOutpParamModParam> parameter);
}

public interface ItestInOutpParamModParam
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestInOutpParamModParamObject? As_InOutpParamModParam { get; }
}

public interface ItestInOutpParamModParamObject
  : IGqlpModelImplementationBase
{
  decimal Param { get; }
}

public interface ItestDomOutpParamModParam
  : IGqlpDomainNumber
{
}
