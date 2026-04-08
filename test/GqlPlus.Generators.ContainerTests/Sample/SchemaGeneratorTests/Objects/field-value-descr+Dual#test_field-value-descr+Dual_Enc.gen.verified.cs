//HintName: test_field-value-descr+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}field-value-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_descr_Dual;

public class testFieldValueDescrDual
  : GqlpEncoderBase
  , ItestFieldValueDescrDual
{
  public ItestFieldValueDescrDualObject? As_FieldValueDescrDual { get; set; }
}

public class testFieldValueDescrDualObject
  : GqlpEncoderBase
  , ItestFieldValueDescrDualObject
{
  public testEnumFieldValueDescrDual Field { get; set; }

  public testFieldValueDescrDualObject
    ( testEnumFieldValueDescrDual field
    )
  {
    Field = field;
  }
}

public enum testEnumFieldValueDescrDual
{
  fieldValueDescrDual,
}
