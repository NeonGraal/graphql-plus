//HintName: test_parent-alt+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}parent-alt+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Dual;

public class testPrntAltDual
  : testRefPrntAltDual
  , ItestPrntAltDual
{
}

public class testRefPrntAltDual
  : ItestRefPrntAltDual
{
  public decimal Parent { get; set; }
}
