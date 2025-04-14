//HintName: Model_generic-alt-simple+output.gen.cs
// Generated from generic-alt-simple+output.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_simple_output;

public interface IOutpGnrcAltSmpl
{
  RefOutpGnrcAltSmpl<String> AsRefOutpGnrcAltSmpl { get; }
}
public class OutputOutpGnrcAltSmpl
  : IOutpGnrcAltSmpl
{
  public RefOutpGnrcAltSmpl<String> AsRefOutpGnrcAltSmpl { get; set; }
}

public interface IRefOutpGnrcAltSmpl<Tref>
{
  Tref Asref { get; }
}
public class OutputRefOutpGnrcAltSmpl<Tref>
  : IRefOutpGnrcAltSmpl<Tref>
{
  public Tref Asref { get; set; }
}
