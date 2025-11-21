//HintName: test_constraint-parent-dual-parent+Dual_Intf.gen.cs
// Generated from constraint-parent-dual-parent+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Dual;

public interface ItestCnstPrntDualPrntDual
  : ItestRefCnstPrntDualPrntDual
{
  public testCnstPrntDualPrntDual CnstPrntDualPrntDual { get; set; }
}

public interface ItestCnstPrntDualPrntDualField
  : ItestRefCnstPrntDualPrntDualField
{
}

public interface ItestRefCnstPrntDualPrntDual<Tref>
  : Itestref
{
  public testRefCnstPrntDualPrntDual RefCnstPrntDualPrntDual { get; set; }
}

public interface ItestRefCnstPrntDualPrntDualField<Tref>
  : ItestrefField
{
}

public interface ItestPrntCnstPrntDualPrntDual
{
  public testString AsString { get; set; }
  public testPrntCnstPrntDualPrntDual PrntCnstPrntDualPrntDual { get; set; }
}

public interface ItestPrntCnstPrntDualPrntDualField
{
}

public interface ItestAltCnstPrntDualPrntDual
  : ItestPrntCnstPrntDualPrntDual
{
  public testAltCnstPrntDualPrntDual AltCnstPrntDualPrntDual { get; set; }
}

public interface ItestAltCnstPrntDualPrntDualField
  : ItestPrntCnstPrntDualPrntDualField
{
  public testNumber alt { get; set; }
}
