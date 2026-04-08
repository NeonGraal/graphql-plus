//HintName: test_object-param-dup+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}object-param-dup+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_dup_Dual;

public class testObjParamDupDual<TTest>
  : GqlpEncoderBase
  , ItestObjParamDupDual<TTest>
{
  public ItestObjParamDupDualObject<TTest>? As_ObjParamDupDual { get; set; }
}

public class testObjParamDupDualObject<TTest>
  : GqlpEncoderBase
  , ItestObjParamDupDualObject<TTest>
{
  public TTest Test { get; set; }
  public TTest Type { get; set; }

  public testObjParamDupDualObject
    ( TTest test
    , TTest type
    )
  {
    Test = test;
    Type = type;
  }
}
