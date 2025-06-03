//HintName: Model_generic-alt-arg+Input.gen.cs
// Generated from generic-alt-arg+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_arg_Input;

public interface IGnrcAltArgInp<Ttype>
{
  RefGnrcAltArgInp<Ttype> AsRefGnrcAltArgInp { get; }
}
public class InputGnrcAltArgInp<Ttype>
  : IGnrcAltArgInp<Ttype>
{
  public RefGnrcAltArgInp<Ttype> AsRefGnrcAltArgInp { get; set; }
}

public interface IRefGnrcAltArgInp<Tref>
{
  Tref Asref { get; }
}
public class InputRefGnrcAltArgInp<Tref>
  : IRefGnrcAltArgInp<Tref>
{
  public Tref Asref { get; set; }
}
