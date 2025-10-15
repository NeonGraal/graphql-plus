//HintName: test_parent-descr+Dual_Impl.gen.cs
// Generated from parent-descr+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Dual;

public class DualtestPrntDescrDual
  : DualtestRefPrntDescrDual
  , ItestPrntDescrDual
{
}

public class DualtestRefPrntDescrDual
  : ItestRefPrntDescrDual
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
