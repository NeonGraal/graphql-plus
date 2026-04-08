//HintName: test_field-value-descr+Output_Enc.gen.cs
// Generated from {CurrentDirectory}field-value-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_descr_Output;

public class testFieldValueDescrOutp
  : GqlpEncoderBase
  , ItestFieldValueDescrOutp
{
  public ItestFieldValueDescrOutpObject? As_FieldValueDescrOutp { get; set; }
}

public class testFieldValueDescrOutpObject
  : GqlpEncoderBase
  , ItestFieldValueDescrOutpObject
{
  public testEnumFieldValueDescrOutp Field { get; set; }

  public testFieldValueDescrOutpObject
    ( testEnumFieldValueDescrOutp field
    )
  {
    Field = field;
  }
}

public enum testEnumFieldValueDescrOutp
{
  fieldValueDescrOutp,
}
