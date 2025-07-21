//HintName: Gqlp_constraint-parent-dual-grandparent+Output_Impl.gen.cs
// Generated from constraint-parent-dual-grandparent+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_parent_dual_grandparent_Output;
public class OutputCnstPrntDualGrndOutp
  : OutputRefCnstPrntDualGrndOutp
  , ICnstPrntDualGrndOutp
{
}
public class OutputRefCnstPrntDualGrndOutp<Tref>
  : Outputref
  , IRefCnstPrntDualGrndOutp<Tref>
{
}
public class DualGrndCnstPrntDualGrndOutp
  : IGrndCnstPrntDualGrndOutp
{
  public String AsString { get; set; }
}
public class DualPrntCnstPrntDualGrndOutp
  : DualGrndCnstPrntDualGrndOutp
  , IPrntCnstPrntDualGrndOutp
{
}
public class OutputAltCnstPrntDualGrndOutp
  : OutputPrntCnstPrntDualGrndOutp
  , IAltCnstPrntDualGrndOutp
{
  public Number alt { get; set; }
}
