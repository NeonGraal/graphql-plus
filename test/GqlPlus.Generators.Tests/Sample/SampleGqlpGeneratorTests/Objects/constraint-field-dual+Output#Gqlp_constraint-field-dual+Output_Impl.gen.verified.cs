//HintName: Gqlp_constraint-field-dual+Output_Impl.gen.cs
// Generated from constraint-field-dual+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_field_dual_Output;
public class OutputCnstFieldDualOutp
  : OutputRefCnstFieldDualOutp
  , ICnstFieldDualOutp
{
}
public class OutputRefCnstFieldDualOutp<Tref>
  : IRefCnstFieldDualOutp<Tref>
{
  public Tref field { get; set; }
}
public class DualPrntCnstFieldDualOutp
  : IPrntCnstFieldDualOutp
{
  public String AsString { get; set; }
}
public class OutputAltCnstFieldDualOutp
  : OutputPrntCnstFieldDualOutp
  , IAltCnstFieldDualOutp
{
  public Number alt { get; set; }
}
