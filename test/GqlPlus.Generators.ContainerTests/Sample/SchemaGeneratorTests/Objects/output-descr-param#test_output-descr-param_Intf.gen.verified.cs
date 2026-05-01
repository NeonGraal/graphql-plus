//HintName: test_output-descr-param_Intf.gen.cs
// Generated from {CurrentDirectory}output-descr-param.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_descr_param;

public interface ItestOutpDescrParam
  : IGqlpInterfaceBase
{
  ItestOutpDescrParamObject? As_OutpDescrParam { get; }
}

public interface ItestOutpDescrParamObject
  : IGqlpInterfaceBase
{
  ItestFldOutpDescrParam Field { get; }
  ItestFldOutpDescrParam? Call_Field(ItestInOutpDescrParam parameter);
}

public interface ItestFldOutpDescrParam
  : IGqlpInterfaceBase
{
  ItestFldOutpDescrParamObject? As_FldOutpDescrParam { get; }
}

public interface ItestFldOutpDescrParamObject
  : IGqlpInterfaceBase
{
}

public interface ItestInOutpDescrParam
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestInOutpDescrParamObject? As_InOutpDescrParam { get; }
}

public interface ItestInOutpDescrParamObject
  : IGqlpInterfaceBase
{
  decimal Param { get; }
}
