//HintName: test_object-param+Dual_Intf.gen.cs
// Generated from object-param+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Dual;

public interface ItestObjParamDual<Ttest,Ttype>
{
  ItestObjParamDualObject AsObjParamDual { get; }
}

public interface ItestObjParamDualObject<Ttest,Ttype>
{
  Ttest Test { get; }
  Ttype Type { get; }
}
