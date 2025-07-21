//HintName: Gqlp_constraint-parent-obj-parent+Output_Impl.gen.cs
// Generated from constraint-parent-obj-parent+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_parent_obj_parent_Output;
public class OutputCnstPrntObjPrntOutp
  : OutputRefCnstPrntObjPrntOutp
  , ICnstPrntObjPrntOutp
{
}
public class OutputRefCnstPrntObjPrntOutp<Tref>
  : Outputref
  , IRefCnstPrntObjPrntOutp<Tref>
{
}
public class OutputPrntCnstPrntObjPrntOutp
  : IPrntCnstPrntObjPrntOutp
{
  public String AsString { get; set; }
}
public class OutputAltCnstPrntObjPrntOutp
  : OutputPrntCnstPrntObjPrntOutp
  , IAltCnstPrntObjPrntOutp
{
  public Number alt { get; set; }
}
