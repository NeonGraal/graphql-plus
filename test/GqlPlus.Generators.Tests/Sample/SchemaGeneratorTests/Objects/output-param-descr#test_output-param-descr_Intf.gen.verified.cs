//HintName: test_output-param-descr_Intf.gen.cs
// Generated from output-param-descr.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_descr;

public interface ItestOutpParamDescr
{
  public testOutpParamDescr OutpParamDescr { get; set; }
}

public interface ItestOutpParamDescrField
{
  public testFldOutpParamDescr field { get; set; }
}

public interface ItestFldOutpParamDescr
{
  public testFldOutpParamDescr FldOutpParamDescr { get; set; }
}

public interface ItestFldOutpParamDescrField
{
}

public interface ItestInOutpParamDescr
{
  public testString AsString { get; set; }
  public testInOutpParamDescr InOutpParamDescr { get; set; }
}

public interface ItestInOutpParamDescrField
{
  public testNumber param { get; set; }
}
