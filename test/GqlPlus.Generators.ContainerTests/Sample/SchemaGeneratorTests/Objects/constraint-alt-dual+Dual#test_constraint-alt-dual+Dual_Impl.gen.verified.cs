//HintName: test_constraint-alt-dual+Dual_Impl.gen.cs
// Generated from constraint-alt-dual+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Dual;

public class testCnstAltDualDual
  : ItestCnstAltDualDual
{
  public ItestRefCnstAltDualDual<ItestAltCnstAltDualDual> AsRefCnstAltDualDual { get; set; }
  public ItestCnstAltDualDualObject AsCnstAltDualDual { get; set; }
}

public class testRefCnstAltDualDual<TRef>
  : ItestRefCnstAltDualDual<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefCnstAltDualDualObject AsRefCnstAltDualDual { get; set; }
}

public class testPrntCnstAltDualDual
  : ItestPrntCnstAltDualDual
{
  public string AsString { get; set; }
  public ItestPrntCnstAltDualDualObject AsPrntCnstAltDualDual { get; set; }
}

public class testAltCnstAltDualDual
  : testPrntCnstAltDualDual
  , ItestAltCnstAltDualDual
{
  public decimal Alt { get; set; }
  public ItestAltCnstAltDualDualObject AsAltCnstAltDualDual { get; set; }
}
