//HintName: test_object-param-dup+Output_Impl.gen.cs
// Generated from {CurrentDirectory}object-param-dup+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_dup_Output;

public class testObjParamDupOutp<TTest>
  : GqlpModelImplementationBase
  , ItestObjParamDupOutp<TTest>
{
  public ItestObjParamDupOutpObject<TTest>? As_ObjParamDupOutp { get; set; }
}

public class testObjParamDupOutpObject<TTest>
  : GqlpModelImplementationBase
  , ItestObjParamDupOutpObject<TTest>
{
  public TTest Test { get; set; }
  public TTest Type { get; set; }

  public testObjParamDupOutpObject(TTest test, TTest type)
  {
    Test = test;
    Type = type;
  }
}
