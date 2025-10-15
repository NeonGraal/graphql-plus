//HintName: test_generic-field-param+Dual_Intf.gen.cs
// Generated from generic-field-param+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Dual;

public interface ItestGnrcFieldParamDual
{
  RefGnrcFieldParamDual<AltGnrcFieldParamDual> field { get; }
}

public interface ItestRefGnrcFieldParamDual<Tref>
{
  Tref Asref { get; }
}

public interface ItestAltGnrcFieldParamDual
{
  Number alt { get; }
  String AsString { get; }
}
