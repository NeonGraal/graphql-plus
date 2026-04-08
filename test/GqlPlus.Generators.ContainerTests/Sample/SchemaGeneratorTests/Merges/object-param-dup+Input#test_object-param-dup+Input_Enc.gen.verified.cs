//HintName: test_object-param-dup+Input_Enc.gen.cs
// Generated from {CurrentDirectory}object-param-dup+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_dup_Input;

public class testObjParamDupInp<TTest>
  : GqlpEncoderBase
  , ItestObjParamDupInp<TTest>
{
  public ItestObjParamDupInpObject<TTest>? As_ObjParamDupInp { get; set; }
}

public class testObjParamDupInpObject<TTest>
  : GqlpEncoderBase
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
