//HintName: Model_generic-field-arg+Input.gen.cs
// Generated from generic-field-arg+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_field_arg_Input;

public interface IInpGnrcFieldArg<Ttype>
{
  RefInpGnrcFieldArg<Ttype> field { get; }
}
public class InputInpGnrcFieldArg<Ttype>
  : IInpGnrcFieldArg<Ttype>
{
  public RefInpGnrcFieldArg<Ttype> field { get; set; }
}

public interface IRefInpGnrcFieldArg<Tref>
{
  Tref Asref { get; }
}
public class InputRefInpGnrcFieldArg<Tref>
  : IRefInpGnrcFieldArg<Tref>
{
  public Tref Asref { get; set; }
}
