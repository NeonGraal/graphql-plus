//HintName: test_input-field-descr-Number_Enc.gen.cs
// Generated from {CurrentDirectory}input-field-descr-Number.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_descr_Number;

public class testInpFieldDescrNmbr
  : GqlpEncoderBase
  , ItestInpFieldDescrNmbr
{
  public ItestInpFieldDescrNmbrObject? As_InpFieldDescrNmbr { get; set; }
}

public class testInpFieldDescrNmbrObject
  : GqlpEncoderBase
  , ItestInpFieldDescrNmbrObject
{
  public decimal Field { get; set; }

  public testInpFieldDescrNmbrObject
    ( decimal field
    )
  {
    Field = field;
  }
}
