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
  ItestOutpDescrParamObject AsOutpDescrParam { get; }
}

public interface ItestOutpDescrParamObject
{
  ItestFldOutpDescrParam Field (ItestInOutpDescrParam parameter);
}

public interface ItestFldOutpDescrParam
  : IGqlpModelImplementationBase
{
  ItestFldOutpDescrParamObject AsFldOutpDescrParam { get; }
}

public interface ItestFldOutpDescrParamObject
{
}

public interface ItestInOutpDescrParam
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestInOutpDescrParamObject AsInOutpDescrParam { get; }
}

public interface ItestInOutpDescrParamObject
{
  decimal Param { get; }
}
