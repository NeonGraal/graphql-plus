//HintName: test_object-field+Input_Enc.gen.cs
// Generated from {CurrentDirectory}object-field+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Input;

public class testObjFieldInp
  : GqlpEncoderBase
  , ItestObjFieldInp
{
  public ItestObjFieldInpObject? As_ObjFieldInp { get; set; }
}

public class testObjFieldInpObject
  : GqlpEncoderBase
  , ItestObjFieldInpObject
{
  public ItestFldObjFieldInp Field { get; set; }

  public testObjFieldInpObject
    ( ItestFldObjFieldInp field
    )
  {
    Field = field;
  }
}

public class testFldObjFieldInp
  : GqlpEncoderBase
  , ItestFldObjFieldInp
{
  public ItestFldObjFieldInpObject? As_FldObjFieldInp { get; set; }
}

public class testFldObjFieldInpObject
  : GqlpEncoderBase
  , ItestFldObjFieldInpObject
{

  public testFldObjFieldInpObject
    ()
  {
  }
}
