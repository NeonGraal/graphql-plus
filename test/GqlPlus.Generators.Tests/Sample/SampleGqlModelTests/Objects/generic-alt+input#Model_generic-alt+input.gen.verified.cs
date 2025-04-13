//HintName: Model_generic-alt+input.gen.cs
// Generated from generic-alt+input.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_input;

public interface IInpGnrcAlt<Ttype>
{
  Ttype Astype { get; }
}
public class InputInpGnrcAlt<Ttype>
  : IInpGnrcAlt<Ttype>
{
  public Ttype Astype { get; set; }
}
