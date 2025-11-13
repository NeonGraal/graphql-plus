//HintName: test_output-param-type-descr_Impl.gen.cs
// Generated from output-param-type-descr.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_output_param_type_descr;

public class testOutpParamTypeDescr
  : ItestOutpParamTypeDescr
{
  public testFldOutpParamTypeDescr field { get; set; }
  public testOutpParamTypeDescr OutpParamTypeDescr { get; set; }
}

public class testFldOutpParamTypeDescr
  : ItestFldOutpParamTypeDescr
{
  public testFldOutpParamTypeDescr FldOutpParamTypeDescr { get; set; }
}

public class testInOutpParamTypeDescr
  : ItestInOutpParamTypeDescr
{
  public testNumber param { get; set; }
  public testString AsString { get; set; }
  public testInOutpParamTypeDescr InOutpParamTypeDescr { get; set; }
}
