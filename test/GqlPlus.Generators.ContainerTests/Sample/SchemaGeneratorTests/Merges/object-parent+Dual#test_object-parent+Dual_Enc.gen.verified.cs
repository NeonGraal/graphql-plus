//HintName: test_object-parent+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}object-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_parent_Dual;

public class testObjPrntDual
  : testRefObjPrntDual
  , ItestObjPrntDual
{
  public ItestObjPrntDualObject? As_ObjPrntDual { get; set; }
}

public class testObjPrntDualObject
  : testRefObjPrntDualObject
  , ItestObjPrntDualObject
{

  public testObjPrntDualObject
    ()
  {
  }
}

public class testRefObjPrntDual
  : GqlpEncoderBase
  , ItestRefObjPrntDual
{
  public ItestRefObjPrntDualObject? As_RefObjPrntDual { get; set; }
}

public class testRefObjPrntDualObject
  : GqlpEncoderBase
  , ItestRefObjPrntDualObject
{

  public testRefObjPrntDualObject
    ()
  {
  }
}
