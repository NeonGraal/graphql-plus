//HintName: test_object-param-dup+Dual_Intf.gen.cs
// Generated from object-param-dup+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_dup_Dual;

public interface ItestObjParamDupDual<Ttest>
{
  public ItestObjParamDupDualObject AsObjParamDupDual { get; set; }
}

public interface ItestObjParamDupDualObject<Ttest>
{
  public Ttest Test { get; set; }
  public Ttest Type { get; set; }
}
