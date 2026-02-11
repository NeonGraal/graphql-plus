//HintName: test_constraint-field-dual+Dual_Intf.gen.cs
// Generated from constraint-field-dual+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Dual;

public interface ItestCnstFieldDualDual
  : ItestRefCnstFieldDualDual
{
  ItestCnstFieldDualDualObject AsCnstFieldDualDual { get; }
}

public interface ItestCnstFieldDualDualObject
  : ItestRefCnstFieldDualDualObject
{
}

public interface ItestRefCnstFieldDualDual<Tref>
{
  ItestRefCnstFieldDualDualObject AsRefCnstFieldDualDual { get; }
}

public interface ItestRefCnstFieldDualDualObject<Tref>
{
  Tref Field { get; }
}

public interface ItestPrntCnstFieldDualDual
{
  string AsString { get; }
  ItestPrntCnstFieldDualDualObject AsPrntCnstFieldDualDual { get; }
}

public interface ItestPrntCnstFieldDualDualObject
{
}

public interface ItestAltCnstFieldDualDual
  : ItestPrntCnstFieldDualDual
{
  ItestAltCnstFieldDualDualObject AsAltCnstFieldDualDual { get; }
}

public interface ItestAltCnstFieldDualDualObject
  : ItestPrntCnstFieldDualDualObject
{
  decimal Alt { get; }
}
