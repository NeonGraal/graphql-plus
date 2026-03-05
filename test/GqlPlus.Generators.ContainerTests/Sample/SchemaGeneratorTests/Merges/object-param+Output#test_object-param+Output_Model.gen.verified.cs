//HintName: test_object-param+Output_Model.gen.cs
// Generated from {CurrentDirectory}object-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Output;

public class testObjParamOutp<TTest,TType>
  : GqlpModelImplementationBase
  , ItestObjParamOutp<TTest,TType>
{
  public ItestObjParamOutpObject<TTest,TType>? As_ObjParamOutp { get; set; }
}

public class testObjParamOutpObject<TTest,TType>
  : GqlpModelImplementationBase
  , ItestObjParamOutpObject<TTest,TType>
{
  public TTest Test { get; set; }
  public TType Type { get; set; }

  public testObjParamOutpObject
    ( TTest test
    , TType type
    )
  {
    Test = test;
    Type = type;
  }
}
