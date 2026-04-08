//HintName: test_object-field-alias+Input_Enc.gen.cs
// Generated from {CurrentDirectory}object-field-alias+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Input;

public class testObjFieldAliasInp
  : GqlpEncoderBase
  , ItestObjFieldAliasInp
{
  public ItestObjFieldAliasInpObject? As_ObjFieldAliasInp { get; set; }
}

public class testObjFieldAliasInpObject
  : GqlpEncoderBase
  , ItestObjFieldAliasInpObject
{
  public ItestFldObjFieldAliasInp Field { get; set; }

  public testObjFieldAliasInpObject
    ( ItestFldObjFieldAliasInp field
    )
  {
    Field = field;
  }
}

public class testFldObjFieldAliasInp
  : GqlpEncoderBase
  , ItestFldObjFieldAliasInp
{
  public ItestFldObjFieldAliasInpObject? As_FldObjFieldAliasInp { get; set; }
}

public class testFldObjFieldAliasInpObject
  : GqlpEncoderBase
  , ItestFldObjFieldAliasInpObject
{

  public testFldObjFieldAliasInpObject
    ()
  {
  }
}
