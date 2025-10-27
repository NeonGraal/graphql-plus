//HintName: test_output-param-descr_Impl.gen.cs
// Generated from output-param-descr.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_output_param_descr;

public class testOutpParamDescr
  : ItestOutpParamDescr
{
  public FldOutpParamDescr field { get; set; }
}

public class testFldOutpParamDescr
  : ItestFldOutpParamDescr
{
}

public class testInOutpParamDescr
  : ItestInOutpParamDescr
{
  public Number param { get; set; }
  public String AsString { get; set; }
}
