//HintName: test_constraint-parent-dual-grandparent+Dual_Intf.gen.cs
// Generated from constraint-parent-dual-grandparent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Dual;

public interface ItestCnstPrntDualGrndDual
  : ItestRefCnstPrntDualGrndDual
{
  public testCnstPrntDualGrndDual CnstPrntDualGrndDual { get; set; }
}

public interface ItestCnstPrntDualGrndDualObject
  : ItestRefCnstPrntDualGrndDualObject
{
}

public interface ItestRefCnstPrntDualGrndDual<Tref>
  : Itestref
{
  public testRefCnstPrntDualGrndDual RefCnstPrntDualGrndDual { get; set; }
}

public interface ItestRefCnstPrntDualGrndDualObject<Tref>
  : ItestrefObject
{
}

public interface ItestGrndCnstPrntDualGrndDual
{
  public testString AsString { get; set; }
  public testGrndCnstPrntDualGrndDual GrndCnstPrntDualGrndDual { get; set; }
}

public interface ItestGrndCnstPrntDualGrndDualObject
{
}

public interface ItestPrntCnstPrntDualGrndDual
  : ItestGrndCnstPrntDualGrndDual
{
  public testPrntCnstPrntDualGrndDual PrntCnstPrntDualGrndDual { get; set; }
}

public interface ItestPrntCnstPrntDualGrndDualObject
  : ItestGrndCnstPrntDualGrndDualObject
{
}

public interface ItestAltCnstPrntDualGrndDual
  : ItestPrntCnstPrntDualGrndDual
{
  public testAltCnstPrntDualGrndDual AltCnstPrntDualGrndDual { get; set; }
}

public interface ItestAltCnstPrntDualGrndDualObject
  : ItestPrntCnstPrntDualGrndDualObject
{
  public testNumber alt { get; set; }
}
