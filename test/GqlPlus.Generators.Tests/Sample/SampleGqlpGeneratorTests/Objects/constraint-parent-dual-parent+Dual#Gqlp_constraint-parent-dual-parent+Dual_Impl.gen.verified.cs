//HintName: Gqlp_constraint-parent-dual-parent+Dual_Impl.gen.cs
// Generated from constraint-parent-dual-parent+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_parent_dual_parent_Dual;
public class DualCnstPrntDualPrntDual
  : DualRefCnstPrntDualPrntDual
  , ICnstPrntDualPrntDual
{
}
public class DualRefCnstPrntDualPrntDual<Tref>
  : Dualref
  , IRefCnstPrntDualPrntDual<Tref>
{
}
public class DualPrntCnstPrntDualPrntDual
  : IPrntCnstPrntDualPrntDual
{
  public String AsString { get; set; }
}
public class DualAltCnstPrntDualPrntDual
  : DualPrntCnstPrntDualPrntDual
  , IAltCnstPrntDualPrntDual
{
  public Number alt { get; set; }
}
