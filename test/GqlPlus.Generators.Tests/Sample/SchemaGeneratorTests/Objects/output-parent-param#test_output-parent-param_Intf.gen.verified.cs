//HintName: test_output-parent-param_Intf.gen.cs
// Generated from output-parent-param.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_output_parent_param;

public interface ItestOutpPrntParam
  : ItestPrntOutpPrntParam
{
  FldOutpPrntParam field { get; }
}

public interface ItestPrntOutpPrntParam
{
  FldOutpPrntParam field { get; }
}

public interface ItestFldOutpPrntParam
{
}

public interface ItestInOutpPrntParam
{
  Number param { get; }
  String AsString { get; }
}

public interface ItestPrntOutpPrntParamIn
{
  Number parent { get; }
  String AsString { get; }
}
