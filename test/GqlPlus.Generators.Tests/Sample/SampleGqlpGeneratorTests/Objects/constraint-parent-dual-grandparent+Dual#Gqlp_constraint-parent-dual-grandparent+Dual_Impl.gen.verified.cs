//HintName: Gqlp_constraint-parent-dual-grandparent+Dual_Impl.gen.cs
// Generated from constraint-parent-dual-grandparent+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_parent_dual_grandparent_Dual;
public class DualCnstPrntDualGrndDual
  : DualRefCnstPrntDualGrndDual
  , ICnstPrntDualGrndDual
{
}
public class DualRefCnstPrntDualGrndDual<Tref>
  : Dualref
  , IRefCnstPrntDualGrndDual<Tref>
{
}
public class DualGrndCnstPrntDualGrndDual
  : IGrndCnstPrntDualGrndDual
{
  public String AsString { get; set; }
}
public class DualPrntCnstPrntDualGrndDual
  : DualGrndCnstPrntDualGrndDual
  , IPrntCnstPrntDualGrndDual
{
}
public class DualAltCnstPrntDualGrndDual
  : DualPrntCnstPrntDualGrndDual
  , IAltCnstPrntDualGrndDual
{
  public Number alt { get; set; }
}
