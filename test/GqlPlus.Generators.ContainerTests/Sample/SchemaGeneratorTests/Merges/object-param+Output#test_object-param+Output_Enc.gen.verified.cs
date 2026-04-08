//HintName: test_object-param+Output_Enc.gen.cs
// Generated from {CurrentDirectory}object-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Output;

public class testObjParamOutp<TTest,TType>
  : GqlpEncoderBase
  , ItestObjParamOutp<TTest,TType>
{
  public ItestObjParamOutpObject<TTest,TType>? As_ObjParamOutp { get; set; }
}

public class testObjParamOutpObject<TTest,TType>
  : GqlpEncoderBase
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
