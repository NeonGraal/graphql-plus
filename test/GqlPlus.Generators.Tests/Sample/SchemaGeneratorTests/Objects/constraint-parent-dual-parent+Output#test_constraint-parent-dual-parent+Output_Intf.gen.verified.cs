//HintName: test_constraint-parent-dual-parent+Output_Intf.gen.cs
// Generated from constraint-parent-dual-parent+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Output;

public interface ItestCnstPrntDualPrntOutp
  : ItestRefCnstPrntDualPrntOutp
{
}

public interface ItestRefCnstPrntDualPrntOutp<Tref>
  : Itestref
{
}

public interface ItestPrntCnstPrntDualPrntOutp
{
  String AsString { get; }
}

public interface ItestAltCnstPrntDualPrntOutp
  : ItestPrntCnstPrntDualPrntOutp
{
  Number alt { get; }
}
