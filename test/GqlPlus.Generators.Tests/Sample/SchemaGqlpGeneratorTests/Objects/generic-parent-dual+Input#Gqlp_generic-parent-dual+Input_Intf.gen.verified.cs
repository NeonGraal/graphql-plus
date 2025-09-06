//HintName: Gqlp_generic-parent-dual+Input_Intf.gen.cs
// Generated from generic-parent-dual+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_dual_Input;

public interface IGnrcPrntDualInp
  : IRefGnrcPrntDualInp
{
}

public interface IRefGnrcPrntDualInp<Tref>
{
  Tref Asref { get; }
}

public interface IAltGnrcPrntDualInp
{
  Number alt { get; }
  String AsString { get; }
}
