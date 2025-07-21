//HintName: Gqlp_generic-alt-param+Dual_Intf.gen.cs
// Generated from generic-alt-param+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_alt_param_Dual;

public interface IGnrcAltParamDual
{
  RefGnrcAltParamDual<AltGnrcAltParamDual> AsRefGnrcAltParamDual { get; }
}

public interface IRefGnrcAltParamDual<Tref>
{
  Tref Asref { get; }
}

public interface IAltGnrcAltParamDual
{
  Number alt { get; }
  String AsString { get; }
}
