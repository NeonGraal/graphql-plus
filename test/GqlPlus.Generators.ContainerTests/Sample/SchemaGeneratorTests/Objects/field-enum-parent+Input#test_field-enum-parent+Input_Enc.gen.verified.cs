//HintName: test_field-enum-parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Input;

public class testFieldEnumPrntInp
  : GqlpEncoderBase
  , ItestFieldEnumPrntInp
{
  public ItestFieldEnumPrntInpObject? As_FieldEnumPrntInp { get; set; }
}

public class testFieldEnumPrntInpObject
  : GqlpEncoderBase
  , ItestFieldEnumPrntInpObject
{
  public testEnumFieldEnumPrntInp Field { get; set; }

  public testFieldEnumPrntInpObject
    ( testEnumFieldEnumPrntInp field
    )
  {
    Field = field;
  }
}

public enum testEnumFieldEnumPrntInp
{
  prnt_fieldEnumPrntInp = testPrntFieldEnumPrntInp.prnt_fieldEnumPrntInp,
  fieldEnumPrntInp,
}

public enum testPrntFieldEnumPrntInp
{
  prnt_fieldEnumPrntInp,
}
