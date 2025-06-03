//HintName: Model_generic-alt-arg+Output.gen.cs
// Generated from generic-alt-arg+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_arg_Output;

public interface IGnrcAltArgOutp<Ttype>
{
  RefGnrcAltArgOutp<Ttype> AsRefGnrcAltArgOutp { get; }
}
public class OutputGnrcAltArgOutp<Ttype>
  : IGnrcAltArgOutp<Ttype>
{
  public RefGnrcAltArgOutp<Ttype> AsRefGnrcAltArgOutp { get; set; }
}

public interface IRefGnrcAltArgOutp<Tref>
{
  Tref Asref { get; }
}
public class OutputRefGnrcAltArgOutp<Tref>
  : IRefGnrcAltArgOutp<Tref>
{
  public Tref Asref { get; set; }
}
