//HintName: test_output-descr-param_Impl.gen.cs
// Generated from {CurrentDirectory}output-descr-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_descr_param;

public class testOutpDescrParam
  : GqlpModelImplementationBase
  , ItestOutpDescrParam
{
  public ItestOutpDescrParamObject? As_OutpDescrParam { get; set; }
}

public class testOutpDescrParamObject
  : GqlpModelImplementationBase
  , ItestOutpDescrParamObject
{
  public ItestFldOutpDescrParam? Field(ItestInOutpDescrParam parameter)
    => null;

  public testOutpDescrParamObject()
  {
  }
}

public class testFldOutpDescrParam
  : GqlpModelImplementationBase
  , ItestFldOutpDescrParam
{
  public ItestFldOutpDescrParamObject? As_FldOutpDescrParam { get; set; }
}

public class testFldOutpDescrParamObject
  : GqlpModelImplementationBase
  , ItestFldOutpDescrParamObject
{

  public testFldOutpDescrParamObject()
  {
  }
}

public class testInOutpDescrParam
  : GqlpModelImplementationBase
  , ItestInOutpDescrParam
{
  public string? AsString { get; set; }
  public ItestInOutpDescrParamObject? As_InOutpDescrParam { get; set; }
}

public class testInOutpDescrParamObject
  : GqlpModelImplementationBase
  , ItestInOutpDescrParamObject
{
  public decimal Param { get; set; }

  public testInOutpDescrParamObject(decimal param)
  {
    Param = param;
  }
}
