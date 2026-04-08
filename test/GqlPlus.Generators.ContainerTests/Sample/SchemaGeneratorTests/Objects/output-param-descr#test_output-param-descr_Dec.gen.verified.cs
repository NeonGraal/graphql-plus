//HintName: test_output-param-descr_Dec.gen.cs
// Generated from {CurrentDirectory}output-param-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_descr;

public interface ItestOutpParamDescr
  // No Base because it's Class
{
  ItestOutpParamDescrObject? As_OutpParamDescr { get; }
}

public interface ItestOutpParamDescrObject
  // No Base because it's Class
{
  ItestFldOutpParamDescr? Field(ItestInOutpParamDescr parameter);
}

public interface ItestFldOutpParamDescr
  // No Base because it's Class
{
  ItestFldOutpParamDescrObject? As_FldOutpParamDescr { get; }
}

public interface ItestFldOutpParamDescrObject
  // No Base because it's Class
{
}

public interface ItestInOutpParamDescr
  // No Base because it's Class
{
  string? AsString { get; }
  ItestInOutpParamDescrObject? As_InOutpParamDescr { get; }
}

public interface ItestInOutpParamDescrObject
  // No Base because it's Class
{
  decimal Param { get; }
}
