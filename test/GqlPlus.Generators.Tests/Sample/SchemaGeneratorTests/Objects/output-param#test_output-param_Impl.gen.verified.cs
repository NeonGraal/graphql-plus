//HintName: test_output-param_Impl.gen.cs
// Generated from output-param.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param;

public class testOutpParam
  : ItestOutpParam
{
  public testFldOutpParam field { get; set; }
  public testOutpParam OutpParam { get; set; }
}

public class testFldOutpParam
  : ItestFldOutpParam
{
  public testFldOutpParam FldOutpParam { get; set; }
}

public class testInOutpParam
  : ItestInOutpParam
{
  public testNumber param { get; set; }
  public testString AsString { get; set; }
  public testInOutpParam InOutpParam { get; set; }
}
