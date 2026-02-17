//HintName: test_parent-field+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}parent-field+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Dual;

public class testPrntFieldDual
  : testRefPrntFieldDual
  , ItestPrntFieldDual
{
  public decimal Field { get; set; }
}

public class testRefPrntFieldDual
  : ItestRefPrntFieldDual
{
  public decimal Parent { get; set; }
}
