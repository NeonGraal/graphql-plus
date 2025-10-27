//HintName: test_output-param_Impl.gen.cs
// Generated from output-param.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_output_param;

public class testOutpParam
  : ItestOutpParam
{
  public FldOutpParam field { get; set; }
}

public class testFldOutpParam
  : ItestFldOutpParam
{
}

public class testInOutpParam
  : ItestInOutpParam
{
  public Number param { get; set; }
  public String AsString { get; set; }
}
