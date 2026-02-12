//HintName: test_object-param-dup+Dual_Impl.gen.cs
// Generated from object-param-dup+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_dup_Dual;

public class testObjParamDupDual<TTest>
  : ItestObjParamDupDual<TTest>
{
  public TTest Test { get; set; }
  public TTest Type { get; set; }
  public ItestObjParamDupDualObject<TTest> AsObjParamDupDual { get; set; }
}
