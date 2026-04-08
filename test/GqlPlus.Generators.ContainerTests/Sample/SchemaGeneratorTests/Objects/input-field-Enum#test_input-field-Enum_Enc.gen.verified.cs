//HintName: test_input-field-Enum_Enc.gen.cs
// Generated from {CurrentDirectory}input-field-Enum.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_Enum;

public class testInpFieldEnum
  : GqlpEncoderBase
  , ItestInpFieldEnum
{
  public ItestInpFieldEnumObject? As_InpFieldEnum { get; set; }
}

public class testInpFieldEnumObject
  : GqlpEncoderBase
  , ItestInpFieldEnumObject
{
  public testEnumInpFieldEnum Field { get; set; }

  public testInpFieldEnumObject
    ( testEnumInpFieldEnum field
    )
  {
    Field = field;
  }
}

public enum testEnumInpFieldEnum
{
  inpFieldEnum,
}
