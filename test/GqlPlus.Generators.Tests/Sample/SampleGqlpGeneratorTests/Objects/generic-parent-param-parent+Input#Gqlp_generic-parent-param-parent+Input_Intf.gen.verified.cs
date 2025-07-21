//HintName: Gqlp_generic-parent-param-parent+Input_Intf.gen.cs
// Generated from generic-parent-param-parent+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_param_parent_Input;

public interface IGnrcPrntParamPrntInp
  : IRefGnrcPrntParamPrntInp
{
}

public interface IRefGnrcPrntParamPrntInp<Tref>
  : Iref
{
}

public interface IAltGnrcPrntParamPrntInp
{
  Number alt { get; }
  String AsString { get; }
}
