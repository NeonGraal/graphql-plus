//HintName: Gqlp_generic-parent-param-parent+Output_Intf.gen.cs
// Generated from generic-parent-param-parent+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_param_parent_Output;

public interface IGnrcPrntParamPrntOutp
  : IRefGnrcPrntParamPrntOutp
{
}

public interface IRefGnrcPrntParamPrntOutp<Tref>
  : Iref
{
}

public interface IAltGnrcPrntParamPrntOutp
{
  Number alt { get; }
  String AsString { get; }
}
