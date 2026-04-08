//HintName: test_field-enum+Output_Enc.gen.cs
// Generated from {CurrentDirectory}field-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Output;

public class testFieldEnumOutp
  : GqlpEncoderBase
  , ItestFieldEnumOutp
{
  public ItestFieldEnumOutpObject? As_FieldEnumOutp { get; set; }
}

public class testFieldEnumOutpObject
  : GqlpEncoderBase
  , ItestFieldEnumOutpObject
{
  public testEnumFieldEnumOutp Field { get; set; }

  public testFieldEnumOutpObject
    ( testEnumFieldEnumOutp field
    )
  {
    Field = field;
  }
}

public enum testEnumFieldEnumOutp
{
  fieldEnumOutp,
}
