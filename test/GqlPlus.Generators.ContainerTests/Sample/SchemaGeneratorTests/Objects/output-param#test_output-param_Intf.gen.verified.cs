//HintName: test_output-param_Intf.gen.cs
// Generated from {CurrentDirectory}output-param.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param;

public interface ItestOutpParam
  : IGqlpInterfaceBase
{
  ItestOutpParamObject? As_OutpParam { get; }
}

public interface ItestOutpParamObject
  : IGqlpInterfaceBase
{
  ItestFldOutpParam Field { get; }
  ItestFldOutpParam? Call_Field(ItestInOutpParam parameter);
}

public interface ItestFldOutpParam
  : IGqlpInterfaceBase
{
  ItestFldOutpParamObject? As_FldOutpParam { get; }
}

public interface ItestFldOutpParamObject
  : IGqlpInterfaceBase
{
}

public interface ItestInOutpParam
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestInOutpParamObject? As_InOutpParam { get; }
}

public interface ItestInOutpParamObject
  : IGqlpInterfaceBase
{
  decimal Param { get; }
}
