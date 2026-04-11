//HintName: test_output-parent-param_Model.gen.cs
// Generated from {CurrentDirectory}output-parent-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
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
  : GqlpModelBase
  , ItestPrntOutpPrntParam
{
  public ItestPrntOutpPrntParamObject? As_PrntOutpPrntParam { get; set; }
}

public class testPrntOutpPrntParamObject
  : GqlpModelBase
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
  : GqlpModelBase
  , ItestFldOutpPrntParam
{
  public ItestFldOutpPrntParamObject? As_FldOutpPrntParam { get; set; }
}

public class testFldOutpPrntParamObject
  : GqlpModelBase
  , ItestFldOutpPrntParamObject
{

  public testFldOutpPrntParamObject
    ()
  {
  }
}

public class testInOutpPrntParam
  : GqlpModelBase
  , ItestInOutpPrntParam
{
  public string? AsString { get; set; }
  public ItestInOutpPrntParamObject? As_InOutpPrntParam { get; set; }
}

public class testInOutpPrntParamObject
  : GqlpModelBase
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
  : GqlpModelBase
  , ItestPrntOutpPrntParamIn
{
  public string? AsString { get; set; }
  public ItestPrntOutpPrntParamInObject? As_PrntOutpPrntParamIn { get; set; }
}

public class testPrntOutpPrntParamInObject
  : GqlpModelBase
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
