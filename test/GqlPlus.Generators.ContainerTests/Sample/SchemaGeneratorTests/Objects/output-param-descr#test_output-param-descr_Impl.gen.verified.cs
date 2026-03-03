//HintName: test_output-param-descr_Impl.gen.cs
// Generated from {CurrentDirectory}output-param-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_descr;

public class testOutpParamDescr
  : GqlpModelImplementationBase
  , ItestOutpParamDescr
{
  public ItestOutpParamDescrObject? As_OutpParamDescr { get; set; }
}

public class testOutpParamDescrObject
  : GqlpModelImplementationBase
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
  : GqlpModelImplementationBase
  , ItestFldOutpParamDescr
{
  public ItestFldOutpParamDescrObject? As_FldOutpParamDescr { get; set; }
}

public class testFldOutpParamDescrObject
  : GqlpModelImplementationBase
  , ItestFldOutpParamDescrObject
{

  public testFldOutpParamDescrObject
    ()
  {
  }
}

public class testInOutpParamDescr
  : GqlpModelImplementationBase
  , ItestInOutpParamDescr
{
  public string? AsString { get; set; }
  public ItestInOutpParamDescrObject? As_InOutpParamDescr { get; set; }
}

public class testInOutpParamDescrObject
  : GqlpModelImplementationBase
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
