//HintName: test_object-param+Input_Intf.gen.cs
// Generated from object-param+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Input;

public interface ItestObjParamInp<Ttest,Ttype>
{
  public testObjParamInp ObjParamInp { get; set; }
}

public interface ItestObjParamInpObject<Ttest,Ttype>
{
  public Ttest test { get; set; }
  public Ttype type { get; set; }
}
