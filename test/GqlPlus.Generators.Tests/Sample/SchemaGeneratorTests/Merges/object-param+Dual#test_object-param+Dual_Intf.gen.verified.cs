//HintName: test_object-param+Dual_Intf.gen.cs
// Generated from object-param+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Dual;

public interface ItestObjParamDual<Ttest,Ttype>
{
  public testObjParamDual ObjParamDual { get; set; }
}

public interface ItestObjParamDualObject<Ttest,Ttype>
{
  public Ttest test { get; set; }
  public Ttype type { get; set; }
}
