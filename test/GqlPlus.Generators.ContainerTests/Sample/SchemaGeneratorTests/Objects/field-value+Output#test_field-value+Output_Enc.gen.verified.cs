//HintName: test_field-value+Output_Enc.gen.cs
// Generated from {CurrentDirectory}field-value+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Output;

public class testFieldValueOutp
  : GqlpEncoderBase
  , ItestFieldValueOutp
{
  public ItestFieldValueOutpObject? As_FieldValueOutp { get; set; }
}

public class testFieldValueOutpObject
  : GqlpEncoderBase
  , ItestFieldValueOutpObject
{
  public testEnumFieldValueOutp Field { get; set; }

  public testFieldValueOutpObject
    ( testEnumFieldValueOutp field
    )
  {
    Field = field;
  }
}

public enum testEnumFieldValueOutp
{
  fieldValueOutp,
}
