//HintName: test_field-mod-Enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-mod-Enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_Enum_Input;

public class testFieldModEnumInp
  : GqlpEncoderBase
  , ItestFieldModEnumInp
{
  public ItestFieldModEnumInpObject? As_FieldModEnumInp { get; set; }
}

public class testFieldModEnumInpObject
  : GqlpEncoderBase
  , ItestFieldModEnumInpObject
{
  public IDictionary<testEnumFieldModEnumInp, string> Field { get; set; }

  public testFieldModEnumInpObject
    ( IDictionary<testEnumFieldModEnumInp, string> field
    )
  {
    Field = field;
  }
}

public enum testEnumFieldModEnumInp
{
  value,
}
