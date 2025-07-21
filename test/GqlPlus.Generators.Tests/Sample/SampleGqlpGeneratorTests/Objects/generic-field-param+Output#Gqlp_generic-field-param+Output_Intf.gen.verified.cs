//HintName: Gqlp_generic-field-param+Output_Intf.gen.cs
// Generated from generic-field-param+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_field_param_Output;

public interface IGnrcFieldParamOutp
{
  RefGnrcFieldParamOutp<AltGnrcFieldParamOutp> field { get; }
}

public interface IRefGnrcFieldParamOutp<Tref>
{
  Tref Asref { get; }
}

public interface IAltGnrcFieldParamOutp
{
  Number alt { get; }
  String AsString { get; }
}
