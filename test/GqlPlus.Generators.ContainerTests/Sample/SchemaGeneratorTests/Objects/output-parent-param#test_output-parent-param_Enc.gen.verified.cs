//HintName: test_output-parent-param_Enc.gen.cs
// Generated from {CurrentDirectory}output-parent-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_param;

public class testOutpPrntParam
  : testPrntOutpPrntParam
  , ItestOutpPrntParam
{
  public ItestOutpPrntParamObject? As_OutpPrntParam { get; set; }
}

public class testOutpPrntParamObject
  : testPrntOutpPrntParamObject
  , ItestOutpPrntParamObject
{
  public ItestFldOutpPrntParam? Field(ItestInOutpPrntParam parameter)
    => null;

  public testOutpPrntParamObject
    ()
  {
  }
}

public class testPrntOutpPrntParam
  : GqlpEncoderBase
  , ItestPrntOutpPrntParam
{
  public ItestPrntOutpPrntParamObject? As_PrntOutpPrntParam { get; set; }
}

public class testPrntOutpPrntParamObject
  : GqlpEncoderBase
  , ItestPrntOutpPrntParamObject
{
  public ItestFldOutpPrntParam? Field(ItestPrntOutpPrntParamIn parameter)
    => null;

  public testPrntOutpPrntParamObject
    ()
  {
  }
}

public class testFldOutpPrntParam
  : GqlpEncoderBase
  , ItestFldOutpPrntParam
{
  public ItestFldOutpPrntParamObject? As_FldOutpPrntParam { get; set; }
}

public class testFldOutpPrntParamObject
  : GqlpEncoderBase
  , ItestFldOutpPrntParamObject
{

  public testFldOutpPrntParamObject
    ()
  {
  }
}

public class testInOutpPrntParam
  : GqlpEncoderBase
  , ItestInOutpPrntParam
{
  public string? AsString { get; set; }
  public ItestInOutpPrntParamObject? As_InOutpPrntParam { get; set; }
}

public class testInOutpPrntParamObject
  : GqlpEncoderBase
  , ItestInOutpPrntParamObject
{
  public decimal Param { get; set; }

  public testInOutpPrntParamObject
    ( decimal param
    )
  {
    Param = param;
  }
}

public class testPrntOutpPrntParamIn
  : GqlpEncoderBase
  , ItestPrntOutpPrntParamIn
{
  public string? AsString { get; set; }
  public ItestPrntOutpPrntParamInObject? As_PrntOutpPrntParamIn { get; set; }
}

public class testPrntOutpPrntParamInObject
  : GqlpEncoderBase
  , ItestPrntOutpPrntParamInObject
{
  public decimal Parent { get; set; }

  public testPrntOutpPrntParamInObject
    ( decimal parent
    )
  {
    Parent = parent;
  }
}
