//HintName: test_field-mod-Enum+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}field-mod-Enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_Enum_Dual;

public class testFieldModEnumDual
  : GqlpEncoderBase
  , ItestFieldModEnumDual
{
  public ItestFieldModEnumDualObject? As_FieldModEnumDual { get; set; }
}

public class testFieldModEnumDualObject
  : GqlpEncoderBase
  , ItestFieldModEnumDualObject
{
  public IDictionary<testEnumFieldModEnumDual, string> Field { get; set; }

  public testFieldModEnumDualObject
    ( IDictionary<testEnumFieldModEnumDual, string> field
    )
  {
    Field = field;
  }
}

public enum testEnumFieldModEnumDual
{
  value,
}
