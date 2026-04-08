//HintName: test_field-descr+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_descr_Input;

public class testFieldDescrInp
  : GqlpEncoderBase
  , ItestFieldDescrInp
{
  public ItestFieldDescrInpObject? As_FieldDescrInp { get; set; }
}

public class testFieldDescrInpObject
  : GqlpEncoderBase
  , ItestFieldDescrInpObject
{
  public string Field { get; set; }

  public testFieldDescrInpObject
    ( string field
    )
  {
    Field = field;
  }
}
