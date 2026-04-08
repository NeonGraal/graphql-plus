//HintName: test_field-type-descr+Output_Enc.gen.cs
// Generated from {CurrentDirectory}field-type-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_type_descr_Output;

public class testFieldTypeDescrOutp
  : GqlpEncoderBase
  , ItestFieldTypeDescrOutp
{
  public ItestFieldTypeDescrOutpObject? As_FieldTypeDescrOutp { get; set; }
}

public class testFieldTypeDescrOutpObject
  : GqlpEncoderBase
  , ItestFieldTypeDescrOutpObject
{
  public decimal Field { get; set; }

  public testFieldTypeDescrOutpObject
    ( decimal field
    )
  {
    Field = field;
  }
}
