//HintName: test_object-param+Input_Enc.gen.cs
// Generated from {CurrentDirectory}object-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Input;

public class testObjParamInp<TTest,TType>
  : GqlpEncoderBase
  , ItestObjParamInp<TTest,TType>
{
  public ItestObjParamInpObject<TTest,TType>? As_ObjParamInp { get; set; }
}

public class testObjParamInpObject<TTest,TType>
  : GqlpEncoderBase
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
