//HintName: test_field-type-descr+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-type-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_type_descr_Input;

public class testFieldTypeDescrInp
  : GqlpEncoderBase
  , ItestFieldTypeDescrInp
{
  public ItestFieldTypeDescrInpObject? As_FieldTypeDescrInp { get; set; }
}

public class testFieldTypeDescrInpObject
  : GqlpEncoderBase
  , ItestFieldTypeDescrInpObject
{
  public decimal Field { get; set; }

  public testFieldTypeDescrInpObject
    ( decimal field
    )
  {
    Field = field;
  }
}
