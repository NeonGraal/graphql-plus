//HintName: test_output-descr-param_Intf.gen.cs
// Generated from output-descr-param.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_descr_param;

public interface ItestOutpDescrParam
{
  public ItestOutpDescrParamObject AsOutpDescrParam { get; set; }
}

public interface ItestOutpDescrParamObject
{
  public ItestFldOutpDescrParam Field { get; set; }
}

public interface ItestFldOutpDescrParam
{
  public ItestFldOutpDescrParamObject AsFldOutpDescrParam { get; set; }
}

public interface ItestFldOutpDescrParamObject
{
}

public interface ItestInOutpDescrParam
{
  public string AsString { get; set; }
  public ItestInOutpDescrParamObject AsInOutpDescrParam { get; set; }
}

public interface ItestInOutpDescrParamObject
{
  public decimal Param { get; set; }
}
