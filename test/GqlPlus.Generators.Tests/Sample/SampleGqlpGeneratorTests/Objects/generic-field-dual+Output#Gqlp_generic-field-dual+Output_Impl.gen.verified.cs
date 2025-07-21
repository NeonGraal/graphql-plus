//HintName: Gqlp_generic-field-dual+Output_Impl.gen.cs
// Generated from generic-field-dual+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_field_dual_Output;
public class OutputGnrcFieldDualOutp
  : IGnrcFieldDualOutp
{
  public RefGnrcFieldDualOutp<AltGnrcFieldDualOutp> field { get; set; }
}
public class OutputRefGnrcFieldDualOutp<Tref>
  : IRefGnrcFieldDualOutp<Tref>
{
  public Tref Asref { get; set; }
}
public class DualAltGnrcFieldDualOutp
  : IAltGnrcFieldDualOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
