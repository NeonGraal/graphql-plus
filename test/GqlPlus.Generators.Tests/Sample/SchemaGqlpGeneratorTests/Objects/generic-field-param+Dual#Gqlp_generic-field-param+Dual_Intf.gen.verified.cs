//HintName: Gqlp_generic-field-param+Dual_Intf.gen.cs
// Generated from generic-field-param+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_field_param_Dual;

public interface IGnrcFieldParamDual
{
  RefGnrcFieldParamDual<AltGnrcFieldParamDual> field { get; }
}

public interface IRefGnrcFieldParamDual<Tref>
{
  Tref Asref { get; }
}

public interface IAltGnrcFieldParamDual
{
  Number alt { get; }
  String AsString { get; }
}
