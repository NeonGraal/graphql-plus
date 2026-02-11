//HintName: test_constraint-parent-dual-parent+Dual_Intf.gen.cs
// Generated from constraint-parent-dual-parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Dual;

public interface ItestCnstPrntDualPrntDual
  : ItestRefCnstPrntDualPrntDual
{
  ItestCnstPrntDualPrntDualObject AsCnstPrntDualPrntDual { get; }
}

public interface ItestCnstPrntDualPrntDualObject
  : ItestRefCnstPrntDualPrntDualObject
{
}

public interface ItestRefCnstPrntDualPrntDual<Tref>
  : Itestref
{
  ItestRefCnstPrntDualPrntDualObject AsRefCnstPrntDualPrntDual { get; }
}

public interface ItestRefCnstPrntDualPrntDualObject<Tref>
  : ItestrefObject
{
}

public interface ItestPrntCnstPrntDualPrntDual
{
  string AsString { get; }
  ItestPrntCnstPrntDualPrntDualObject AsPrntCnstPrntDualPrntDual { get; }
}

public interface ItestPrntCnstPrntDualPrntDualObject
{
}

public interface ItestAltCnstPrntDualPrntDual
  : ItestPrntCnstPrntDualPrntDual
{
  ItestAltCnstPrntDualPrntDualObject AsAltCnstPrntDualPrntDual { get; }
}

public interface ItestAltCnstPrntDualPrntDualObject
  : ItestPrntCnstPrntDualPrntDualObject
{
  decimal Alt { get; }
}
