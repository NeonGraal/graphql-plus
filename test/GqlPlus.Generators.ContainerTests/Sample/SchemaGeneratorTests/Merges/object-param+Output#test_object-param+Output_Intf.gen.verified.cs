//HintName: test_object-param+Output_Intf.gen.cs
// Generated from object-param+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Output;

public interface ItestObjParamOutp<TTest,TType>
{
  ItestObjParamOutpObject AsObjParamOutp { get; }
}

public interface ItestObjParamOutpObject<TTest,TType>
{
  TTest Test { get; }
  TType Type { get; }
}
