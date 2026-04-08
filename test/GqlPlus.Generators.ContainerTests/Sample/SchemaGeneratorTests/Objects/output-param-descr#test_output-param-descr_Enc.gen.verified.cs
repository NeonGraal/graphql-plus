//HintName: test_output-param-descr_Enc.gen.cs
// Generated from {CurrentDirectory}output-param-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_descr;

public class testOutpParamDescr
  : GqlpEncoderBase
  , ItestOutpParamDescr
{
  public ItestOutpParamDescrObject? As_OutpParamDescr { get; set; }
}

public class testOutpParamDescrObject
  : GqlpEncoderBase
  , ItestOutpParamDescrObject
{
  public ItestFldOutpParamDescr? Field(ItestInOutpParamDescr parameter)
    => null;

  public testOutpParamDescrObject
    ()
  {
  }
}

public class testFldOutpParamDescr
  : GqlpEncoderBase
  , ItestFldOutpParamDescr
{
  public ItestFldOutpParamDescrObject? As_FldOutpParamDescr { get; set; }
}

public class testFldOutpParamDescrObject
  : GqlpEncoderBase
  , ItestFldOutpParamDescrObject
{

  public testFldOutpParamDescrObject
    ()
  {
  }
}

public class testInOutpParamDescr
  : GqlpEncoderBase
  , ItestInOutpParamDescr
{
  public string? AsString { get; set; }
  public ItestInOutpParamDescrObject? As_InOutpParamDescr { get; set; }
}

public class testInOutpParamDescrObject
  : GqlpEncoderBase
  , ItestInOutpParamDescrObject
{
  public decimal Param { get; set; }

  public testInOutpParamDescrObject
    ( decimal param
    )
  {
    Param = param;
  }
}
