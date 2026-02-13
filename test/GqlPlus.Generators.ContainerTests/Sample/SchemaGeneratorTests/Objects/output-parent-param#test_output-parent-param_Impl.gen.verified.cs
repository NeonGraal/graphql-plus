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
  public ItestOutpPrntParamObject AsOutpPrntParam { get; set; }
}

public class testPrntOutpPrntParam
  : ItestPrntOutpPrntParam
{
  public ItestFldOutpPrntParam Field { get; set; }
  public ItestPrntOutpPrntParamObject AsPrntOutpPrntParam { get; set; }
}

public class testFldOutpPrntParam
  : ItestFldOutpPrntParam
{
  public ItestFldOutpPrntParamObject AsFldOutpPrntParam { get; set; }
}

public class testInOutpPrntParam
  : ItestInOutpPrntParam
{
  public decimal Param { get; set; }
  public string AsString { get; set; }
  public ItestInOutpPrntParamObject AsInOutpPrntParam { get; set; }
}

public class testPrntOutpPrntParamIn
  : ItestPrntOutpPrntParamIn
{
  public decimal Parent { get; set; }
  public string AsString { get; set; }
  public ItestPrntOutpPrntParamInObject AsPrntOutpPrntParamIn { get; set; }
}
