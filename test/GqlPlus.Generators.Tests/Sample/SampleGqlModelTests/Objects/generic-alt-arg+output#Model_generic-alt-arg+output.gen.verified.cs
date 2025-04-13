//HintName: Model_generic-alt-arg+output.gen.cs
// Generated from generic-alt-arg+output.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_arg_output;

public interface IOutpGnrcAltArg<Ttype>
{
  RefOutpGnrcAltArg AsRefOutpGnrcAltArg { get; }
}
public class OutputOutpGnrcAltArg<Ttype>
  : IOutpGnrcAltArg<Ttype>
{
  public RefOutpGnrcAltArg AsRefOutpGnrcAltArg { get; set; }
}

public interface IRefOutpGnrcAltArg<Tref>
{
  Tref Asref { get; }
}
public class OutputRefOutpGnrcAltArg<Tref>
  : IRefOutpGnrcAltArg<Tref>
{
  public Tref Asref { get; set; }
}
