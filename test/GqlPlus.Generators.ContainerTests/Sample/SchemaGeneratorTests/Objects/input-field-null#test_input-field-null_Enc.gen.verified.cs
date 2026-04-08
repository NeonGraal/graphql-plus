//HintName: test_input-field-null_Enc.gen.cs
// Generated from {CurrentDirectory}input-field-null.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_null;

public class testInpFieldNull
  : GqlpEncoderBase
  , ItestInpFieldNull
{
  public ItestInpFieldNullObject? As_InpFieldNull { get; set; }
}

public class testInpFieldNullObject
  : GqlpEncoderBase
  , ItestInpFieldNullObject
{
  public ItestFldInpFieldNull? Field { get; set; }

  public testInpFieldNullObject
    ()
  {
  }
}

public class testFldInpFieldNull
  : GqlpEncoderBase
  , ItestFldInpFieldNull
{
  public ItestFldInpFieldNullObject? As_FldInpFieldNull { get; set; }
}

public class testFldInpFieldNullObject
  : GqlpEncoderBase
  , ItestFldInpFieldNullObject
{

  public testFldInpFieldNullObject
    ()
  {
  }
}
