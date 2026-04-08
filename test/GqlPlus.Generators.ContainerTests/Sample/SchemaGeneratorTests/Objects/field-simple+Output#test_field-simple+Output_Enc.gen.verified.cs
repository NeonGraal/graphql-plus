//HintName: test_field-simple+Output_Enc.gen.cs
// Generated from {CurrentDirectory}field-simple+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_simple_Output;

public class testFieldSmplOutp
  : GqlpEncoderBase
  , ItestFieldSmplOutp
{
  public ItestFieldSmplOutpObject? As_FieldSmplOutp { get; set; }
}

public class testFieldSmplOutpObject
  : GqlpEncoderBase
  , ItestFieldSmplOutpObject
{
  public decimal Field { get; set; }

  public testFieldSmplOutpObject
    ( decimal field
    )
  {
    Field = field;
  }
}
