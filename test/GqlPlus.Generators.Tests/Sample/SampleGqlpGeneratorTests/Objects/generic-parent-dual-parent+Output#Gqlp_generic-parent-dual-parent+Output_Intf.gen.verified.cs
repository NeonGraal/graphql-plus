//HintName: Gqlp_generic-parent-dual-parent+Output_Intf.gen.cs
// Generated from generic-parent-dual-parent+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_dual_parent_Output;

public interface IGnrcPrntDualPrntOutp
  : IRefGnrcPrntDualPrntOutp
{
}

public interface IRefGnrcPrntDualPrntOutp<Tref>
  : Iref
{
}

public interface IAltGnrcPrntDualPrntOutp
{
  Number alt { get; }
  String AsString { get; }
}
