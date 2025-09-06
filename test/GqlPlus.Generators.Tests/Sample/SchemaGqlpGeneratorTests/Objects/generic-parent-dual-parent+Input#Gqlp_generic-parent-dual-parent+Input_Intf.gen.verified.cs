//HintName: Gqlp_generic-parent-dual-parent+Input_Intf.gen.cs
// Generated from generic-parent-dual-parent+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_dual_parent_Input;

public interface IGnrcPrntDualPrntInp
  : IRefGnrcPrntDualPrntInp
{
}

public interface IRefGnrcPrntDualPrntInp<Tref>
  : Iref
{
}

public interface IAltGnrcPrntDualPrntInp
{
  Number alt { get; }
  String AsString { get; }
}
