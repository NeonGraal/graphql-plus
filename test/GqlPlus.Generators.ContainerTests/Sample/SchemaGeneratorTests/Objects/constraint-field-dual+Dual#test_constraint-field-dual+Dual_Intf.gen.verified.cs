//HintName: test_constraint-field-dual+Dual_Intf.gen.cs
// Generated from constraint-field-dual+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Dual;

public interface ItestCnstFieldDualDual
  : ItestRefCnstFieldDualDual
{
}

public interface ItestCnstFieldDualDualObject
  : ItestRefCnstFieldDualDualObject
{
}

public interface ItestRefCnstFieldDualDual<Tref>
{
}

public interface ItestRefCnstFieldDualDualObject<Tref>
{
  public Tref Field { get; set; }
}

public interface ItestPrntCnstFieldDualDual
{
  public ItestString AsString { get; set; }
}

public interface ItestPrntCnstFieldDualDualObject
{
}

public interface ItestAltCnstFieldDualDual
  : ItestPrntCnstFieldDualDual
{
}

public interface ItestAltCnstFieldDualDualObject
  : ItestPrntCnstFieldDualDualObject
{
  public ItestNumber Alt { get; set; }
}
