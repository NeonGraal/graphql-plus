//HintName: test_output-descr-param_Enc.gen.cs
// Generated from {CurrentDirectory}output-descr-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_descr_param;

public class testOutpDescrParam
  : GqlpEncoderBase
  , ItestOutpDescrParam
{
  public ItestOutpDescrParamObject? As_OutpDescrParam { get; set; }
}

public class testOutpDescrParamObject
  : GqlpEncoderBase
  , ItestOutpDescrParamObject
{
  public ItestFldOutpDescrParam? Field(ItestInOutpDescrParam parameter)
    => null;

  public testOutpDescrParamObject
    ()
  {
  }
}

public class testFldOutpDescrParam
  : GqlpEncoderBase
  , ItestFldOutpDescrParam
{
  public ItestFldOutpDescrParamObject? As_FldOutpDescrParam { get; set; }
}

public class testFldOutpDescrParamObject
  : GqlpEncoderBase
  , ItestFldOutpDescrParamObject
{

  public testFldOutpDescrParamObject
    ()
  {
  }
}

public class testInOutpDescrParam
  : GqlpEncoderBase
  , ItestInOutpDescrParam
{
  public string? AsString { get; set; }
  public ItestInOutpDescrParamObject? As_InOutpDescrParam { get; set; }
}

public class testInOutpDescrParamObject
  : GqlpEncoderBase
  , ItestInOutpDescrParamObject
{
  public decimal Param { get; set; }

  public testInOutpDescrParamObject
    ( decimal param
    )
  {
    Param = param;
  }
}
