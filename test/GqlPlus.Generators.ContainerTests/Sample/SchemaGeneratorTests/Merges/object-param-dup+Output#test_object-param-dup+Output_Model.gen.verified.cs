//HintName: test_object-param-dup+Output_Model.gen.cs
// Generated from {CurrentDirectory}object-param-dup+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_dup_Output;

public class testObjParamDupOutp<TTest>
  : GqlpModelBase
  , ItestObjParamDupOutp<TTest>
{
  public ItestObjParamDupOutpObject<TTest>? As_ObjParamDupOutp { get; set; }
}

public class testObjParamDupOutpObject<TTest>
  : GqlpModelBase
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
