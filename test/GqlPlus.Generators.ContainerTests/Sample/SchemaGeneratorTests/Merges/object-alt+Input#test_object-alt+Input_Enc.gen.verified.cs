//HintName: test_object-alt+Input_Enc.gen.cs
// Generated from {CurrentDirectory}object-alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_Input;

public class testObjAltInp
  : GqlpEncoderBase
  , ItestObjAltInp
{
  public ItestObjAltInpType? AsObjAltInpType { get; set; }
  public ItestObjAltInpObject? As_ObjAltInp { get; set; }
}

public class testObjAltInpObject
  : GqlpEncoderBase
  , ItestObjAltInpObject
{

  public testObjAltInpObject
    ()
  {
  }
}

public class testObjAltInpType
  : GqlpEncoderBase
  , ItestObjAltInpType
{
  public ItestObjAltInpTypeObject? As_ObjAltInpType { get; set; }
}

public class testObjAltInpTypeObject
  : GqlpEncoderBase
  , ItestObjAltInpTypeObject
{

  public testObjAltInpTypeObject
    ()
  {
  }
}
