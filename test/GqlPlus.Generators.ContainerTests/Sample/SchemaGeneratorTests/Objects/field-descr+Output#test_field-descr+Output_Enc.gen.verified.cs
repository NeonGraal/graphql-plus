//HintName: test_field-descr+Output_Enc.gen.cs
// Generated from {CurrentDirectory}field-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_descr_Output;

public class testFieldDescrOutp
  : GqlpEncoderBase
  , ItestFieldDescrOutp
{
  public ItestFieldDescrOutpObject? As_FieldDescrOutp { get; set; }
}

public class testFieldDescrOutpObject
  : GqlpEncoderBase
  , ItestFieldDescrOutpObject
{
  public string Field { get; set; }

  public testFieldDescrOutpObject
    ( string field
    )
  {
    Field = field;
  }
}
