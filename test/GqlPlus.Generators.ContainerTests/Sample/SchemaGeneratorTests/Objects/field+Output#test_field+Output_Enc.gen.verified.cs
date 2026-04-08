//HintName: test_field+Output_Enc.gen.cs
// Generated from {CurrentDirectory}field+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_Output;

public class testFieldOutp
  : GqlpEncoderBase
  , ItestFieldOutp
{
  public ItestFieldOutpObject? As_FieldOutp { get; set; }
}

public class testFieldOutpObject
  : GqlpEncoderBase
  , ItestFieldOutpObject
{
  public string Field { get; set; }

  public testFieldOutpObject
    ( string field
    )
  {
    Field = field;
  }
}
