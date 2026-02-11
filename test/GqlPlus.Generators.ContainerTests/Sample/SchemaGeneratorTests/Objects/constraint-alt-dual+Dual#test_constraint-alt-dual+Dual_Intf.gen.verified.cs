//HintName: test_constraint-alt-dual+Dual_Intf.gen.cs
// Generated from constraint-alt-dual+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Dual;

public interface ItestCnstAltDualDual
{
  ItestRefCnstAltDualDual<ItestAltCnstAltDualDual> AsRefCnstAltDualDual { get; }
  ItestCnstAltDualDualObject AsCnstAltDualDual { get; }
}

public interface ItestCnstAltDualDualObject
{
}

public interface ItestRefCnstAltDualDual<Tref>
{
  Tref Asref { get; }
  ItestRefCnstAltDualDualObject AsRefCnstAltDualDual { get; }
}

public interface ItestRefCnstAltDualDualObject<Tref>
{
}

public interface ItestPrntCnstAltDualDual
{
  string AsString { get; }
  ItestPrntCnstAltDualDualObject AsPrntCnstAltDualDual { get; }
}

public interface ItestPrntCnstAltDualDualObject
{
}

public interface ItestAltCnstAltDualDual
  : ItestPrntCnstAltDualDual
{
  ItestAltCnstAltDualDualObject AsAltCnstAltDualDual { get; }
}

public interface ItestAltCnstAltDualDualObject
  : ItestPrntCnstAltDualDualObject
{
  decimal Alt { get; }
}
