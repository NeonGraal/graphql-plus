//HintName: test_field+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_Input;

public class testFieldInp
  : GqlpEncoderBase
  , ItestFieldInp
{
  public ItestFieldInpObject? As_FieldInp { get; set; }
}

public class testFieldInpObject
  : GqlpEncoderBase
  , ItestFieldInpObject
{
  public string Field { get; set; }

  public testFieldInpObject
    ( string field
    )
  {
    Field = field;
  }
}
