//HintName: test_parent-dual+Output_Impl.gen.cs
// Generated from {CurrentDirectory}parent-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Output;

public class testPrntDualOutp
  : testRefPrntDualOutp
  , ItestPrntDualOutp
{
}

public class testRefPrntDualOutp
  : ItestRefPrntDualOutp
{
  public decimal Parent { get; set; }
}
