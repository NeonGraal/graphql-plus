//HintName: test_object-parent+Output_Model.gen.cs
// Generated from {CurrentDirectory}object-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
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
}

public class testRefObjPrntOutp
  : GqlpModelImplementationBase
  , ItestRefObjPrntOutp
{
  public ItestRefObjPrntOutpObject? As_RefObjPrntOutp { get; set; }
}

public class testRefObjPrntOutpObject
  : GqlpModelImplementationBase
  , ItestRefObjPrntOutpObject
{
}
