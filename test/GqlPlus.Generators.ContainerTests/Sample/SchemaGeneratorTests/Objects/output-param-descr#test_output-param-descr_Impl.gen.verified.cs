//HintName: test_output-param-descr_Impl.gen.cs
// Generated from output-param-descr.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_descr;

public class testOutpParamDescr
  : ItestOutpParamDescr
{
  public ItestFldOutpParamDescr Field { get; set; }
  public ItestOutpParamDescrObject AsOutpParamDescr { get; set; }
}

public class testFldOutpParamDescr
  : ItestFldOutpParamDescr
{
  public ItestFldOutpParamDescrObject AsFldOutpParamDescr { get; set; }
}

public class testInOutpParamDescr
  : ItestInOutpParamDescr
{
  public ItestNumber Param { get; set; }
  public ItestString AsString { get; set; }
  public ItestInOutpParamDescrObject AsInOutpParamDescr { get; set; }
}
