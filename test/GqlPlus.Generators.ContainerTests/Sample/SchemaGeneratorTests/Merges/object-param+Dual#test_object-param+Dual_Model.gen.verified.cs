//HintName: test_object-param+Dual_Model.gen.cs
// Generated from {CurrentDirectory}object-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Dual;

public class testObjParamDual<TTest,TType>
  : GqlpModelBase
  , ItestObjParamDual<TTest,TType>
{
  public ItestObjParamDualObject<TTest,TType>? As_ObjParamDual { get; set; }
}

public class testObjParamDualObject<TTest,TType>
  : GqlpModelBase
  , ItestObjParamDualObject<TTest,TType>
{
  public TTest Test { get; set; }
  public TType Type { get; set; }

  public testObjParamDualObject
    ( TTest test
    , TType type
    )
  {
    Test = test;
    Type = type;
  }
}
