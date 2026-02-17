//HintName: test_output-param_Impl.gen.cs
// Generated from {CurrentDirectory}output-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param;

public class testOutpParam
  : ItestOutpParam
{
  public ItestFldOutpParam Field (ItestInOutpParam)
{ }
}

public class testFldOutpParam
  : ItestFldOutpParam
{
}

public class testInOutpParam
  : ItestInOutpParam
{
  public decimal Param { get; set; }
}
