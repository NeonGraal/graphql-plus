//HintName: test_object-alias+Dual_Model.gen.cs
// Generated from {CurrentDirectory}object-alias+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alias_Dual;

public class testObjAliasDual
  : GqlpModelBase
  , ItestObjAliasDual
{
  public ItestObjAliasDualObject? As_ObjAliasDual { get; set; }
}

public class testObjAliasDualObject
  : GqlpModelBase
  , ItestObjAliasDualObject
{

  public testObjAliasDualObject
    ()
  {
  }
}
