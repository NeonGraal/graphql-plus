//HintName: test_output-param-type-descr_Intf.gen.cs
// Generated from output-param-type-descr.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_type_descr;

public interface ItestOutpParamTypeDescr
{
  public testOutpParamTypeDescr OutpParamTypeDescr { get; set; }
}

public interface ItestOutpParamTypeDescrObject
{
  public testFldOutpParamTypeDescr field { get; set; }
}

public interface ItestFldOutpParamTypeDescr
{
  public testFldOutpParamTypeDescr FldOutpParamTypeDescr { get; set; }
}

public interface ItestFldOutpParamTypeDescrObject
{
}

public interface ItestInOutpParamTypeDescr
{
  public testString AsString { get; set; }
  public testInOutpParamTypeDescr InOutpParamTypeDescr { get; set; }
}

public interface ItestInOutpParamTypeDescrObject
{
  public testNumber param { get; set; }
}
