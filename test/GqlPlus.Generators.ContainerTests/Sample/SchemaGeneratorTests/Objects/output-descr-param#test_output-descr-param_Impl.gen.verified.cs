//HintName: test_output-descr-param_Impl.gen.cs
// Generated from output-descr-param.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_descr_param;

public class testOutpDescrParam
  : ItestOutpDescrParam
{
  public ItestFldOutpDescrParam Field { get; set; }
  public ItestOutpDescrParamObject AsOutpDescrParam { get; set; }
}

public class testFldOutpDescrParam
  : ItestFldOutpDescrParam
{
  public ItestFldOutpDescrParamObject AsFldOutpDescrParam { get; set; }
}

public class testInOutpDescrParam
  : ItestInOutpDescrParam
{
  public ItestNumber Param { get; set; }
  public ItestString AsString { get; set; }
  public ItestInOutpDescrParamObject AsInOutpDescrParam { get; set; }
}
