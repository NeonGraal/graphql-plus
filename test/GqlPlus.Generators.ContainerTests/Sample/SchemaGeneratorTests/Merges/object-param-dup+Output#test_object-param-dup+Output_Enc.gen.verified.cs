//HintName: test_object-param-dup+Output_Enc.gen.cs
// Generated from {CurrentDirectory}object-param-dup+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_dup_Output;

public class testObjParamDupOutp<TTest>
  : GqlpEncoderBase
  , ItestObjParamDupOutp<TTest>
{
  public ItestObjParamDupOutpObject<TTest>? As_ObjParamDupOutp { get; set; }
}

public class testObjParamDupOutpObject<TTest>
  : GqlpEncoderBase
  , ItestObjParamDupOutpObject<TTest>
{
  public TTest Test { get; set; }
  public TTest Type { get; set; }

  public testObjParamDupOutpObject
    ( TTest test
    , TTest type
    )
  {
    Test = test;
    Type = type;
  }
}
