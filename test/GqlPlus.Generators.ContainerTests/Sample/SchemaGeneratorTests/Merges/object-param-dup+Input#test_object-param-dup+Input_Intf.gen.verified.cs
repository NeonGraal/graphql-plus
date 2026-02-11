//HintName: test_object-param-dup+Input_Intf.gen.cs
// Generated from object-param-dup+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_dup_Input;

public interface ItestObjParamDupInp<Ttest>
{
  ItestObjParamDupInpObject AsObjParamDupInp { get; }
}

public interface ItestObjParamDupInpObject<Ttest>
{
  Ttest Test { get; }
  Ttest Type { get; }
}
