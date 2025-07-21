//HintName: Gqlp_generic-alt-dual+Output_Intf.gen.cs
// Generated from generic-alt-dual+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_alt_dual_Output;

public interface IGnrcAltDualOutp
{
  RefGnrcAltDualOutp<AltGnrcAltDualOutp> AsRefGnrcAltDualOutp { get; }
}

public interface IRefGnrcAltDualOutp<Tref>
{
  Tref Asref { get; }
}

public interface IAltGnrcAltDualOutp
{
  Number alt { get; }
  String AsString { get; }
}
