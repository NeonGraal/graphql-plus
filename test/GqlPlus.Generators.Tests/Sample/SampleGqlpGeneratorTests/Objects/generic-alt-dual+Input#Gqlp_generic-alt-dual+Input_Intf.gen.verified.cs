//HintName: Gqlp_generic-alt-dual+Input_Intf.gen.cs
// Generated from generic-alt-dual+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_alt_dual_Input;

public interface IGnrcAltDualInp
{
  RefGnrcAltDualInp<AltGnrcAltDualInp> AsRefGnrcAltDualInp { get; }
}

public interface IRefGnrcAltDualInp<Tref>
{
  Tref Asref { get; }
}

public interface IAltGnrcAltDualInp
{
  Number alt { get; }
  String AsString { get; }
}
