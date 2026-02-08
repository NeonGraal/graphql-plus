//HintName: test_output-param-type-descr_Impl.gen.cs
// Generated from output-param-type-descr.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_type_descr;

public class testOutpParamTypeDescr
  : ItestOutpParamTypeDescr
{
  public ItestFldOutpParamTypeDescr Field { get; set; }
}

public class testFldOutpParamTypeDescr
  : ItestFldOutpParamTypeDescr
{
}

public class testInOutpParamTypeDescr
  : ItestInOutpParamTypeDescr
{
  public ItestNumber Param { get; set; }
  public ItestString AsString { get; set; }
}
