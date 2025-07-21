//HintName: Gqlp_generic-alt-dual+Dual_Intf.gen.cs
// Generated from generic-alt-dual+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_alt_dual_Dual;

public interface IGnrcAltDualDual
{
  RefGnrcAltDualDual<AltGnrcAltDualDual> AsRefGnrcAltDualDual { get; }
}

public interface IRefGnrcAltDualDual<Tref>
{
  Tref Asref { get; }
}

public interface IAltGnrcAltDualDual
{
  Number alt { get; }
  String AsString { get; }
}
