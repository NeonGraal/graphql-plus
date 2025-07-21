//HintName: Gqlp_generic-field-dual+Output_Intf.gen.cs
// Generated from generic-field-dual+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_field_dual_Output;

public interface IGnrcFieldDualOutp
{
  RefGnrcFieldDualOutp<AltGnrcFieldDualOutp> field { get; }
}

public interface IRefGnrcFieldDualOutp<Tref>
{
  Tref Asref { get; }
}

public interface IAltGnrcFieldDualOutp
{
  Number alt { get; }
  String AsString { get; }
}
