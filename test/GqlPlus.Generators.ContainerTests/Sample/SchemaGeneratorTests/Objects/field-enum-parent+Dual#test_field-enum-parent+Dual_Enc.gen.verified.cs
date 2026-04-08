//HintName: test_field-enum-parent+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Dual;

public class testFieldEnumPrntDual
  : GqlpEncoderBase
  , ItestFieldEnumPrntDual
{
  public ItestFieldEnumPrntDualObject? As_FieldEnumPrntDual { get; set; }
}

public class testFieldEnumPrntDualObject
  : GqlpEncoderBase
  , ItestFieldEnumPrntDualObject
{
  public testEnumFieldEnumPrntDual Field { get; set; }

  public testFieldEnumPrntDualObject
    ( testEnumFieldEnumPrntDual field
    )
  {
    Field = field;
  }
}

public enum testEnumFieldEnumPrntDual
{
  prnt_fieldEnumPrntDual = testPrntFieldEnumPrntDual.prnt_fieldEnumPrntDual,
  fieldEnumPrntDual,
}

public enum testPrntFieldEnumPrntDual
{
  prnt_fieldEnumPrntDual,
}
