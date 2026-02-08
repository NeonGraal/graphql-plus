//HintName: test_output-param_Intf.gen.cs
// Generated from output-param.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param;

public interface ItestOutpParam
{
  public ItestOutpParamObject AsOutpParam { get; set; }
}

public interface ItestOutpParamObject
{
  public ItestFldOutpParam Field { get; set; }
}

public interface ItestFldOutpParam
{
  public ItestFldOutpParamObject AsFldOutpParam { get; set; }
}

public interface ItestFldOutpParamObject
{
}

public interface ItestInOutpParam
{
  public ItestString AsString { get; set; }
  public ItestInOutpParamObject AsInOutpParam { get; set; }
}

public interface ItestInOutpParamObject
{
  public ItestNumber Param { get; set; }
}
