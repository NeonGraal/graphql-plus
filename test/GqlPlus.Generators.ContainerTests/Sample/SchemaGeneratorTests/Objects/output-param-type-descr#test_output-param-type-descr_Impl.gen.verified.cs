//HintName: test_output-param-type-descr_Impl.gen.cs
// Generated from {CurrentDirectory}output-param-type-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_type_descr;

public class testOutpParamTypeDescr
  : GqlpModelImplementationBase
  , ItestOutpParamTypeDescr
{
  public ItestOutpParamTypeDescrObject? As_OutpParamTypeDescr { get; set; }
}

public class testOutpParamTypeDescrObject
  : GqlpModelImplementationBase
  , ItestOutpParamTypeDescrObject
{
  public ItestFldOutpParamTypeDescr? Field(ItestInOutpParamTypeDescr parameter)
    => null;

  public testOutpParamTypeDescrObject()
  {
  }
}

public class testFldOutpParamTypeDescr
  : GqlpModelImplementationBase
  , ItestFldOutpParamTypeDescr
{
  public ItestFldOutpParamTypeDescrObject? As_FldOutpParamTypeDescr { get; set; }
}

public class testFldOutpParamTypeDescrObject
  : GqlpModelImplementationBase
  , ItestFldOutpParamTypeDescrObject
{

  public testFldOutpParamTypeDescrObject()
  {
  }
}

public class testInOutpParamTypeDescr
  : GqlpModelImplementationBase
  , ItestInOutpParamTypeDescr
{
  public string? AsString { get; set; }
  public ItestInOutpParamTypeDescrObject? As_InOutpParamTypeDescr { get; set; }
}

public class testInOutpParamTypeDescrObject
  : GqlpModelImplementationBase
  , ItestInOutpParamTypeDescrObject
{
  public decimal Param { get; set; }

  public testInOutpParamTypeDescrObject(decimal param)
  {
    Param = param;
  }
}
