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

public interface ItestCnstPrntDualGrndDualField
  : ItestRefCnstPrntDualGrndDualField
{
}

public interface ItestRefCnstPrntDualGrndDual<Tref>
  : Itestref
{
  public testRefCnstPrntDualGrndDual RefCnstPrntDualGrndDual { get; set; }
}

public interface ItestRefCnstPrntDualGrndDualField<Tref>
  : ItestrefField
{
}

public interface ItestGrndCnstPrntDualGrndDual
{
  public testString AsString { get; set; }
  public testGrndCnstPrntDualGrndDual GrndCnstPrntDualGrndDual { get; set; }
}

public interface ItestGrndCnstPrntDualGrndDualField
{
}

public interface ItestPrntCnstPrntDualGrndDual
  : ItestGrndCnstPrntDualGrndDual
{
  public testPrntCnstPrntDualGrndDual PrntCnstPrntDualGrndDual { get; set; }
}

public interface ItestPrntCnstPrntDualGrndDualField
  : ItestGrndCnstPrntDualGrndDualField
{
}

public interface ItestAltCnstPrntDualGrndDual
  : ItestPrntCnstPrntDualGrndDual
{
  public testAltCnstPrntDualGrndDual AltCnstPrntDualGrndDual { get; set; }
}

public interface ItestAltCnstPrntDualGrndDualField
  : ItestPrntCnstPrntDualGrndDualField
{
  public testNumber alt { get; set; }
}
