//HintName: test_parent-field+Dual_Impl.gen.cs
// Generated from parent-field+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Dual;

public class testPrntFieldDual
  : testRefPrntFieldDual
  , ItestPrntFieldDual
{
  public Number field { get; set; }
}

public class testRefPrntFieldDual
  : ItestRefPrntFieldDual
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
