//HintName: Model_generic-descr+Input.gen.cs
// Generated from generic-descr+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_descr_Input;

public interface IGnrcDescrInp<Ttype>
{
  Ttype field { get; }
}
public class InputGnrcDescrInp<Ttype>
  : IGnrcDescrInp<Ttype>
{
  public Ttype field { get; set; }
}
