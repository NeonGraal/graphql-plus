//HintName: Model_generic-alt-dual+Output.gen.cs
// Generated from generic-alt-dual+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_generic_alt_dual_Output;

public interface IGnrcAltDualOutp
{
  RefGnrcAltDualOutp<AltGnrcAltDualOutp> AsRefGnrcAltDualOutp { get; }
}
public class OutputGnrcAltDualOutp
  : IGnrcAltDualOutp
{
  public RefGnrcAltDualOutp<AltGnrcAltDualOutp> AsRefGnrcAltDualOutp { get; set; }
}

public interface IRefGnrcAltDualOutp<Tref>
{
  Tref Asref { get; }
}
public class OutputRefGnrcAltDualOutp<Tref>
  : IRefGnrcAltDualOutp<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltGnrcAltDualOutp
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltGnrcAltDualOutp
  : IAltGnrcAltDualOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
