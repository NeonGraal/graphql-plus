//HintName: test_output-parent-param_Intf.gen.cs
// Generated from output-parent-param.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_param;

public interface ItestOutpPrntParam
  : ItestPrntOutpPrntParam
{
}

public interface ItestOutpPrntParamObject
  : ItestPrntOutpPrntParamObject
{
  public ItestFldOutpPrntParam Field { get; set; }
}

public interface ItestPrntOutpPrntParam
{
}

public interface ItestPrntOutpPrntParamObject
{
  public ItestFldOutpPrntParam Field { get; set; }
}

public interface ItestFldOutpPrntParam
{
}

public interface ItestFldOutpPrntParamObject
{
}

public interface ItestInOutpPrntParam
{
  public ItestString AsString { get; set; }
}

public interface ItestInOutpPrntParamObject
{
  public ItestNumber Param { get; set; }
}

public interface ItestPrntOutpPrntParamIn
{
  public ItestString AsString { get; set; }
}

public interface ItestPrntOutpPrntParamInObject
{
  public ItestNumber Parent { get; set; }
}
