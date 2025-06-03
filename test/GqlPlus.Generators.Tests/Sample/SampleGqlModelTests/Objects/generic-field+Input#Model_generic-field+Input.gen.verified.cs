//HintName: Model_generic-field+Input.gen.cs
// Generated from generic-field+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_field_Input;

public interface IInpGnrcField<Ttype>
{
  Ttype field { get; }
}
public class InputInpGnrcField<Ttype>
  : IInpGnrcField<Ttype>
{
  public Ttype field { get; set; }
}
