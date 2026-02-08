//HintName: test_output-param-type-descr_Intf.gen.cs
// Generated from output-param-type-descr.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_type_descr;

public interface ItestOutpParamTypeDescr
{
  public ItestOutpParamTypeDescrObject AsOutpParamTypeDescr { get; set; }
}

public interface ItestOutpParamTypeDescrObject
{
  public ItestFldOutpParamTypeDescr Field { get; set; }
}

public interface ItestFldOutpParamTypeDescr
{
  public ItestFldOutpParamTypeDescrObject AsFldOutpParamTypeDescr { get; set; }
}

public interface ItestFldOutpParamTypeDescrObject
{
}

public interface ItestInOutpParamTypeDescr
{
  public ItestString AsString { get; set; }
  public ItestInOutpParamTypeDescrObject AsInOutpParamTypeDescr { get; set; }
}

public interface ItestInOutpParamTypeDescrObject
{
  public ItestNumber Param { get; set; }
}
