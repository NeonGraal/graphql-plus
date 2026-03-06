//HintName: test_output-param-type-descr_Intf.gen.cs
// Generated from {CurrentDirectory}output-param-type-descr.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_type_descr;

public interface ItestOutpParamTypeDescr
  : IGqlpModelImplementationBase
{
  ItestOutpParamTypeDescrObject? As_OutpParamTypeDescr { get; }
}

public interface ItestOutpParamTypeDescrObject
  : IGqlpModelImplementationBase
{
  ItestFldOutpParamTypeDescr? Field(ItestInOutpParamTypeDescr parameter);
}

public interface ItestFldOutpParamTypeDescr
  : IGqlpModelImplementationBase
{
  ItestFldOutpParamTypeDescrObject? As_FldOutpParamTypeDescr { get; }
}

public interface ItestFldOutpParamTypeDescrObject
  : IGqlpModelImplementationBase
{
}

public interface ItestInOutpParamTypeDescr
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestInOutpParamTypeDescrObject? As_InOutpParamTypeDescr { get; }
}

public interface ItestInOutpParamTypeDescrObject
  : IGqlpModelImplementationBase
{
  decimal Param { get; }
}
