//HintName: Model_generic-alt+Input.gen.cs
// Generated from generic-alt+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_Input;

public interface IGnrcAltInp<Ttype>
{
  Ttype Astype { get; }
}
public class InputGnrcAltInp<Ttype>
  : IGnrcAltInp<Ttype>
{
  public Ttype Astype { get; set; }
}
