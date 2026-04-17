//HintName: test_object-param-dup+Input_Model.gen.cs
// Generated from {CurrentDirectory}object-param-dup+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_dup_Input;

public class testObjParamDupInp<TTest>
  : GqlpModelBase
  , ItestObjParamDupInp<TTest>
{
  public ItestObjParamDupInpObject<TTest>? As_ObjParamDupInp { get; set; }
}

public class testObjParamDupInpObject<TTest>
  : GqlpModelBase
  , ItestObjParamDupInpObject<TTest>
{
  public TTest Test { get; set; }
  public TTest Type { get; set; }

  public testObjParamDupInpObject
    ( TTest test
    , TTest type
    )
  {
    Test = test;
    Type = type;
  }
}
