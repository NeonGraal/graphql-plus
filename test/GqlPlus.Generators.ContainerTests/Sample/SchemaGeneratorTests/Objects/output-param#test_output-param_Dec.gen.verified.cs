//HintName: test_output-param_Dec.gen.cs
// Generated from {CurrentDirectory}output-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param;

public interface ItestOutpParam
  // No Base because it's Class
{
  ItestOutpParamObject? As_OutpParam { get; }
}

public interface ItestOutpParamObject
  // No Base because it's Class
{
  ItestFldOutpParam? Field(ItestInOutpParam parameter);
}

public interface ItestFldOutpParam
  // No Base because it's Class
{
  ItestFldOutpParamObject? As_FldOutpParam { get; }
}

public interface ItestFldOutpParamObject
  // No Base because it's Class
{
}

public interface ItestInOutpParam
  // No Base because it's Class
{
  string? AsString { get; }
  ItestInOutpParamObject? As_InOutpParam { get; }
}

public interface ItestInOutpParamObject
  // No Base because it's Class
{
  decimal Param { get; }
}
