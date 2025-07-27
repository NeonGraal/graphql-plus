//HintName: Gqlp_constraint-parent-dual-parent+Output_Impl.gen.cs
// Generated from constraint-parent-dual-parent+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_parent_dual_parent_Output;

public class OutputCnstPrntDualPrntOutp
  : OutputRefCnstPrntDualPrntOutp
  , ICnstPrntDualPrntOutp
{
}

public class OutputRefCnstPrntDualPrntOutp<Tref>
  : Outputref
  , IRefCnstPrntDualPrntOutp<Tref>
{
}

public class DualPrntCnstPrntDualPrntOutp
  : IPrntCnstPrntDualPrntOutp
{
  public String AsString { get; set; }
}

public class OutputAltCnstPrntDualPrntOutp
  : OutputPrntCnstPrntDualPrntOutp
  , IAltCnstPrntDualPrntOutp
{
  public Number alt { get; set; }
}
