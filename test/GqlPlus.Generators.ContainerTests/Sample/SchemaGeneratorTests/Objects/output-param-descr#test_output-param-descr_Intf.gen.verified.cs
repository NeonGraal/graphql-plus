//HintName: test_output-param-descr_Intf.gen.cs
// Generated from {CurrentDirectory}output-param-descr.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_descr;

public interface ItestOutpParamDescr
  : IGqlpModelImplementationBase
{
  ItestOutpParamDescrObject? As_OutpParamDescr { get; }
}

public interface ItestOutpParamDescrObject
  : IGqlpModelImplementationBase
{
  ItestFldOutpParamDescr? Field(ItestInOutpParamDescr parameter);
}

public interface ItestFldOutpParamDescr
  : IGqlpModelImplementationBase
{
  ItestFldOutpParamDescrObject? As_FldOutpParamDescr { get; }
}

public interface ItestFldOutpParamDescrObject
  : IGqlpModelImplementationBase
{
}

public interface ItestInOutpParamDescr
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestInOutpParamDescrObject? As_InOutpParamDescr { get; }
}

public interface ItestInOutpParamDescrObject
  : IGqlpModelImplementationBase
{
  decimal Param { get; }
}
