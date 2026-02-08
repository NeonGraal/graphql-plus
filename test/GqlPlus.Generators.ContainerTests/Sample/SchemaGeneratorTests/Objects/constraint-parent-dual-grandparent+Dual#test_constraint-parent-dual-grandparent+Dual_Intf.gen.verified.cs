//HintName: test_constraint-parent-dual-grandparent+Dual_Intf.gen.cs
// Generated from constraint-parent-dual-grandparent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Dual;

public interface ItestCnstPrntDualGrndDual
  : ItestRefCnstPrntDualGrndDual
{
}

public interface ItestCnstPrntDualGrndDualObject
  : ItestRefCnstPrntDualGrndDualObject
{
}

public interface ItestRefCnstPrntDualGrndDual<Tref>
  : Itestref
{
}

public interface ItestRefCnstPrntDualGrndDualObject<Tref>
  : ItestrefObject
{
}

public interface ItestGrndCnstPrntDualGrndDual
{
  public ItestString AsString { get; set; }
}

public interface ItestGrndCnstPrntDualGrndDualObject
{
}

public interface ItestPrntCnstPrntDualGrndDual
  : ItestGrndCnstPrntDualGrndDual
{
}

public interface ItestPrntCnstPrntDualGrndDualObject
  : ItestGrndCnstPrntDualGrndDualObject
{
}

public interface ItestAltCnstPrntDualGrndDual
  : ItestPrntCnstPrntDualGrndDual
{
}

public interface ItestAltCnstPrntDualGrndDualObject
  : ItestPrntCnstPrntDualGrndDualObject
{
  public ItestNumber Alt { get; set; }
}
