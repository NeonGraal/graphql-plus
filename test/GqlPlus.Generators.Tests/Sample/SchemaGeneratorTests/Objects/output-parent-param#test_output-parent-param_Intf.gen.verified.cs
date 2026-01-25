//HintName: test_output-parent-param_Intf.gen.cs
// Generated from output-parent-param.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_param;

public interface ItestOutpPrntParam
  : ItestPrntOutpPrntParam
{
  public testOutpPrntParam OutpPrntParam { get; set; }
}

public interface ItestOutpPrntParamObject
  : ItestPrntOutpPrntParamObject
{
  public testFldOutpPrntParam field { get; set; }
}

public interface ItestPrntOutpPrntParam
{
  public testPrntOutpPrntParam PrntOutpPrntParam { get; set; }
}

public interface ItestPrntOutpPrntParamObject
{
  public testFldOutpPrntParam field { get; set; }
}

public interface ItestFldOutpPrntParam
{
  public testFldOutpPrntParam FldOutpPrntParam { get; set; }
}

public interface ItestFldOutpPrntParamObject
{
}

public interface ItestInOutpPrntParam
{
  public testString AsString { get; set; }
  public testInOutpPrntParam InOutpPrntParam { get; set; }
}

public interface ItestInOutpPrntParamObject
{
  public testNumber param { get; set; }
}

public interface ItestPrntOutpPrntParamIn
{
  public testString AsString { get; set; }
  public testPrntOutpPrntParamIn PrntOutpPrntParamIn { get; set; }
}

public interface ItestPrntOutpPrntParamInObject
{
  public testNumber parent { get; set; }
}
