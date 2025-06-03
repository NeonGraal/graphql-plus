//HintName: Model_generic-alt+Input.gen.cs
// Generated from generic-alt+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_Input;

public interface IInpGnrcAlt<Ttype>
{
  Ttype Astype { get; }
}
public class InputInpGnrcAlt<Ttype>
  : IInpGnrcAlt<Ttype>
{
  public Ttype Astype { get; set; }
}
