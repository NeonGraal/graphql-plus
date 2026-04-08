//HintName: test_field-object+Output_Enc.gen.cs
// Generated from {CurrentDirectory}field-object+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Output;

public class testFieldObjOutp
  : GqlpEncoderBase
  , ItestFieldObjOutp
{
  public ItestFieldObjOutpObject? As_FieldObjOutp { get; set; }
}

public class testFieldObjOutpObject
  : GqlpEncoderBase
  , ItestFieldObjOutpObject
{
  public ItestFldFieldObjOutp Field { get; set; }

  public testFieldObjOutpObject
    ( ItestFldFieldObjOutp field
    )
  {
    Field = field;
  }
}

public class testFldFieldObjOutp
  : GqlpEncoderBase
  , ItestFldFieldObjOutp
{
  public string? AsString { get; set; }
  public ItestFldFieldObjOutpObject? As_FldFieldObjOutp { get; set; }
}

public class testFldFieldObjOutpObject
  : GqlpEncoderBase
  , ItestFldFieldObjOutpObject
{
  public decimal Field { get; set; }

  public testFldFieldObjOutpObject
    ( decimal field
    )
  {
    Field = field;
  }
}
