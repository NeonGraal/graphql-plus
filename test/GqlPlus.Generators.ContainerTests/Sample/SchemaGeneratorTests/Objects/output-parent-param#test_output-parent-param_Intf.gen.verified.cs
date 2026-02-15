//HintName: test_output-parent-param_Intf.gen.cs
// Generated from output-parent-param.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_param;

public interface ItestOutpPrntParam
  : ItestPrntOutpPrntParam
{
  ItestOutpPrntParamObject AsOutpPrntParam { get; }
}

public interface ItestOutpPrntParamObject
  : ItestPrntOutpPrntParamObject
{
  ItestFldOutpPrntParam Field { get; }
}

public interface ItestPrntOutpPrntParam
{
  ItestPrntOutpPrntParamObject AsPrntOutpPrntParam { get; }
}

public interface ItestPrntOutpPrntParamObject
{
  ItestFldOutpPrntParam Field { get; }
}

public interface ItestFldOutpPrntParam
{
  ItestFldOutpPrntParamObject AsFldOutpPrntParam { get; }
}

public interface ItestFldOutpPrntParamObject
{
}

public interface ItestInOutpPrntParam
{
  string AsString { get; }
  ItestInOutpPrntParamObject AsInOutpPrntParam { get; }
}

public interface ItestInOutpPrntParamObject
{
  decimal Param { get; }
}

public interface ItestPrntOutpPrntParamIn
{
  string AsString { get; }
  ItestPrntOutpPrntParamInObject AsPrntOutpPrntParamIn { get; }
}

public interface ItestPrntOutpPrntParamInObject
{
  decimal Parent { get; }
}
