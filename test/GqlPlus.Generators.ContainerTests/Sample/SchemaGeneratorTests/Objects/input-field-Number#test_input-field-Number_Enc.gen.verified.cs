//HintName: test_input-field-Number_Enc.gen.cs
// Generated from {CurrentDirectory}input-field-Number.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_Number;

public class testInpFieldNmbr
  : GqlpEncoderBase
  , ItestInpFieldNmbr
{
  public ItestInpFieldNmbrObject? As_InpFieldNmbr { get; set; }
}

public class testInpFieldNmbrObject
  : GqlpEncoderBase
  , ItestInpFieldNmbrObject
{
  public decimal Field { get; set; }

  public testInpFieldNmbrObject
    ( decimal field
    )
  {
    Field = field;
  }
}
