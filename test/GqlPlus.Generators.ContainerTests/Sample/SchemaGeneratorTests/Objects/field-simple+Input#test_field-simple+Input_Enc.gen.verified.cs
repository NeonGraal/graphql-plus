//HintName: test_field-simple+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-simple+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_simple_Input;

public class testFieldSmplInp
  : GqlpEncoderBase
  , ItestFieldSmplInp
{
  public ItestFieldSmplInpObject? As_FieldSmplInp { get; set; }
}

public class testFieldSmplInpObject
  : GqlpEncoderBase
  , ItestFieldSmplInpObject
{
  public decimal Field { get; set; }

  public testFieldSmplInpObject
    ( decimal field
    )
  {
    Field = field;
  }
}
