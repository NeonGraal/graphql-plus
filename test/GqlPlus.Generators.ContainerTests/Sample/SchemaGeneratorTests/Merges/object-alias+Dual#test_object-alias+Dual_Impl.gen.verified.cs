//HintName: test_object-alias+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}object-alias+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alias_Dual;

public class testObjAliasDual
  : GqlpModelImplementationBase
  , ItestObjAliasDual
{
  public ItestObjAliasDualObject? As_ObjAliasDual { get; set; }
}

public class testObjAliasDualObject
  : GqlpModelImplementationBase
  , ItestObjAliasDualObject
{

  public testObjAliasDualObject
    ()
  {
  }
}
