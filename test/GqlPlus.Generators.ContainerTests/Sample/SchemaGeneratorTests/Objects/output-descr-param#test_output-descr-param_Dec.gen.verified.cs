//HintName: test_output-descr-param_Dec.gen.cs
// Generated from {CurrentDirectory}output-descr-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_descr_param;

public interface ItestOutpDescrParam
  // No Base because it's Class
{
  ItestOutpDescrParamObject? As_OutpDescrParam { get; }
}

public interface ItestOutpDescrParamObject
  // No Base because it's Class
{
  ItestFldOutpDescrParam? Field(ItestInOutpDescrParam parameter);
}

public interface ItestFldOutpDescrParam
  // No Base because it's Class
{
  ItestFldOutpDescrParamObject? As_FldOutpDescrParam { get; }
}

public interface ItestFldOutpDescrParamObject
  // No Base because it's Class
{
}

public interface ItestInOutpDescrParam
  // No Base because it's Class
{
  string? AsString { get; }
  ItestInOutpDescrParamObject? As_InOutpDescrParam { get; }
}

public interface ItestInOutpDescrParamObject
  // No Base because it's Class
{
  decimal Param { get; }
}
