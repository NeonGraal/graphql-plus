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
  ItestOutpParamObject AsOutpParam { get; }
}

public interface ItestOutpParamObject
{
  ItestFldOutpParam Field (ItestInOutpParam parameter);
}

public interface ItestFldOutpParam
  : IGqlpModelImplementationBase
{
  ItestFldOutpParamObject AsFldOutpParam { get; }
}

public interface ItestFldOutpParamObject
{
}

public interface ItestInOutpParam
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestInOutpParamObject AsInOutpParam { get; }
}

public interface ItestInOutpParamObject
{
  decimal Param { get; }
}
