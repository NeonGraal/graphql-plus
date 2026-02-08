//HintName: test_constraint-parent-dual-parent+Output_Intf.gen.cs
// Generated from constraint-parent-dual-parent+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Output;

public interface ItestCnstPrntDualPrntOutp
  : ItestRefCnstPrntDualPrntOutp
{
}

public interface ItestCnstPrntDualPrntOutpObject
  : ItestRefCnstPrntDualPrntOutpObject
{
}

public interface ItestRefCnstPrntDualPrntOutp<Tref>
  : Itestref
{
}

public interface ItestRefCnstPrntDualPrntOutpObject<Tref>
  : ItestrefObject
{
}

public interface ItestPrntCnstPrntDualPrntOutp
{
  public ItestString AsString { get; set; }
}

public interface ItestPrntCnstPrntDualPrntOutpObject
{
}

public interface ItestAltCnstPrntDualPrntOutp
  : ItestPrntCnstPrntDualPrntOutp
{
}

public interface ItestAltCnstPrntDualPrntOutpObject
  : ItestPrntCnstPrntDualPrntOutpObject
{
  public ItestNumber Alt { get; set; }
}
