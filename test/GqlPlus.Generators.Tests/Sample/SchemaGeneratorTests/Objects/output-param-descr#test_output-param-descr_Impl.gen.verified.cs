//HintName: test_output-param-descr_Impl.gen.cs
// Generated from output-param-descr.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_output_param_descr;

public class testOutpParamDescr
  : ItestOutpParamDescr
{
  public testFldOutpParamDescr field { get; set; }
  public testOutpParamDescr OutpParamDescr { get; set; }
}

public class testFldOutpParamDescr
  : ItestFldOutpParamDescr
{
  public testFldOutpParamDescr FldOutpParamDescr { get; set; }
}

public class testInOutpParamDescr
  : ItestInOutpParamDescr
{
  public testNumber param { get; set; }
  public testString AsString { get; set; }
  public testInOutpParamDescr InOutpParamDescr { get; set; }
}
