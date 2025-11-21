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

public interface ItestCnstPrntDualPrntInpField
  : ItestRefCnstPrntDualPrntInpField
{
}

public interface ItestRefCnstPrntDualPrntInp<Tref>
  : Itestref
{
  public testRefCnstPrntDualPrntInp RefCnstPrntDualPrntInp { get; set; }
}

public interface ItestRefCnstPrntDualPrntInpField<Tref>
  : ItestrefField
{
}

public interface ItestPrntCnstPrntDualPrntInp
{
  public testString AsString { get; set; }
  public testPrntCnstPrntDualPrntInp PrntCnstPrntDualPrntInp { get; set; }
}

public interface ItestPrntCnstPrntDualPrntInpField
{
}

public interface ItestAltCnstPrntDualPrntInp
  : ItestPrntCnstPrntDualPrntInp
{
  public testAltCnstPrntDualPrntInp AltCnstPrntDualPrntInp { get; set; }
}

public interface ItestAltCnstPrntDualPrntInpField
  : ItestPrntCnstPrntDualPrntInpField
{
  public testNumber alt { get; set; }
}
