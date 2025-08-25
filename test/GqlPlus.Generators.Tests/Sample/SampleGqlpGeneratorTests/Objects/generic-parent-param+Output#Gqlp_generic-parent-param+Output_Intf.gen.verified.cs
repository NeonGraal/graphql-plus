//HintName: Gqlp_generic-parent-param+Output_Intf.gen.cs
// Generated from generic-parent-param+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_param_Output;

public interface IGnrcPrntParamOutp
  : IRefGnrcPrntParamOutp
{
}

public interface IRefGnrcPrntParamOutp<Tref>
{
  Tref Asref { get; }
}

public interface IAltGnrcPrntParamOutp
{
  Number alt { get; }
  String AsString { get; }
}
