//HintName: test_output-parent-param_Impl.gen.cs
// Generated from output-parent-param.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_param;

public class testOutpPrntParam
  : testPrntOutpPrntParam
  , ItestOutpPrntParam
{
  public testFldOutpPrntParam field { get; set; }
  public testOutpPrntParam OutpPrntParam { get; set; }
}

public class testPrntOutpPrntParam
  : ItestPrntOutpPrntParam
{
  public testFldOutpPrntParam field { get; set; }
  public testPrntOutpPrntParam PrntOutpPrntParam { get; set; }
}

public class testFldOutpPrntParam
  : ItestFldOutpPrntParam
{
  public testFldOutpPrntParam FldOutpPrntParam { get; set; }
}

public class testInOutpPrntParam
  : ItestInOutpPrntParam
{
  public testNumber param { get; set; }
  public testString AsString { get; set; }
  public testInOutpPrntParam InOutpPrntParam { get; set; }
}

public class testPrntOutpPrntParamIn
  : ItestPrntOutpPrntParamIn
{
  public testNumber parent { get; set; }
  public testString AsString { get; set; }
  public testPrntOutpPrntParamIn PrntOutpPrntParamIn { get; set; }
}
