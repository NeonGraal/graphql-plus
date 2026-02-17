//HintName: test_output-parent-param_Impl.gen.cs
// Generated from {CurrentDirectory}output-parent-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_param;

public class testOutpPrntParam
  : testPrntOutpPrntParam
  , ItestOutpPrntParam
{
  public ItestFldOutpPrntParam Field (ItestInOutpPrntParam)
{ }
}

public class testPrntOutpPrntParam
  : ItestPrntOutpPrntParam
{
  public ItestFldOutpPrntParam Field (ItestPrntOutpPrntParamIn)
{ }
}

public class testFldOutpPrntParam
  : ItestFldOutpPrntParam
{
}

public class testInOutpPrntParam
  : ItestInOutpPrntParam
{
  public decimal Param { get; set; }
}

public class testPrntOutpPrntParamIn
  : ItestPrntOutpPrntParamIn
{
  public decimal Parent { get; set; }
}
