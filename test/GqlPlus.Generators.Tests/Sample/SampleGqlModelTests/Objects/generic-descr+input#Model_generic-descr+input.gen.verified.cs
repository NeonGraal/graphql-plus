//HintName: Model_generic-descr+input.gen.cs
// Generated from generic-descr+input.graphql+

/*
*/

namespace GqlTest.Model_generic_descr_input;

public interface IInpGnrcDescr<Ttype>
{
  Ttype field { get; }
}
public class InputInpGnrcDescr<Ttype>
  : IInpGnrcDescr<Ttype>
{
  public Ttype field { get; set; }
}
