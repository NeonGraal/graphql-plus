//HintName: test_output-descr-param_Intf.gen.cs
// Generated from output-descr-param.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_descr_param;

public interface ItestOutpDescrParam
{
  ItestOutpDescrParamObject AsOutpDescrParam { get; }
}

public interface ItestOutpDescrParamObject
{
  ItestFldOutpDescrParam Field { get; }
}

public interface ItestFldOutpDescrParam
{
  ItestFldOutpDescrParamObject AsFldOutpDescrParam { get; }
}

public interface ItestFldOutpDescrParamObject
{
}

public interface ItestInOutpDescrParam
{
  string AsString { get; }
  ItestInOutpDescrParamObject AsInOutpDescrParam { get; }
}

public interface ItestInOutpDescrParamObject
{
  decimal Param { get; }
}
