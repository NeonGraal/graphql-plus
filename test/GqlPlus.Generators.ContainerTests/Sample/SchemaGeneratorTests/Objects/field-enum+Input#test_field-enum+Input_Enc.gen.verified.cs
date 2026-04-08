//HintName: test_field-enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Input;

public class testFieldEnumInp
  : GqlpEncoderBase
  , ItestFieldEnumInp
{
  public ItestFieldEnumInpObject? As_FieldEnumInp { get; set; }
}

public class testFieldEnumInpObject
  : GqlpEncoderBase
  , ItestFieldEnumInpObject
{
  public testEnumFieldEnumInp Field { get; set; }

  public testFieldEnumInpObject
    ( testEnumFieldEnumInp field
    )
  {
    Field = field;
  }
}

public enum testEnumFieldEnumInp
{
  fieldEnumInp,
}
