//HintName: Gqlp_output-param-descr_Impl.gen.cs
// Generated from output-param-descr.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_output_param_descr;
public class OutputOutpParamDescr
  : IOutpParamDescr
{
  public FldOutpParamDescr field { get; set; }
}
public class DualFldOutpParamDescr
  : IFldOutpParamDescr
{
}
public class InputInOutpParamDescr
  : IInOutpParamDescr
{
  public Number param { get; set; }
  public String AsString { get; set; }
}
