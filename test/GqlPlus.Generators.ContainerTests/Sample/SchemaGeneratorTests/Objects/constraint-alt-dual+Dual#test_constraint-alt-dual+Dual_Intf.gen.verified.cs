//HintName: test_constraint-alt-dual+Dual_Intf.gen.cs
// Generated from constraint-alt-dual+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Dual;

public interface ItestCnstAltDualDual
{
  public ItestRefCnstAltDualDual<ItestAltCnstAltDualDual> AsRefCnstAltDualDual { get; set; }
}

public interface ItestCnstAltDualDualObject
{
}

public interface ItestRefCnstAltDualDual<Tref>
{
  public Tref Asref { get; set; }
}

public interface ItestRefCnstAltDualDualObject<Tref>
{
}

public interface ItestPrntCnstAltDualDual
{
  public ItestString AsString { get; set; }
}

public interface ItestPrntCnstAltDualDualObject
{
}

public interface ItestAltCnstAltDualDual
  : ItestPrntCnstAltDualDual
{
}

public interface ItestAltCnstAltDualDualObject
  : ItestPrntCnstAltDualDualObject
{
  public ItestNumber Alt { get; set; }
}
