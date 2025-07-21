//HintName: Gqlp_output-param_Impl.gen.cs
// Generated from output-param.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_output_param;
public class OutputOutpParam
  : IOutpParam
{
  public FldOutpParam field { get; set; }
}
public class DualFldOutpParam
  : IFldOutpParam
{
}
public class InputInOutpParam
  : IInOutpParam
{
  public Number param { get; set; }
  public String AsString { get; set; }
}
