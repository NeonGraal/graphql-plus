//HintName: Model_generic-field-arg+input.gen.cs
// Generated from generic-field-arg+input.graphql+

/*
*/

namespace GqlTest.Model_generic_field_arg_input;

public interface IInpGnrcFieldArg<Ttype>
{
  RefInpGnrcFieldArg field { get; }
}
public class InputInpGnrcFieldArg<Ttype>
  : IInpGnrcFieldArg<Ttype>
{
  public RefInpGnrcFieldArg field { get; set; }
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
