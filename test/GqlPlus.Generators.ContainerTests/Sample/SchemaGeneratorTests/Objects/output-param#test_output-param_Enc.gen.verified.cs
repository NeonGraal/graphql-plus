//HintName: test_output-param_Enc.gen.cs
// Generated from {CurrentDirectory}output-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param;

public class testOutpParam
  : GqlpEncoderBase
  , ItestOutpParam
{
  public ItestOutpParamObject? As_OutpParam { get; set; }
}

public class testOutpParamObject
  : GqlpEncoderBase
  , ItestOutpParamObject
{
  public ItestFldOutpParam? Field(ItestInOutpParam parameter)
    => null;

  public testOutpParamObject
    ()
  {
  }
}

public class testFldOutpParam
  : GqlpEncoderBase
  , ItestFldOutpParam
{
  public ItestFldOutpParamObject? As_FldOutpParam { get; set; }
}

public class testFldOutpParamObject
  : GqlpEncoderBase
  , ItestFldOutpParamObject
{

  public testFldOutpParamObject
    ()
  {
  }
}

public class testInOutpParam
  : GqlpEncoderBase
  , ItestInOutpParam
{
  public string? AsString { get; set; }
  public ItestInOutpParamObject? As_InOutpParam { get; set; }
}

public class testInOutpParamObject
  : GqlpEncoderBase
  , ItestInOutpParamObject
{
  public decimal Param { get; set; }

  public testInOutpParamObject
    ( decimal param
    )
  {
    Param = param;
  }
}
