//HintName: test_output-parent-param_Impl.gen.cs
// Generated from output-parent-param.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_output_parent_param;

public class OutputtestOutpPrntParam
  : OutputtestPrntOutpPrntParam
  , ItestOutpPrntParam
{
  public FldOutpPrntParam field { get; set; }
}

public class OutputtestPrntOutpPrntParam
  : ItestPrntOutpPrntParam
{
  public FldOutpPrntParam field { get; set; }
}

public class DualtestFldOutpPrntParam
  : ItestFldOutpPrntParam
{
}

public class InputtestInOutpPrntParam
  : ItestInOutpPrntParam
{
  public Number param { get; set; }
  public String AsString { get; set; }
}

public class InputtestPrntOutpPrntParamIn
  : ItestPrntOutpPrntParamIn
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
