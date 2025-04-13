//HintName: Model_generic-alt-arg-descr+output.gen.cs
// Generated from generic-alt-arg-descr+output.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_arg_descr_output;

public interface IOutpGnrcAltArgDescr<Ttype>
{
  RefOutpGnrcAltArgDescr AsRefOutpGnrcAltArgDescr { get; }
}
public class OutputOutpGnrcAltArgDescr<Ttype>
  : IOutpGnrcAltArgDescr<Ttype>
{
  public RefOutpGnrcAltArgDescr AsRefOutpGnrcAltArgDescr { get; set; }
}

public interface IRefOutpGnrcAltArgDescr<Tref>
{
  Tref Asref { get; }
}
public class OutputRefOutpGnrcAltArgDescr<Tref>
  : IRefOutpGnrcAltArgDescr<Tref>
{
  public Tref Asref { get; set; }
}
