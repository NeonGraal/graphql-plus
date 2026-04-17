//HintName: test_output-param-descr_Intf.gen.cs
// Generated from {CurrentDirectory}output-param-descr.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_descr;

public interface ItestOutpParamDescr
  : IGqlpInterfaceBase
{
  ItestOutpParamDescrObject? As_OutpParamDescr { get; }
}

public interface ItestOutpParamDescrObject
  : IGqlpInterfaceBase
{
  ItestFldOutpParamDescr? Field(ItestInOutpParamDescr parameter);
  ItestFldOutpParamDescr? Field();
}

public interface ItestFldOutpParamDescr
  : IGqlpInterfaceBase
{
  ItestFldOutpParamDescrObject? As_FldOutpParamDescr { get; }
}

public interface ItestFldOutpParamDescrObject
  : IGqlpInterfaceBase
{
}

public interface ItestInOutpParamDescr
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestInOutpParamDescrObject? As_InOutpParamDescr { get; }
}

public interface ItestInOutpParamDescrObject
  : IGqlpInterfaceBase
{
  decimal Param { get; }
}
