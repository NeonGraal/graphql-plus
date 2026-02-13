//HintName: test_object-param+Input_Impl.gen.cs
// Generated from object-param+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Input;

public class testObjParamInp<TTest,TType>
  : ItestObjParamInp<TTest,TType>
{
  public TTest Test { get; set; }
  public TType Type { get; set; }
  public ItestObjParamInpObject<TTest,TType> AsObjParamInp { get; set; }
}
