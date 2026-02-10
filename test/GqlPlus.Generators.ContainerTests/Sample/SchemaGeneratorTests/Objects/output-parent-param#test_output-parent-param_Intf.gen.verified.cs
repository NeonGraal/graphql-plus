//HintName: test_output-parent-param_Intf.gen.cs
// Generated from output-parent-param.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_param;

public interface ItestOutpPrntParam
  : ItestPrntOutpPrntParam
{
  public ItestOutpPrntParamObject AsOutpPrntParam { get; set; }
}

public interface ItestOutpPrntParamObject
  : ItestPrntOutpPrntParamObject
{
  public ItestFldOutpPrntParam Field { get; set; }
}

public interface ItestPrntOutpPrntParam
{
  public ItestPrntOutpPrntParamObject AsPrntOutpPrntParam { get; set; }
}

public interface ItestPrntOutpPrntParamObject
{
  public ItestFldOutpPrntParam Field { get; set; }
}

public interface ItestFldOutpPrntParam
{
  public ItestFldOutpPrntParamObject AsFldOutpPrntParam { get; set; }
}

public interface ItestFldOutpPrntParamObject
{
}

public interface ItestInOutpPrntParam
{
  public string AsString { get; set; }
  public ItestInOutpPrntParamObject AsInOutpPrntParam { get; set; }
}

public interface ItestInOutpPrntParamObject
{
  public decimal Param { get; set; }
}

public interface ItestPrntOutpPrntParamIn
{
  public string AsString { get; set; }
  public ItestPrntOutpPrntParamInObject AsPrntOutpPrntParamIn { get; set; }
}

public interface ItestPrntOutpPrntParamInObject
{
  public decimal Parent { get; set; }
}
