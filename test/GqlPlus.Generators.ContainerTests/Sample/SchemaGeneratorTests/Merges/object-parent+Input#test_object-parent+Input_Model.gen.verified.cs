//HintName: test_object-parent+Input_Model.gen.cs
// Generated from {CurrentDirectory}object-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_parent_Input;

public class testObjPrntInp
  : testRefObjPrntInp
  , ItestObjPrntInp
{
  public ItestObjPrntInpObject? As_ObjPrntInp { get; set; }
}

public class testObjPrntInpObject
  : testRefObjPrntInpObject
  , ItestObjPrntInpObject
{
}

public class testRefObjPrntInp
  : GqlpModelImplementationBase
  , ItestRefObjPrntInp
{
  public ItestRefObjPrntInpObject? As_RefObjPrntInp { get; set; }
}

public class testRefObjPrntInpObject
  : GqlpModelImplementationBase
  , ItestRefObjPrntInpObject
{
}
