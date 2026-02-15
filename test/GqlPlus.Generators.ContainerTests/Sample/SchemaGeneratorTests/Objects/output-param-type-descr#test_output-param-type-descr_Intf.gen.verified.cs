//HintName: test_output-param-type-descr_Intf.gen.cs
// Generated from output-param-type-descr.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_type_descr;

public interface ItestOutpParamTypeDescr
{
  ItestOutpParamTypeDescrObject AsOutpParamTypeDescr { get; }
}

public interface ItestOutpParamTypeDescrObject
{
  ItestFldOutpParamTypeDescr Field { get; }
}

public interface ItestFldOutpParamTypeDescr
{
  ItestFldOutpParamTypeDescrObject AsFldOutpParamTypeDescr { get; }
}

public interface ItestFldOutpParamTypeDescrObject
{
}

public interface ItestInOutpParamTypeDescr
{
  string AsString { get; }
  ItestInOutpParamTypeDescrObject AsInOutpParamTypeDescr { get; }
}

public interface ItestInOutpParamTypeDescrObject
{
  decimal Param { get; }
}
