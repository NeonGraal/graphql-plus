//HintName: test_output-param-type-descr_Dec.gen.cs
// Generated from {CurrentDirectory}output-param-type-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_type_descr;

public interface ItestOutpParamTypeDescr
  // No Base because it's Class
{
  ItestOutpParamTypeDescrObject? As_OutpParamTypeDescr { get; }
}

public interface ItestOutpParamTypeDescrObject
  // No Base because it's Class
{
  ItestFldOutpParamTypeDescr? Field(ItestInOutpParamTypeDescr parameter);
}

public interface ItestFldOutpParamTypeDescr
  // No Base because it's Class
{
  ItestFldOutpParamTypeDescrObject? As_FldOutpParamTypeDescr { get; }
}

public interface ItestFldOutpParamTypeDescrObject
  // No Base because it's Class
{
}

public interface ItestInOutpParamTypeDescr
  // No Base because it's Class
{
  string? AsString { get; }
  ItestInOutpParamTypeDescrObject? As_InOutpParamTypeDescr { get; }
}

public interface ItestInOutpParamTypeDescrObject
  // No Base because it's Class
{
  decimal Param { get; }
}
