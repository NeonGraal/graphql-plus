//HintName: test_output-descr-param_Intf.gen.cs
// Generated from {CurrentDirectory}output-descr-param.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_descr_param;

public interface ItestOutpDescrParam
  : IGqlpModelImplementationBase
{
  ItestOutpDescrParamObject? As_OutpDescrParam { get; }
}

public interface ItestOutpDescrParamObject
  : IGqlpModelImplementationBase
{
  ItestFldOutpDescrParam? Field(ItestInOutpDescrParam parameter);
}

public interface ItestFldOutpDescrParam
  : IGqlpModelImplementationBase
{
  ItestFldOutpDescrParamObject? As_FldOutpDescrParam { get; }
}

public interface ItestFldOutpDescrParamObject
  : IGqlpModelImplementationBase
{
}

public interface ItestInOutpDescrParam
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestInOutpDescrParamObject? As_InOutpDescrParam { get; }
}

public interface ItestInOutpDescrParamObject
  : IGqlpModelImplementationBase
{
  decimal Param { get; }
}
