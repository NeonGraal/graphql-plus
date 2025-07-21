//HintName: Gqlp_output-parent-param_Impl.gen.cs
// Generated from output-parent-param.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_output_parent_param;
public class OutputOutpPrntParam
  : OutputPrntOutpPrntParam
  , IOutpPrntParam
{
  public FldOutpPrntParam field { get; set; }
}
public class OutputPrntOutpPrntParam
  : IPrntOutpPrntParam
{
  public FldOutpPrntParam field { get; set; }
}
public class DualFldOutpPrntParam
  : IFldOutpPrntParam
{
}
public class InputInOutpPrntParam
  : IInOutpPrntParam
{
  public Number param { get; set; }
  public String AsString { get; set; }
}
public class InputPrntOutpPrntParamIn
  : IPrntOutpPrntParamIn
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
