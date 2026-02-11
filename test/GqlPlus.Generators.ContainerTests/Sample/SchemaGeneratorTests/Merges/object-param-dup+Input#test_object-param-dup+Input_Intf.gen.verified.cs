//HintName: test_object-param-dup+Input_Intf.gen.cs
// Generated from object-param-dup+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_dup_Input;

public interface ItestObjParamDupInp<TTest>
{
  ItestObjParamDupInpObject AsObjParamDupInp { get; }
}

public interface ItestObjParamDupInpObject<TTest>
{
  TTest Test { get; }
  TTest Type { get; }
}
