//HintName: test_output-param-type-descr_Intf.gen.cs
// Generated from {CurrentDirectory}output-param-type-descr.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_type_descr;

public interface ItestOutpParamTypeDescr
  : IGqlpInterfaceBase
{
  ItestOutpParamTypeDescrObject? As_OutpParamTypeDescr { get; }
}

public interface ItestOutpParamTypeDescrObject
  : IGqlpInterfaceBase
{
  ItestFldOutpParamTypeDescr? Field(ItestInOutpParamTypeDescr parameter);
  ItestFldOutpParamTypeDescr? Field();
}

public interface ItestFldOutpParamTypeDescr
  : IGqlpInterfaceBase
{
  ItestFldOutpParamTypeDescrObject? As_FldOutpParamTypeDescr { get; }
}

public interface ItestFldOutpParamTypeDescrObject
  : IGqlpInterfaceBase
{
}

public interface ItestInOutpParamTypeDescr
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestInOutpParamTypeDescrObject? As_InOutpParamTypeDescr { get; }
}

public interface ItestInOutpParamTypeDescrObject
  : IGqlpInterfaceBase
{
  decimal Param { get; }
}
