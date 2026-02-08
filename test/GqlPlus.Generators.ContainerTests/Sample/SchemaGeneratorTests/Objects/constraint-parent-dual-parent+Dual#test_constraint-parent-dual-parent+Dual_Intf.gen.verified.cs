//HintName: test_constraint-parent-dual-parent+Dual_Intf.gen.cs
// Generated from constraint-parent-dual-parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Dual;

public interface ItestCnstPrntDualPrntDual
  : ItestRefCnstPrntDualPrntDual
{
}

public interface ItestCnstPrntDualPrntDualObject
  : ItestRefCnstPrntDualPrntDualObject
{
}

public interface ItestRefCnstPrntDualPrntDual<Tref>
  : Itestref
{
}

public interface ItestRefCnstPrntDualPrntDualObject<Tref>
  : ItestrefObject
{
}

public interface ItestPrntCnstPrntDualPrntDual
{
  public ItestString AsString { get; set; }
}

public interface ItestPrntCnstPrntDualPrntDualObject
{
}

public interface ItestAltCnstPrntDualPrntDual
  : ItestPrntCnstPrntDualPrntDual
{
}

public interface ItestAltCnstPrntDualPrntDualObject
  : ItestPrntCnstPrntDualPrntDualObject
{
  public ItestNumber Alt { get; set; }
}
