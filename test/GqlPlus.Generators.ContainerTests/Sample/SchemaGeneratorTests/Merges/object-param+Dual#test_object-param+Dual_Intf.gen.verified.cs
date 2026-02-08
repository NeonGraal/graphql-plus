//HintName: test_object-param+Dual_Intf.gen.cs
// Generated from object-param+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Dual;

public interface ItestObjParamDual<Ttest,Ttype>
{
  public ItestObjParamDualObject AsObjParamDual { get; set; }
}

public interface ItestObjParamDualObject<Ttest,Ttype>
{
  public Ttest Test { get; set; }
  public Ttype Type { get; set; }
}
