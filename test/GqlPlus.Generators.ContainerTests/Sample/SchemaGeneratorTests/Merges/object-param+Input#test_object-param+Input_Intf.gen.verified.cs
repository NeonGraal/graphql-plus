//HintName: test_object-param+Input_Intf.gen.cs
// Generated from object-param+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Input;

public interface ItestObjParamInp<Ttest,Ttype>
{
  ItestObjParamInpObject AsObjParamInp { get; }
}

public interface ItestObjParamInpObject<Ttest,Ttype>
{
  Ttest Test { get; }
  Ttype Type { get; }
}
