//HintName: test_output-param-descr_Model.gen.cs
// Generated from {CurrentDirectory}output-param-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_descr;

public class testOutpParamDescr
  : GqlpModelBase
  , ItestOutpParamDescr
{
  public ItestOutpParamDescrObject? As_OutpParamDescr { get; set; }
}

public class testOutpParamDescrObject
  : GqlpModelBase
  , ItestOutpParamDescrObject
{
  public ItestFldOutpParamDescr? Field(ItestInOutpParamDescr parameter)
    => null;
  public ItestFldOutpParamDescr? Field()
    => null;

  public testOutpParamDescrObject
    ()
  {
  }
}

public class testFldOutpParamDescr
  : GqlpModelBase
  , ItestFldOutpParamDescr
{
  public ItestFldOutpParamDescrObject? As_FldOutpParamDescr { get; set; }
}

public class testFldOutpParamDescrObject
  : GqlpModelBase
  , ItestFldOutpParamDescrObject
{

  public testFldOutpParamDescrObject
    ()
  {
  }
}

public class testInOutpParamDescr
  : GqlpModelBase
  , ItestInOutpParamDescr
{
  public string? AsString { get; set; }
  public ItestInOutpParamDescrObject? As_InOutpParamDescr { get; set; }
}

public class testInOutpParamDescrObject
  : GqlpModelBase
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
