//HintName: Model_generic-alt-arg+Output.gen.cs
// Generated from generic-alt-arg+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_arg_Output;

public interface IOutpGnrcAltArg<Ttype>
{
  RefOutpGnrcAltArg<Ttype> AsRefOutpGnrcAltArg { get; }
}
public class OutputOutpGnrcAltArg<Ttype>
  : IOutpGnrcAltArg<Ttype>
{
  public RefOutpGnrcAltArg<Ttype> AsRefOutpGnrcAltArg { get; set; }
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
