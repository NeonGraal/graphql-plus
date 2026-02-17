//HintName: test_parent+Input_Impl.gen.cs
// Generated from {CurrentDirectory}parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Input;

public class testPrntInp
  : testRefPrntInp
  , ItestPrntInp
{
}

public class testRefPrntInp
  : ItestRefPrntInp
{
  public decimal Parent { get; set; }
}
