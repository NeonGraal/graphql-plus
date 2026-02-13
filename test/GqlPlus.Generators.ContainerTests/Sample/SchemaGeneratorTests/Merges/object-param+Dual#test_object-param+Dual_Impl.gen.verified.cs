//HintName: test_object-param+Dual_Impl.gen.cs
// Generated from object-param+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Dual;

public class testObjParamDual<TTest,TType>
  : ItestObjParamDual<TTest,TType>
{
  public TTest Test { get; set; }
  public TType Type { get; set; }
  public ItestObjParamDualObject<TTest,TType> AsObjParamDual { get; set; }
}
