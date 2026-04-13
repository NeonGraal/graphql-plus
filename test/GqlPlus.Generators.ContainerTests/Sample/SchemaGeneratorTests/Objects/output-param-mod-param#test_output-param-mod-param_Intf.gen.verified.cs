//HintName: test_output-param-mod-param_Intf.gen.cs
// Generated from {CurrentDirectory}output-param-mod-param.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_param;

public interface ItestOutpParamModParam<TMod>
  : IGqlpInterfaceBase
{
  ItestOutpParamModParamObject<TMod>? As_OutpParamModParam { get; }
}

public interface ItestOutpParamModParamObject<TMod>
  : IGqlpInterfaceBase
{
  ItestDomOutpParamModParam? Field(IDictionary<TMod, ItestInOutpParamModParam> parameter);
  ItestDomOutpParamModParam? Field();
}

public interface ItestInOutpParamModParam
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestInOutpParamModParamObject? As_InOutpParamModParam { get; }
}

public interface ItestInOutpParamModParamObject
  : IGqlpInterfaceBase
{
  decimal Param { get; }
}

public interface ItestDomOutpParamModParam
  : IGqlpDomainNumber
{
}
