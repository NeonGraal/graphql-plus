//HintName: test_object-field+Output_Enc.gen.cs
// Generated from {CurrentDirectory}object-field+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Output;

public class testObjFieldOutp
  : GqlpEncoderBase
  , ItestObjFieldOutp
{
  public ItestObjFieldOutpObject? As_ObjFieldOutp { get; set; }
}

public class testObjFieldOutpObject
  : GqlpEncoderBase
  , ItestObjFieldOutpObject
{
  public ItestFldObjFieldOutp Field { get; set; }

  public testObjFieldOutpObject
    ( ItestFldObjFieldOutp field
    )
  {
    Field = field;
  }
}

public class testFldObjFieldOutp
  : GqlpEncoderBase
  , ItestFldObjFieldOutp
{
  public ItestFldObjFieldOutpObject? As_FldObjFieldOutp { get; set; }
}

public class testFldObjFieldOutpObject
  : GqlpEncoderBase
  , ItestFldObjFieldOutpObject
{

  public testFldObjFieldOutpObject
    ()
  {
  }
}
