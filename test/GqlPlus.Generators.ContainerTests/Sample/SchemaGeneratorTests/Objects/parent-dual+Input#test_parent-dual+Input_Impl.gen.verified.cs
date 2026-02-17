//HintName: test_parent-dual+Input_Impl.gen.cs
// Generated from {CurrentDirectory}parent-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Input;

public class testPrntDualInp
  : testRefPrntDualInp
  , ItestPrntDualInp
{
}

public class testRefPrntDualInp
  : ItestRefPrntDualInp
{
  public decimal Parent { get; set; }
}
