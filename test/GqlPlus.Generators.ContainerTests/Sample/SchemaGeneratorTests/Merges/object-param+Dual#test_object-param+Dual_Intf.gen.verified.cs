//HintName: test_object-param+Dual_Intf.gen.cs
// Generated from object-param+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Dual;

public interface ItestObjParamDual<TTest,TType>
{
  ItestObjParamDualObject<TTest,TType> AsObjParamDual { get; }
}

public interface ItestObjParamDualObject<TTest,TType>
{
  TTest Test { get; }
  TType Type { get; }
}
