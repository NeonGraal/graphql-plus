//HintName: test_output-param_Intf.gen.cs
// Generated from {CurrentDirectory}output-param.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param;

public interface ItestOutpParam
  : IGqlpModelImplementationBase
{
  ItestOutpParamObject? As_OutpParam { get; }
}

public interface ItestOutpParamObject
  : IGqlpModelImplementationBase
{
  ItestFldOutpParam? Field(ItestInOutpParam parameter);
}

public interface ItestFldOutpParam
  : IGqlpModelImplementationBase
{
  ItestFldOutpParamObject? As_FldOutpParam { get; }
}

public interface ItestFldOutpParamObject
  : IGqlpModelImplementationBase
{
}

public interface ItestInOutpParam
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestInOutpParamObject? As_InOutpParam { get; }
}

public interface ItestInOutpParamObject
  : IGqlpModelImplementationBase
{
  decimal Param { get; }
}
