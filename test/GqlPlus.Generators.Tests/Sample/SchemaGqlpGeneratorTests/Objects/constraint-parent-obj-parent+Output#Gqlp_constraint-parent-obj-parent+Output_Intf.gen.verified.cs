//HintName: Gqlp_constraint-parent-obj-parent+Output_Intf.gen.cs
// Generated from constraint-parent-obj-parent+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_parent_obj_parent_Output;

public interface ICnstPrntObjPrntOutp
  : IRefCnstPrntObjPrntOutp
{
}

public interface IRefCnstPrntObjPrntOutp<Tref>
  : Iref
{
}

public interface IPrntCnstPrntObjPrntOutp
{
  String AsString { get; }
}

public interface IAltCnstPrntObjPrntOutp
  : IPrntCnstPrntObjPrntOutp
{
  Number alt { get; }
}
