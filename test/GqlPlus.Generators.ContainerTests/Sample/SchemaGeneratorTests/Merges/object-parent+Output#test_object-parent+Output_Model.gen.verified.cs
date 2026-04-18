//HintName: test_object-parent+Output_Model.gen.cs
// Generated from {CurrentDirectory}object-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_parent_Output;

public class testObjPrntOutp
  : testRefObjPrntOutp
  , ItestObjPrntOutp
{
  public ItestObjPrntOutpObject? As_ObjPrntOutp { get; set; }
}

public class testObjPrntOutpObject
  : testRefObjPrntOutpObject
  , ItestObjPrntOutpObject
{

  public testObjPrntOutpObject
    ()
  {
  }
}

public class testRefObjPrntOutp
  : GqlpModelBase
  , ItestRefObjPrntOutp
{
  public ItestRefObjPrntOutpObject? As_RefObjPrntOutp { get; set; }
}

public class testRefObjPrntOutpObject
  : GqlpModelBase
  , ItestRefObjPrntOutpObject
{

  public testRefObjPrntOutpObject
    ()
  {
  }
}
