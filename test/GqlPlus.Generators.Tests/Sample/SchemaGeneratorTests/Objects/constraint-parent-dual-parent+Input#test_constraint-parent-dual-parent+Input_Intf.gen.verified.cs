//HintName: test_constraint-parent-dual-parent+Input_Intf.gen.cs
// Generated from constraint-parent-dual-parent+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Input;

public interface ItestCnstPrntDualPrntInp
  : ItestRefCnstPrntDualPrntInp
{
}

public interface ItestRefCnstPrntDualPrntInp<Tref>
  : Itestref
{
}

public interface ItestPrntCnstPrntDualPrntInp
{
  String AsString { get; }
}

public interface ItestAltCnstPrntDualPrntInp
  : ItestPrntCnstPrntDualPrntInp
{
  Number alt { get; }
}
