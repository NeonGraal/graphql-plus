//HintName: Model_generic-alt-arg-descr+Output.gen.cs
// Generated from generic-alt-arg-descr+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_arg_descr_Output;

public interface IOutpGnrcAltArgDescr<Ttype>
{
  RefOutpGnrcAltArgDescr<Ttype> AsRefOutpGnrcAltArgDescr { get; }
}
public class OutputOutpGnrcAltArgDescr<Ttype>
  : IOutpGnrcAltArgDescr<Ttype>
{
  public RefOutpGnrcAltArgDescr<Ttype> AsRefOutpGnrcAltArgDescr { get; set; }
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
