//HintName: test_constraint-parent-dual-grandparent+Dual_Intf.gen.cs
// Generated from constraint-parent-dual-grandparent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Dual;

public interface ItestCnstPrntDualGrndDual
  : ItestRefCnstPrntDualGrndDual
{
  ItestCnstPrntDualGrndDualObject AsCnstPrntDualGrndDual { get; }
}

public interface ItestCnstPrntDualGrndDualObject
  : ItestRefCnstPrntDualGrndDualObject
{
}

public interface ItestRefCnstPrntDualGrndDual<Tref>
  : Itestref
{
  ItestRefCnstPrntDualGrndDualObject AsRefCnstPrntDualGrndDual { get; }
}

public interface ItestRefCnstPrntDualGrndDualObject<Tref>
  : ItestrefObject
{
}

public interface ItestGrndCnstPrntDualGrndDual
{
  string AsString { get; }
  ItestGrndCnstPrntDualGrndDualObject AsGrndCnstPrntDualGrndDual { get; }
}

public interface ItestGrndCnstPrntDualGrndDualObject
{
}

public interface ItestPrntCnstPrntDualGrndDual
  : ItestGrndCnstPrntDualGrndDual
{
  ItestPrntCnstPrntDualGrndDualObject AsPrntCnstPrntDualGrndDual { get; }
}

public interface ItestPrntCnstPrntDualGrndDualObject
  : ItestGrndCnstPrntDualGrndDualObject
{
}

public interface ItestAltCnstPrntDualGrndDual
  : ItestPrntCnstPrntDualGrndDual
{
  ItestAltCnstPrntDualGrndDualObject AsAltCnstPrntDualGrndDual { get; }
}

public interface ItestAltCnstPrntDualGrndDualObject
  : ItestPrntCnstPrntDualGrndDualObject
{
  decimal Alt { get; }
}
