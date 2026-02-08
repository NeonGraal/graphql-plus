//HintName: test_output-parent-param_Impl.gen.cs
// Generated from output-parent-param.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_param;

public class testOutpPrntParam
  : testPrntOutpPrntParam
  , ItestOutpPrntParam
{
  public ItestFldOutpPrntParam Field { get; set; }
}

public class testPrntOutpPrntParam
  : ItestPrntOutpPrntParam
{
  public ItestFldOutpPrntParam Field { get; set; }
}

public class testFldOutpPrntParam
  : ItestFldOutpPrntParam
{
}

public class testInOutpPrntParam
  : ItestInOutpPrntParam
{
  public ItestNumber Param { get; set; }
  public ItestString AsString { get; set; }
}

public class testPrntOutpPrntParamIn
  : ItestPrntOutpPrntParamIn
{
  public ItestNumber Parent { get; set; }
  public ItestString AsString { get; set; }
}
