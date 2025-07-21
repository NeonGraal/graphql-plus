//HintName: Gqlp_generic-field-param+Input_Intf.gen.cs
// Generated from generic-field-param+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_field_param_Input;

public interface IGnrcFieldParamInp
{
  RefGnrcFieldParamInp<AltGnrcFieldParamInp> field { get; }
}

public interface IRefGnrcFieldParamInp<Tref>
{
  Tref Asref { get; }
}

public interface IAltGnrcFieldParamInp
{
  Number alt { get; }
  String AsString { get; }
}
