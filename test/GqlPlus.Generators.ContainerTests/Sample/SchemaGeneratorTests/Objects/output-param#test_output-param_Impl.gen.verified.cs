//HintName: test_output-param_Impl.gen.cs
// Generated from {CurrentDirectory}output-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param;

public class testOutpParam
  : GqlpModelImplementationBase
  , ItestOutpParam
{
  public ItestOutpParamObject? As_OutpParam { get; set; }
}

public class testOutpParamObject
  : GqlpModelImplementationBase
  , ItestOutpParamObject
{
  public ItestFldOutpParam? Field(ItestInOutpParam parameter)
    => null;

  public testOutpParamObject()
  {
  }
}

public class testFldOutpParam
  : GqlpModelImplementationBase
  , ItestFldOutpParam
{
  public ItestFldOutpParamObject? As_FldOutpParam { get; set; }
}

public class testFldOutpParamObject
  : GqlpModelImplementationBase
  , ItestFldOutpParamObject
{

  public testFldOutpParamObject()
  {
  }
}

public class testInOutpParam
  : GqlpModelImplementationBase
  , ItestInOutpParam
{
  public string? AsString { get; set; }
  public ItestInOutpParamObject? As_InOutpParam { get; set; }
}

public class testInOutpParamObject
  : GqlpModelImplementationBase
  , ItestInOutpParamObject
{
  public decimal Param { get; set; }

  public testInOutpParamObject(decimal param)
  {
    Param = param;
  }
}
