//HintName: test_parent+Output_Impl.gen.cs
// Generated from {CurrentDirectory}parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Output;

public class testPrntOutp
  : testRefPrntOutp
  , ItestPrntOutp
{
}

public class testRefPrntOutp
  : ItestRefPrntOutp
{
  public decimal Parent { get; set; }
}
