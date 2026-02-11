//HintName: test_object-param+Input_Intf.gen.cs
// Generated from object-param+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Input;

public interface ItestObjParamInp<TTest,TType>
{
  ItestObjParamInpObject AsObjParamInp { get; }
}

public interface ItestObjParamInpObject<TTest,TType>
{
  TTest Test { get; }
  TType Type { get; }
}
