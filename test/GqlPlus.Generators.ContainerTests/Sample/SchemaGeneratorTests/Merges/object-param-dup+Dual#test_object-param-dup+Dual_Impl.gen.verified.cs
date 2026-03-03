//HintName: test_object-param-dup+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}object-param-dup+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_dup_Dual;

public class testObjParamDupDual<TTest>
  : GqlpModelImplementationBase
  , ItestObjParamDupDual<TTest>
{
  public ItestObjParamDupDualObject<TTest>? As_ObjParamDupDual { get; set; }
}

public class testObjParamDupDualObject<TTest>
  : GqlpModelImplementationBase
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
