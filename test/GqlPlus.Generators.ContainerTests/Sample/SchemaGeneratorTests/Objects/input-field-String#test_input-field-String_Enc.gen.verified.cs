//HintName: test_input-field-String_Enc.gen.cs
// Generated from {CurrentDirectory}input-field-String.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_String;

public class testInpFieldStr
  : GqlpEncoderBase
  , ItestInpFieldStr
{
  public ItestInpFieldStrObject? As_InpFieldStr { get; set; }
}

public class testInpFieldStrObject
  : GqlpEncoderBase
  , ItestInpFieldStrObject
{
  public string Field { get; set; }

  public testInpFieldStrObject
    ( string field
    )
  {
    Field = field;
  }
}
