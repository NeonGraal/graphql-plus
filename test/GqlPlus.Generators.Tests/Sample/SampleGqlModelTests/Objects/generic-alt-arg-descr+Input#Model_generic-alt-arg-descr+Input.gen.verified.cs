//HintName: Model_generic-alt-arg-descr+Input.gen.cs
// Generated from generic-alt-arg-descr+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_arg_descr_Input;

public interface IInpGnrcAltArgDescr<Ttype>
{
  RefInpGnrcAltArgDescr<Ttype> AsRefInpGnrcAltArgDescr { get; }
}
public class InputInpGnrcAltArgDescr<Ttype>
  : IInpGnrcAltArgDescr<Ttype>
{
  public RefInpGnrcAltArgDescr<Ttype> AsRefInpGnrcAltArgDescr { get; set; }
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
