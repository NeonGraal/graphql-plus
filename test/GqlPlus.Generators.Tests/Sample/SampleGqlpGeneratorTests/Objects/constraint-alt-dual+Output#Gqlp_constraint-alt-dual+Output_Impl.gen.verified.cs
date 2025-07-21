//HintName: Gqlp_constraint-alt-dual+Output_Impl.gen.cs
// Generated from constraint-alt-dual+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_alt_dual_Output;
public class OutputCnstAltDualOutp
  : ICnstAltDualOutp
{
  public RefCnstAltDualOutp<AltCnstAltDualOutp> AsRefCnstAltDualOutp { get; set; }
}
public class OutputRefCnstAltDualOutp<Tref>
  : IRefCnstAltDualOutp<Tref>
{
  public Tref Asref { get; set; }
}
public class DualPrntCnstAltDualOutp
  : IPrntCnstAltDualOutp
{
  public String AsString { get; set; }
}
public class OutputAltCnstAltDualOutp
  : OutputPrntCnstAltDualOutp
  , IAltCnstAltDualOutp
{
  public Number alt { get; set; }
}
