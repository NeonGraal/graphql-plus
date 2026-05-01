//HintName: test_output-parent-param_Model.gen.cs
// Generated from {CurrentDirectory}output-parent-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
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
  public ItestFldOutpPrntParam Field { get; set; }
  public ItestFldOutpPrntParam? Call_Field(ItestInOutpPrntParam parameter)
    => null;

  public testOutpPrntParamObject
    ( ItestFldOutpPrntParam pfield
    , ItestFldOutpPrntParam pfield
    ) : base(pfield)
  {
    Field = pfield;
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
  public ItestFldOutpPrntParam Field { get; set; }
  public ItestFldOutpPrntParam? Call_Field(ItestPrntOutpPrntParamIn parameter)
    => null;

  public testPrntOutpPrntParamObject
    ( ItestFldOutpPrntParam pfield
    )
  {
    Field = pfield;
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
    ( decimal pparam
    )
  {
    Param = pparam;
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
    ( decimal pparent
    )
  {
    Parent = pparent;
  }
}
