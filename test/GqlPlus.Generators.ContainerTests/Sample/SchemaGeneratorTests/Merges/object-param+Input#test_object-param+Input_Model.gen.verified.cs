//HintName: test_object-param+Input_Model.gen.cs
// Generated from {CurrentDirectory}object-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Input;

public class testObjParamInp<TTest,TType>
  : GqlpModelBase
  , ItestObjParamInp<TTest,TType>
{
  public ItestObjParamInpObject<TTest,TType>? As_ObjParamInp { get; set; }
}

public class testObjParamInpObject<TTest,TType>
  : GqlpModelBase
  , ItestObjParamInpObject<TTest,TType>
{
  public TTest Test { get; set; }
  public TType Type { get; set; }

  public testObjParamInpObject
    ( TTest ptest
    , TType ptype
    )
  {
    Test = ptest;
    Type = ptype;
  }
}
