//HintName: test_constraint-alt-dual+Dual_Intf.gen.cs
// Generated from constraint-alt-dual+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Dual;

public interface ItestCnstAltDualDual
{
  RefCnstAltDualDual<AltCnstAltDualDual> AsRefCnstAltDualDual { get; }
}

public interface ItestRefCnstAltDualDual<Tref>
{
  Tref Asref { get; }
}

public interface ItestPrntCnstAltDualDual
{
  String AsString { get; }
}

public interface ItestAltCnstAltDualDual
  : ItestPrntCnstAltDualDual
{
  Number alt { get; }
}
