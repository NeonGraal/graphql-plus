//HintName: Gqlp_constraint-parent-dual-parent+Output_Intf.gen.cs
// Generated from constraint-parent-dual-parent+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_parent_dual_parent_Output;

public interface ICnstPrntDualPrntOutp
  : IRefCnstPrntDualPrntOutp
{
}

public interface IRefCnstPrntDualPrntOutp<Tref>
  : Iref
{
}

public interface IPrntCnstPrntDualPrntOutp
{
  String AsString { get; }
}

public interface IAltCnstPrntDualPrntOutp
  : IPrntCnstPrntDualPrntOutp
{
  Number alt { get; }
}
