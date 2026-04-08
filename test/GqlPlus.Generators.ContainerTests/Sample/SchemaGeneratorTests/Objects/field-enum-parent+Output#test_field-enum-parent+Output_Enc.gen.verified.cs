//HintName: test_field-enum-parent+Output_Enc.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Output;

public class testFieldEnumPrntOutp
  : GqlpEncoderBase
  , ItestFieldEnumPrntOutp
{
  public ItestFieldEnumPrntOutpObject? As_FieldEnumPrntOutp { get; set; }
}

public class testFieldEnumPrntOutpObject
  : GqlpEncoderBase
  , ItestFieldEnumPrntOutpObject
{
  public testEnumFieldEnumPrntOutp Field { get; set; }

  public testFieldEnumPrntOutpObject
    ( testEnumFieldEnumPrntOutp field
    )
  {
    Field = field;
  }
}

public enum testEnumFieldEnumPrntOutp
{
  prnt_fieldEnumPrntOutp = testPrntFieldEnumPrntOutp.prnt_fieldEnumPrntOutp,
  fieldEnumPrntOutp,
}

public enum testPrntFieldEnumPrntOutp
{
  prnt_fieldEnumPrntOutp,
}
