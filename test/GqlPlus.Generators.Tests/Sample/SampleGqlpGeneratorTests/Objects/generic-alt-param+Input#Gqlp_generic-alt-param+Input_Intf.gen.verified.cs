//HintName: Gqlp_generic-alt-param+Input_Intf.gen.cs
// Generated from generic-alt-param+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_alt_param_Input;

public interface IGnrcAltParamInp
{
  RefGnrcAltParamInp<AltGnrcAltParamInp> AsRefGnrcAltParamInp { get; }
}

public interface IRefGnrcAltParamInp<Tref>
{
  Tref Asref { get; }
}

public interface IAltGnrcAltParamInp
{
  Number alt { get; }
  String AsString { get; }
}
