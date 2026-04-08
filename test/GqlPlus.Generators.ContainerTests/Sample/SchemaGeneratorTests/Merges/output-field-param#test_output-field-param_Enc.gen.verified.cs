//HintName: test_output-field-param_Enc.gen.cs
// Generated from {CurrentDirectory}output-field-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_field_param;

public class testOutpFieldParam
  : GqlpEncoderBase
  , ItestOutpFieldParam
{
  public ItestOutpFieldParamObject? As_OutpFieldParam { get; set; }
}

public class testOutpFieldParamObject
  : GqlpEncoderBase
  , ItestOutpFieldParamObject
{
  public ItestFldOutpFieldParam? Field(ItestOutpFieldParam1 parameter)
    => null;

  public testOutpFieldParamObject
    ()
  {
  }
}

public class testOutpFieldParam1
  : GqlpEncoderBase
  , ItestOutpFieldParam1
{
  public ItestOutpFieldParam1Object? As_OutpFieldParam1 { get; set; }
}

public class testOutpFieldParam1Object
  : GqlpEncoderBase
  , ItestOutpFieldParam1Object
{

  public testOutpFieldParam1Object
    ()
  {
  }
}

public class testOutpFieldParam2
  : GqlpEncoderBase
  , ItestOutpFieldParam2
{
  public ItestOutpFieldParam2Object? As_OutpFieldParam2 { get; set; }
}

public class testOutpFieldParam2Object
  : GqlpEncoderBase
  , ItestOutpFieldParam2Object
{

  public testOutpFieldParam2Object
    ()
  {
  }
}

public class testFldOutpFieldParam
  : GqlpEncoderBase
  , ItestFldOutpFieldParam
{
  public ItestFldOutpFieldParamObject? As_FldOutpFieldParam { get; set; }
}

public class testFldOutpFieldParamObject
  : GqlpEncoderBase
  , ItestFldOutpFieldParamObject
{

  public testFldOutpFieldParamObject
    ()
  {
  }
}
