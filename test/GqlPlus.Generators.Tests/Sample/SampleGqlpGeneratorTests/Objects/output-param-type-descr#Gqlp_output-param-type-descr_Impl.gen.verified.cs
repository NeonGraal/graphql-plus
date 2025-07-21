//HintName: Gqlp_output-param-type-descr_Impl.gen.cs
// Generated from output-param-type-descr.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_output_param_type_descr;
public class OutputOutpParamTypeDescr
  : IOutpParamTypeDescr
{
  public FldOutpParamTypeDescr field { get; set; }
}
public class DualFldOutpParamTypeDescr
  : IFldOutpParamTypeDescr
{
}
public class InputInOutpParamTypeDescr
  : IInOutpParamTypeDescr
{
  public Number param { get; set; }
  public String AsString { get; set; }
}
