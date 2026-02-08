//HintName: test_object-param-dup+Input_Intf.gen.cs
// Generated from object-param-dup+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_dup_Input;

public interface ItestObjParamDupInp<Ttest>
{
  public ItestObjParamDupInpObject AsObjParamDupInp { get; set; }
}

public interface ItestObjParamDupInpObject<Ttest>
{
  public Ttest Test { get; set; }
  public Ttest Type { get; set; }
}
