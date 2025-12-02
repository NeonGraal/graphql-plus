//HintName: test_output-descr-param_Intf.gen.cs
// Generated from output-descr-param.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_output_descr_param;

public interface ItestOutpDescrParam
{
  public testOutpDescrParam OutpDescrParam { get; set; }
}

public interface ItestOutpDescrParamField
{
  public testFldOutpDescrParam field { get; set; }
}

public interface ItestFldOutpDescrParam
{
  public testFldOutpDescrParam FldOutpDescrParam { get; set; }
}

public interface ItestFldOutpDescrParamField
{
}

public interface ItestInOutpDescrParam
{
  public testString AsString { get; set; }
  public testInOutpDescrParam InOutpDescrParam { get; set; }
}

public interface ItestInOutpDescrParamField
{
  public testNumber param { get; set; }
}
