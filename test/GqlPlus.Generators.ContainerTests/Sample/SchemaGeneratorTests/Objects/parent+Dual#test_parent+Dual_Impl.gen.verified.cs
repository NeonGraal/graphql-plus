//HintName: test_parent+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Dual;

public class testPrntDual
  : testRefPrntDual
  , ItestPrntDual
{
}

public class testRefPrntDual
  : ItestRefPrntDual
{
  public decimal Parent { get; set; }
}
