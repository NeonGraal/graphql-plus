//HintName: test_field-value+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-value+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Input;

public class testFieldValueInp
  : GqlpEncoderBase
  , ItestFieldValueInp
{
  public ItestFieldValueInpObject? As_FieldValueInp { get; set; }
}

public class testFieldValueInpObject
  : GqlpEncoderBase
  , ItestFieldValueInpObject
{
  public testEnumFieldValueInp Field { get; set; }

  public testFieldValueInpObject
    ( testEnumFieldValueInp field
    )
  {
    Field = field;
  }
}

public enum testEnumFieldValueInp
{
  fieldValueInp,
}
