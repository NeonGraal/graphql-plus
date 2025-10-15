//HintName: test_parent-alt+Dual_Impl.gen.cs
// Generated from parent-alt+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Dual;

public class DualtestPrntAltDual
  : DualtestRefPrntAltDual
  , ItestPrntAltDual
{
  public Number AsNumber { get; set; }
}

public class DualtestRefPrntAltDual
  : ItestRefPrntAltDual
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
