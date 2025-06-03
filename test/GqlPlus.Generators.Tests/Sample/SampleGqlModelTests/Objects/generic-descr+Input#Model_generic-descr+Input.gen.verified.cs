//HintName: Model_generic-descr+Input.gen.cs
// Generated from generic-descr+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_descr_Input;

public interface IInpGnrcDescr<Ttype>
{
  Ttype field { get; }
}
public class InputInpGnrcDescr<Ttype>
  : IInpGnrcDescr<Ttype>
{
  public Ttype field { get; set; }
}
