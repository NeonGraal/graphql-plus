//HintName: test_output-param-type-descr_Enc.gen.cs
// Generated from {CurrentDirectory}output-param-type-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_type_descr;

public class testOutpParamTypeDescr
  : GqlpEncoderBase
  , ItestOutpParamTypeDescr
{
  public ItestOutpParamTypeDescrObject? As_OutpParamTypeDescr { get; set; }
}

public class testOutpParamTypeDescrObject
  : GqlpEncoderBase
  , ItestOutpParamTypeDescrObject
{
  public ItestFldOutpParamTypeDescr? Field(ItestInOutpParamTypeDescr parameter)
    => null;

  public testOutpParamTypeDescrObject
    ()
  {
  }
}

public class testFldOutpParamTypeDescr
  : GqlpEncoderBase
  , ItestFldOutpParamTypeDescr
{
  public ItestFldOutpParamTypeDescrObject? As_FldOutpParamTypeDescr { get; set; }
}

public class testFldOutpParamTypeDescrObject
  : GqlpEncoderBase
  , ItestFldOutpParamTypeDescrObject
{

  public testFldOutpParamTypeDescrObject
    ()
  {
  }
}

public class testInOutpParamTypeDescr
  : GqlpEncoderBase
  , ItestInOutpParamTypeDescr
{
  public string? AsString { get; set; }
  public ItestInOutpParamTypeDescrObject? As_InOutpParamTypeDescr { get; set; }
}

public class testInOutpParamTypeDescrObject
  : GqlpEncoderBase
  , ItestInOutpParamTypeDescrObject
{
  public decimal Param { get; set; }

  public testInOutpParamTypeDescrObject
    ( decimal param
    )
  {
    Param = param;
  }
}
