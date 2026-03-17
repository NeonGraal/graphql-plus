//HintName: test_output-parent-param_Model.gen.cs
// Generated from {CurrentDirectory}output-parent-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
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
}

public class testPrntOutpPrntParam
  : GqlpModelImplementationBase
  , ItestPrntOutpPrntParam
{
  public ItestPrntOutpPrntParamObject? As_PrntOutpPrntParam { get; set; }
}

public class testPrntOutpPrntParamObject
  : GqlpModelImplementationBase
  , ItestPrntOutpPrntParamObject
{
  public ItestFldOutpPrntParam? Field(ItestPrntOutpPrntParamIn parameter)
    => null;
}

public class testFldOutpPrntParam
  : GqlpModelImplementationBase
  , ItestFldOutpPrntParam
{
  public ItestFldOutpPrntParamObject? As_FldOutpPrntParam { get; set; }
}

public class testFldOutpPrntParamObject
  : GqlpModelImplementationBase
  , ItestFldOutpPrntParamObject
{
}

public class testInOutpPrntParam
  : GqlpModelImplementationBase
  , ItestInOutpPrntParam
{
  public string? AsString { get; set; }
  public ItestInOutpPrntParamObject? As_InOutpPrntParam { get; set; }
}

public class testInOutpPrntParamObject
  : GqlpModelImplementationBase
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
  : GqlpModelImplementationBase
  , ItestPrntOutpPrntParamIn
{
  public string? AsString { get; set; }
  public ItestPrntOutpPrntParamInObject? As_PrntOutpPrntParamIn { get; set; }
}

public class testPrntOutpPrntParamInObject
  : GqlpModelImplementationBase
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
