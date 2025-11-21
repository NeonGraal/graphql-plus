//HintName: test_output-param_Intf.gen.cs
// Generated from output-param.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_output_param;

public interface ItestOutpParam
{
  public testOutpParam OutpParam { get; set; }
}

public interface ItestOutpParamField
{
  public testFldOutpParam field { get; set; }
}

public interface ItestFldOutpParam
{
  public testFldOutpParam FldOutpParam { get; set; }
}

public interface ItestFldOutpParamField
{
}

public interface ItestInOutpParam
{
  public testString AsString { get; set; }
  public testInOutpParam InOutpParam { get; set; }
}

public interface ItestInOutpParamField
{
  public testNumber param { get; set; }
}
