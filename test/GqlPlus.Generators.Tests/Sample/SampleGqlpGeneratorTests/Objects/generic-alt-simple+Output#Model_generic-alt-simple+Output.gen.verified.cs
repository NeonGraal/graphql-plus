//HintName: Model_generic-alt-simple+Output.gen.cs
// Generated from generic-alt-simple+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_generic_alt_simple_Output;

public interface IGnrcAltSmplOutp
{
  RefGnrcAltSmplOutp<String> AsRefGnrcAltSmplOutp { get; }
}
public class OutputGnrcAltSmplOutp
  : IGnrcAltSmplOutp
{
  public RefGnrcAltSmplOutp<String> AsRefGnrcAltSmplOutp { get; set; }
}

public interface IRefGnrcAltSmplOutp<Tref>
{
  Tref Asref { get; }
}
public class OutputRefGnrcAltSmplOutp<Tref>
  : IRefGnrcAltSmplOutp<Tref>
{
  public Tref Asref { get; set; }
}
