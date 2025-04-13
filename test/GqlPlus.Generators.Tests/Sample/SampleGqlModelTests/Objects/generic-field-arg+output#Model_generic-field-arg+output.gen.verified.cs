//HintName: Model_generic-field-arg+output.gen.cs
// Generated from generic-field-arg+output.graphql+

/*
*/

namespace GqlTest.Model_generic_field_arg_output;

public interface IOutpGnrcFieldArg<Ttype>
{
  RefOutpGnrcFieldArg field { get; }
}
public class OutputOutpGnrcFieldArg<Ttype>
  : IOutpGnrcFieldArg<Ttype>
{
  public RefOutpGnrcFieldArg field { get; set; }
}

public interface IRefOutpGnrcFieldArg<Tref>
{
  Tref Asref { get; }
}
public class OutputRefOutpGnrcFieldArg<Tref>
  : IRefOutpGnrcFieldArg<Tref>
{
  public Tref Asref { get; set; }
}
