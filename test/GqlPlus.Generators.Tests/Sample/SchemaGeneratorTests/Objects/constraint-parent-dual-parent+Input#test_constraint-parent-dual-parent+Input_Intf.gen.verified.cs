//HintName: test_constraint-parent-dual-parent+Input_Intf.gen.cs
// Generated from constraint-parent-dual-parent+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Input;

public interface ItestCnstPrntDualPrntInp
  : ItestRefCnstPrntDualPrntInp
{
  public testCnstPrntDualPrntInp CnstPrntDualPrntInp { get; set; }
}

public interface ItestCnstPrntDualPrntInpObject
  : ItestRefCnstPrntDualPrntInpObject
{
}

public interface ItestRefCnstPrntDualPrntInp<Tref>
  : Itestref
{
  public testRefCnstPrntDualPrntInp RefCnstPrntDualPrntInp { get; set; }
}

public interface ItestRefCnstPrntDualPrntInpObject<Tref>
  : ItestrefObject
{
}

public interface ItestPrntCnstPrntDualPrntInp
{
  public testString AsString { get; set; }
  public testPrntCnstPrntDualPrntInp PrntCnstPrntDualPrntInp { get; set; }
}

public interface ItestPrntCnstPrntDualPrntInpObject
{
}

public interface ItestAltCnstPrntDualPrntInp
  : ItestPrntCnstPrntDualPrntInp
{
  public testAltCnstPrntDualPrntInp AltCnstPrntDualPrntInp { get; set; }
}

public interface ItestAltCnstPrntDualPrntInpObject
  : ItestPrntCnstPrntDualPrntInpObject
{
  public testNumber alt { get; set; }
}
