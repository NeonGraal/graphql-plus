//HintName: test_constraint-parent-dual-grandparent+Dual_Intf.gen.cs
// Generated from constraint-parent-dual-grandparent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Dual;

public interface ItestCnstPrntDualGrndDual
  : ItestRefCnstPrntDualGrndDual
{
  public ItestCnstPrntDualGrndDualObject AsCnstPrntDualGrndDual { get; set; }
}

public interface ItestCnstPrntDualGrndDualObject
  : ItestRefCnstPrntDualGrndDualObject
{
}

public interface ItestRefCnstPrntDualGrndDual<Tref>
  : Itestref
{
  public ItestRefCnstPrntDualGrndDualObject AsRefCnstPrntDualGrndDual { get; set; }
}

public interface ItestRefCnstPrntDualGrndDualObject<Tref>
  : ItestrefObject
{
}

public interface ItestGrndCnstPrntDualGrndDual
{
  public string AsString { get; set; }
  public ItestGrndCnstPrntDualGrndDualObject AsGrndCnstPrntDualGrndDual { get; set; }
}

public interface ItestGrndCnstPrntDualGrndDualObject
{
}

public interface ItestPrntCnstPrntDualGrndDual
  : ItestGrndCnstPrntDualGrndDual
{
  public ItestPrntCnstPrntDualGrndDualObject AsPrntCnstPrntDualGrndDual { get; set; }
}

public interface ItestPrntCnstPrntDualGrndDualObject
  : ItestGrndCnstPrntDualGrndDualObject
{
}

public interface ItestAltCnstPrntDualGrndDual
  : ItestPrntCnstPrntDualGrndDual
{
  public ItestAltCnstPrntDualGrndDualObject AsAltCnstPrntDualGrndDual { get; set; }
}

public interface ItestAltCnstPrntDualGrndDualObject
  : ItestPrntCnstPrntDualGrndDualObject
{
  public decimal Alt { get; set; }
}
