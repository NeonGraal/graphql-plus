//HintName: test_output-param_Intf.gen.cs
// Generated from output-param.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param;

public interface ItestOutpParam
{
  ItestOutpParamObject AsOutpParam { get; }
}

public interface ItestOutpParamObject
{
  ItestFldOutpParam Field { get; }
}

public interface ItestFldOutpParam
{
  ItestFldOutpParamObject AsFldOutpParam { get; }
}

public interface ItestFldOutpParamObject
{
}

public interface ItestInOutpParam
{
  string AsString { get; }
  ItestInOutpParamObject AsInOutpParam { get; }
}

public interface ItestInOutpParamObject
{
  decimal Param { get; }
}
