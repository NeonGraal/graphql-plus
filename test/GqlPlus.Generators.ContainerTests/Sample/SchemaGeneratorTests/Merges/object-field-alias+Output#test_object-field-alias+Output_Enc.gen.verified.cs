//HintName: test_object-field-alias+Output_Enc.gen.cs
// Generated from {CurrentDirectory}object-field-alias+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Output;

public class testObjFieldAliasOutp
  : GqlpEncoderBase
  , ItestObjFieldAliasOutp
{
  public ItestObjFieldAliasOutpObject? As_ObjFieldAliasOutp { get; set; }
}

public class testObjFieldAliasOutpObject
  : GqlpEncoderBase
  , ItestObjFieldAliasOutpObject
{
  public ItestFldObjFieldAliasOutp Field { get; set; }

  public testObjFieldAliasOutpObject
    ( ItestFldObjFieldAliasOutp field
    )
  {
    Field = field;
  }
}

public class testFldObjFieldAliasOutp
  : GqlpEncoderBase
  , ItestFldObjFieldAliasOutp
{
  public ItestFldObjFieldAliasOutpObject? As_FldObjFieldAliasOutp { get; set; }
}

public class testFldObjFieldAliasOutpObject
  : GqlpEncoderBase
  , ItestFldObjFieldAliasOutpObject
{

  public testFldObjFieldAliasOutpObject
    ()
  {
  }
}
