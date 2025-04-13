//HintName: Model_generic-field+input.gen.cs
// Generated from generic-field+input.graphql+

/*
*/

namespace GqlTest.Model_generic_field_input;

public interface IInpGnrcField<Ttype>
{
  Ttype field { get; }
}
public class InputInpGnrcField<Ttype>
  : IInpGnrcField<Ttype>
{
  public Ttype field { get; set; }
}
