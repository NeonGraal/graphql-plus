//HintName: test_object-param-dup+Dual_Intf.gen.cs
// Generated from object-param-dup+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_dup_Dual;

public interface ItestObjParamDupDual<TTest>
{
  ItestObjParamDupDualObject<TTest> AsObjParamDupDual { get; }
}

public interface ItestObjParamDupDualObject<TTest>
{
  TTest Test { get; }
  TTest Type { get; }
}
