//HintName: test_constraint-parent-dual-parent+Dual_Intf.gen.cs
// Generated from constraint-parent-dual-parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Dual;

public interface ItestCnstPrntDualPrntDual
  : ItestRefCnstPrntDualPrntDual
{
  public ItestCnstPrntDualPrntDualObject AsCnstPrntDualPrntDual { get; set; }
}

public interface ItestCnstPrntDualPrntDualObject
  : ItestRefCnstPrntDualPrntDualObject
{
}

public interface ItestRefCnstPrntDualPrntDual<Tref>
  : Itestref
{
  public ItestRefCnstPrntDualPrntDualObject AsRefCnstPrntDualPrntDual { get; set; }
}

public interface ItestRefCnstPrntDualPrntDualObject<Tref>
  : ItestrefObject
{
}

public interface ItestPrntCnstPrntDualPrntDual
{
  public string AsString { get; set; }
  public ItestPrntCnstPrntDualPrntDualObject AsPrntCnstPrntDualPrntDual { get; set; }
}

public interface ItestPrntCnstPrntDualPrntDualObject
{
}

public interface ItestAltCnstPrntDualPrntDual
  : ItestPrntCnstPrntDualPrntDual
{
  public ItestAltCnstPrntDualPrntDualObject AsAltCnstPrntDualPrntDual { get; set; }
}

public interface ItestAltCnstPrntDualPrntDualObject
  : ItestPrntCnstPrntDualPrntDualObject
{
  public decimal Alt { get; set; }
}
