//HintName: Model_generic-alt-arg-descr+input.gen.cs
// Generated from generic-alt-arg-descr+input.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_arg_descr_input;

public interface IInpGnrcAltArgDescr<Ttype>
{
  RefInpGnrcAltArgDescr AsRefInpGnrcAltArgDescr { get; }
}
public class InputInpGnrcAltArgDescr<Ttype>
  : IInpGnrcAltArgDescr<Ttype>
{
  public RefInpGnrcAltArgDescr AsRefInpGnrcAltArgDescr { get; set; }
}

public interface IRefInpGnrcAltArgDescr<Tref>
{
  Tref Asref { get; }
}
public class InputRefInpGnrcAltArgDescr<Tref>
  : IRefInpGnrcAltArgDescr<Tref>
{
  public Tref Asref { get; set; }
}
