//HintName: test_object-parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}object-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
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

  public testObjPrntInpObject
    ()
  {
  }
}

public class testRefObjPrntInp
  : GqlpEncoderBase
  , ItestRefObjPrntInp
{
  public ItestRefObjPrntInpObject? As_RefObjPrntInp { get; set; }
}

public class testRefObjPrntInpObject
  : GqlpEncoderBase
  , ItestRefObjPrntInpObject
{

  public testRefObjPrntInpObject
    ()
  {
  }
}
