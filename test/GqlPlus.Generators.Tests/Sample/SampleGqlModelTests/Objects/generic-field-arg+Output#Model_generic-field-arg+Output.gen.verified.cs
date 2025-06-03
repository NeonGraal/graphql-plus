//HintName: Model_generic-field-arg+Output.gen.cs
// Generated from generic-field-arg+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_field_arg_Output;

public interface IOutpGnrcFieldArg<Ttype>
{
  RefOutpGnrcFieldArg<Ttype> field { get; }
}
public class OutputOutpGnrcFieldArg<Ttype>
  : IOutpGnrcFieldArg<Ttype>
{
  public RefOutpGnrcFieldArg<Ttype> field { get; set; }
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
