//HintName: test_output-param-descr_Intf.gen.cs
// Generated from output-param-descr.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_descr;

public interface ItestOutpParamDescr
{
  ItestOutpParamDescrObject AsOutpParamDescr { get; }
}

public interface ItestOutpParamDescrObject
{
  ItestFldOutpParamDescr Field { get; }
}

public interface ItestFldOutpParamDescr
{
  ItestFldOutpParamDescrObject AsFldOutpParamDescr { get; }
}

public interface ItestFldOutpParamDescrObject
{
}

public interface ItestInOutpParamDescr
{
  string AsString { get; }
  ItestInOutpParamDescrObject AsInOutpParamDescr { get; }
}

public interface ItestInOutpParamDescrObject
{
  decimal Param { get; }
}
