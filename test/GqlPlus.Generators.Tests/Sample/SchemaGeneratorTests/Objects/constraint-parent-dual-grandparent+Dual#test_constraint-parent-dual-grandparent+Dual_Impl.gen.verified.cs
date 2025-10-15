//HintName: test_constraint-parent-dual-grandparent+Dual_Impl.gen.cs
// Generated from constraint-parent-dual-grandparent+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Dual;

public class DualtestCnstPrntDualGrndDual
  : DualtestRefCnstPrntDualGrndDual
  , ItestCnstPrntDualGrndDual
{
}

public class DualtestRefCnstPrntDualGrndDual<Tref>
  : Dualtestref
  , ItestRefCnstPrntDualGrndDual<Tref>
{
}

public class DualtestGrndCnstPrntDualGrndDual
  : ItestGrndCnstPrntDualGrndDual
{
  public String AsString { get; set; }
}

public class DualtestPrntCnstPrntDualGrndDual
  : DualtestGrndCnstPrntDualGrndDual
  , ItestPrntCnstPrntDualGrndDual
{
}

public class DualtestAltCnstPrntDualGrndDual
  : DualtestPrntCnstPrntDualGrndDual
  , ItestAltCnstPrntDualGrndDual
{
  public Number alt { get; set; }
}
