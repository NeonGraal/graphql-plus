//HintName: Model_constraint-alt+Input.gen.cs
// Generated from constraint-alt+Input.graphql+

/*
*/

namespace GqlTest.Model_constraint_alt_Input;

public interface ICnstAltInp<Ttype>
{
  Ttype Astype { get; }
}
public class InputCnstAltInp<Ttype>
  : ICnstAltInp<Ttype>
{
  public Ttype Astype { get; set; }
}
