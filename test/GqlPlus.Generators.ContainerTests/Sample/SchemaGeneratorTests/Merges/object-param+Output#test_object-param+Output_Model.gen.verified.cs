//HintName: test_object-param+Output_Model.gen.cs
// Generated from {CurrentDirectory}object-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Output;

public class testObjParamOutp<TTest,TType>
  : GqlpModelBase
  , ItestObjParamOutp<TTest,TType>
{
  public ItestObjParamOutpObject<TTest,TType>? As_ObjParamOutp { get; set; }
}

public class testObjParamOutpObject<TTest,TType>
  : GqlpModelBase
  , ItestObjParamOutpObject<TTest,TType>
{
  public TTest Test { get; set; }
  public TType Type { get; set; }

  public testObjParamOutpObject
    ( TTest ptest
    , TType ptype
    )
  {
    Test = ptest;
    Type = ptype;
  }
}
