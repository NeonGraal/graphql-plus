//HintName: Gqlp_output-descr-param_Impl.gen.cs
// Generated from output-descr-param.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_output_descr_param;
public class OutputOutpDescrParam
  : IOutpDescrParam
{
  public FldOutpDescrParam field { get; set; }
}
public class DualFldOutpDescrParam
  : IFldOutpDescrParam
{
}
public class InputInOutpDescrParam
  : IInOutpDescrParam
{
  public Number param { get; set; }
  public String AsString { get; set; }
}
