//HintName: test_parent-descr+Output_Impl.gen.cs
// Generated from {CurrentDirectory}parent-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Output;

public class testPrntDescrOutp
  : testRefPrntDescrOutp
  , ItestPrntDescrOutp
{
}

public class testRefPrntDescrOutp
  : ItestRefPrntDescrOutp
{
  public decimal Parent { get; set; }
}
