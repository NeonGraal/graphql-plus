//HintName: test_field-value+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}field-value+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Dual;

public class testFieldValueDual
  : GqlpEncoderBase
  , ItestFieldValueDual
{
  public ItestFieldValueDualObject? As_FieldValueDual { get; set; }
}

public class testFieldValueDualObject
  : GqlpEncoderBase
  , ItestFieldValueDualObject
{
  public testEnumFieldValueDual Field { get; set; }

  public testFieldValueDualObject
    ( testEnumFieldValueDual field
    )
  {
    Field = field;
  }
}

public enum testEnumFieldValueDual
{
  fieldValueDual,
}
