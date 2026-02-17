//HintName: test_parent-descr+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}parent-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Dual;

public class testPrntDescrDual
  : testRefPrntDescrDual
  , ItestPrntDescrDual
{
}

public class testRefPrntDescrDual
  : ItestRefPrntDescrDual
{
  public decimal Parent { get; set; }
}
