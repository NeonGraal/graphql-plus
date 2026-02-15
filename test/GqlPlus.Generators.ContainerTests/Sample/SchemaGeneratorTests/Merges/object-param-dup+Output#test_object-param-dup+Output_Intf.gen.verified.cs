//HintName: test_object-param-dup+Output_Intf.gen.cs
// Generated from object-param-dup+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_dup_Output;

public interface ItestObjParamDupOutp<TTest>
{
  ItestObjParamDupOutpObject<TTest> AsObjParamDupOutp { get; }
}

public interface ItestObjParamDupOutpObject<TTest>
{
  TTest Test { get; }
  TTest Type { get; }
}
