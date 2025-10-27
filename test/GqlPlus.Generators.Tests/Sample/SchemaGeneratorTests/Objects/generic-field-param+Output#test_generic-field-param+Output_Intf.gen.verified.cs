//HintName: test_generic-field-param+Output_Intf.gen.cs
// Generated from generic-field-param+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Output;

public interface ItestGnrcFieldParamOutp
{
  RefGnrcFieldParamOutp<AltGnrcFieldParamOutp> field { get; }
}

public interface ItestRefGnrcFieldParamOutp<Tref>
{
  Tref Asref { get; }
}

public interface ItestAltGnrcFieldParamOutp
{
  Number alt { get; }
  String AsString { get; }
}
