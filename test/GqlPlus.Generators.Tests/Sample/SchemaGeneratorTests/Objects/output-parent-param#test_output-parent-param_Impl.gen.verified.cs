//HintName: test_output-parent-param_Impl.gen.cs
// Generated from output-parent-param.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_output_parent_param;

public class testOutpPrntParam
  : testPrntOutpPrntParam
  , ItestOutpPrntParam
{
  public FldOutpPrntParam field { get; set; }
}

public class testPrntOutpPrntParam
  : ItestPrntOutpPrntParam
{
  public FldOutpPrntParam field { get; set; }
}

public class testFldOutpPrntParam
  : ItestFldOutpPrntParam
{
}

public class testInOutpPrntParam
  : ItestInOutpPrntParam
{
  public Number param { get; set; }
  public String AsString { get; set; }
}

public class testPrntOutpPrntParamIn
  : ItestPrntOutpPrntParamIn
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
