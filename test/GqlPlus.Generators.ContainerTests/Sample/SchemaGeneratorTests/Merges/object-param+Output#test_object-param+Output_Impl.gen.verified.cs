//HintName: test_object-param+Output_Impl.gen.cs
// Generated from object-param+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Output;

public class testObjParamOutp<TTest,TType>
  : ItestObjParamOutp<TTest,TType>
{
  public TTest Test { get; set; }
  public TType Type { get; set; }
  public ItestObjParamOutpObject<TTest,TType> AsObjParamOutp { get; set; }
}
