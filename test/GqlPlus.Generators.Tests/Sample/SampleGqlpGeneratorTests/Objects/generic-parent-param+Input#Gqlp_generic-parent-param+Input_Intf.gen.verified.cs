//HintName: Gqlp_generic-parent-param+Input_Intf.gen.cs
// Generated from generic-parent-param+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_param_Input;

public interface IGnrcPrntParamInp
  : IRefGnrcPrntParamInp
{
}

public interface IRefGnrcPrntParamInp<Tref>
{
  Tref Asref { get; }
}

public interface IAltGnrcPrntParamInp
{
  Number alt { get; }
  String AsString { get; }
}
