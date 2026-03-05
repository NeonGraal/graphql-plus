//HintName: test_object-param+Input_Model.gen.cs
// Generated from {CurrentDirectory}object-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Input;

public class testObjParamInp<TTest,TType>
  : GqlpModelImplementationBase
  , ItestObjParamInp<TTest,TType>
{
  public ItestObjParamInpObject<TTest,TType>? As_ObjParamInp { get; set; }
}

public class testObjParamInpObject<TTest,TType>
  : GqlpModelImplementationBase
  , ItestObjParamInpObject<TTest,TType>
{
  public TTest Test { get; set; }
  public TType Type { get; set; }

  public testObjParamInpObject
    ( TTest test
    , TType type
    )
  {
    Test = test;
    Type = type;
  }
}
