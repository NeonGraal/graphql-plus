//HintName: test_output-parent-param_Dec.gen.cs
// Generated from {CurrentDirectory}output-parent-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_param;

public interface ItestOutpPrntParam
  : ItestPrntOutpPrntParam
{
  ItestOutpPrntParamObject? As_OutpPrntParam { get; }
}

public interface ItestOutpPrntParamObject
  : ItestPrntOutpPrntParamObject
{
  ItestFldOutpPrntParam? Field(ItestInOutpPrntParam parameter);
}

public interface ItestPrntOutpPrntParam
  // No Base because it's Class
{
  ItestPrntOutpPrntParamObject? As_PrntOutpPrntParam { get; }
}

public interface ItestPrntOutpPrntParamObject
  // No Base because it's Class
{
  ItestFldOutpPrntParam? Field(ItestPrntOutpPrntParamIn parameter);
}

public interface ItestFldOutpPrntParam
  // No Base because it's Class
{
  ItestFldOutpPrntParamObject? As_FldOutpPrntParam { get; }
}

public interface ItestFldOutpPrntParamObject
  // No Base because it's Class
{
}

public interface ItestInOutpPrntParam
  // No Base because it's Class
{
  string? AsString { get; }
  ItestInOutpPrntParamObject? As_InOutpPrntParam { get; }
}

public interface ItestInOutpPrntParamObject
  // No Base because it's Class
{
  decimal Param { get; }
}

public interface ItestPrntOutpPrntParamIn
  // No Base because it's Class
{
  string? AsString { get; }
  ItestPrntOutpPrntParamInObject? As_PrntOutpPrntParamIn { get; }
}

public interface ItestPrntOutpPrntParamInObject
  // No Base because it's Class
{
  decimal Parent { get; }
}
