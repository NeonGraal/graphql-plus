//HintName: test_field-object+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-object+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Input;

public class testFieldObjInp
  : GqlpEncoderBase
  , ItestFieldObjInp
{
  public ItestFieldObjInpObject? As_FieldObjInp { get; set; }
}

public class testFieldObjInpObject
  : GqlpEncoderBase
  , ItestFieldObjInpObject
{
  public ItestFldFieldObjInp Field { get; set; }

  public testFieldObjInpObject
    ( ItestFldFieldObjInp field
    )
  {
    Field = field;
  }
}

public class testFldFieldObjInp
  : GqlpEncoderBase
  , ItestFldFieldObjInp
{
  public string? AsString { get; set; }
  public ItestFldFieldObjInpObject? As_FldFieldObjInp { get; set; }
}

public class testFldFieldObjInpObject
  : GqlpEncoderBase
  , ItestFldFieldObjInpObject
{
  public decimal Field { get; set; }

  public testFldFieldObjInpObject
    ( decimal field
    )
  {
    Field = field;
  }
}
