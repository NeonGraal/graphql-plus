//HintName: test_constraint-parent-dual-parent+Dual_Impl.gen.cs
// Generated from constraint-parent-dual-parent+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Dual;

public class DualtestCnstPrntDualPrntDual
  : DualtestRefCnstPrntDualPrntDual
  , ItestCnstPrntDualPrntDual
{
}

public class DualtestRefCnstPrntDualPrntDual<Tref>
  : Dualtestref
  , ItestRefCnstPrntDualPrntDual<Tref>
{
}

public class DualtestPrntCnstPrntDualPrntDual
  : ItestPrntCnstPrntDualPrntDual
{
  public String AsString { get; set; }
}

public class DualtestAltCnstPrntDualPrntDual
  : DualtestPrntCnstPrntDualPrntDual
  , ItestAltCnstPrntDualPrntDual
{
  public Number alt { get; set; }
}
