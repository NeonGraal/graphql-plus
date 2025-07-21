//HintName: Gqlp_generic-parent-dual+Output_Intf.gen.cs
// Generated from generic-parent-dual+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_dual_Output;

public interface IGnrcPrntDualOutp
  : IRefGnrcPrntDualOutp
{
}

public interface IRefGnrcPrntDualOutp<Tref>
{
  Tref Asref { get; }
}

public interface IAltGnrcPrntDualOutp
{
  Number alt { get; }
  String AsString { get; }
}
