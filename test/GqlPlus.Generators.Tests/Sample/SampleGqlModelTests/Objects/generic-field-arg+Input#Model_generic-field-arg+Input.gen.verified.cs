//HintName: Model_generic-field-arg+Input.gen.cs
// Generated from generic-field-arg+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_field_arg_Input;

public interface IGnrcFieldArgInp<Ttype>
{
  RefGnrcFieldArgInp<Ttype> field { get; }
}
public class InputGnrcFieldArgInp<Ttype>
  : IGnrcFieldArgInp<Ttype>
{
  public RefGnrcFieldArgInp<Ttype> field { get; set; }
}

public interface IRefGnrcFieldArgInp<Tref>
{
  Tref Asref { get; }
}
public class InputRefGnrcFieldArgInp<Tref>
  : IRefGnrcFieldArgInp<Tref>
{
  public Tref Asref { get; set; }
}
