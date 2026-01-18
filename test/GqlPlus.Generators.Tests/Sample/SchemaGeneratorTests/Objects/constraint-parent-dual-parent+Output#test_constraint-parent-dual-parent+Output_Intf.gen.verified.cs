//HintName: test_constraint-parent-dual-parent+Output_Intf.gen.cs
// Generated from constraint-parent-dual-parent+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Output;

public interface ItestCnstPrntDualPrntOutp
  : ItestRefCnstPrntDualPrntOutp
{
  public testCnstPrntDualPrntOutp CnstPrntDualPrntOutp { get; set; }
}

public interface ItestCnstPrntDualPrntOutpField
  : ItestRefCnstPrntDualPrntOutpField
{
}

public interface ItestRefCnstPrntDualPrntOutp<Tref>
  : Itestref
{
  public testRefCnstPrntDualPrntOutp RefCnstPrntDualPrntOutp { get; set; }
}

public interface ItestRefCnstPrntDualPrntOutpField<Tref>
  : ItestrefField
{
}

public interface ItestPrntCnstPrntDualPrntOutp
{
  public testString AsString { get; set; }
  public testPrntCnstPrntDualPrntOutp PrntCnstPrntDualPrntOutp { get; set; }
}

public interface ItestPrntCnstPrntDualPrntOutpField
{
}

public interface ItestAltCnstPrntDualPrntOutp
  : ItestPrntCnstPrntDualPrntOutp
{
  public testAltCnstPrntDualPrntOutp AltCnstPrntDualPrntOutp { get; set; }
}

public interface ItestAltCnstPrntDualPrntOutpField
  : ItestPrntCnstPrntDualPrntOutpField
{
  public testNumber alt { get; set; }
}
