//HintName: test_output-param_Impl.gen.cs
// Generated from output-param.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param;

public class testOutpParam
  : ItestOutpParam
{
  public ItestFldOutpParam Field { get; set; }
  public ItestOutpParamObject AsOutpParam { get; set; }
}

public class testFldOutpParam
  : ItestFldOutpParam
{
  public ItestFldOutpParamObject AsFldOutpParam { get; set; }
}

public class testInOutpParam
  : ItestInOutpParam
{
  public ItestNumber Param { get; set; }
  public ItestString AsString { get; set; }
  public ItestInOutpParamObject AsInOutpParam { get; set; }
}
