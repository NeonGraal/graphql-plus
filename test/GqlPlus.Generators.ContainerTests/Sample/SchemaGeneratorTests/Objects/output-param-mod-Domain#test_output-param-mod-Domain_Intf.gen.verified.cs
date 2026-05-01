//HintName: test_output-param-mod-Domain_Intf.gen.cs
// Generated from {CurrentDirectory}output-param-mod-Domain.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_Domain;

public interface ItestOutpParamModDmn
  : IGqlpInterfaceBase
{
  ItestOutpParamModDmnObject? As_OutpParamModDmn { get; }
}

public interface ItestOutpParamModDmnObject
  : IGqlpInterfaceBase
{
  ItestDomOutpParamModDmn Field { get; }
  ItestDomOutpParamModDmn? Call_Field(IDictionary<ItestDomOutpParamModDmn, ItestInOutpParamModDmn> parameter);
}

public interface ItestInOutpParamModDmn
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestInOutpParamModDmnObject? As_InOutpParamModDmn { get; }
}

public interface ItestInOutpParamModDmnObject
  : IGqlpInterfaceBase
{
  decimal Param { get; }
}

public interface ItestDomOutpParamModDmn
  : IGqlpDomainNumber
{
}
