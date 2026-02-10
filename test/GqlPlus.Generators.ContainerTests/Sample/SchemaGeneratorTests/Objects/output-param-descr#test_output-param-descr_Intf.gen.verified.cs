//HintName: test_output-param-descr_Intf.gen.cs
// Generated from output-param-descr.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_descr;

public interface ItestOutpParamDescr
{
  public ItestOutpParamDescrObject AsOutpParamDescr { get; set; }
}

public interface ItestOutpParamDescrObject
{
  public ItestFldOutpParamDescr Field { get; set; }
}

public interface ItestFldOutpParamDescr
{
  public ItestFldOutpParamDescrObject AsFldOutpParamDescr { get; set; }
}

public interface ItestFldOutpParamDescrObject
{
}

public interface ItestInOutpParamDescr
{
  public string AsString { get; set; }
  public ItestInOutpParamDescrObject AsInOutpParamDescr { get; set; }
}

public interface ItestInOutpParamDescrObject
{
  public decimal Param { get; set; }
}
