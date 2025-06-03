//HintName: Model_generic-field-arg+Output.gen.cs
// Generated from generic-field-arg+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_field_arg_Output;

public interface IGnrcFieldArgOutp<Ttype>
{
  RefGnrcFieldArgOutp<Ttype> field { get; }
}
public class OutputGnrcFieldArgOutp<Ttype>
  : IGnrcFieldArgOutp<Ttype>
{
  public RefGnrcFieldArgOutp<Ttype> field { get; set; }
}

public interface IRefGnrcFieldArgOutp<Tref>
{
  Tref Asref { get; }
}
public class OutputRefGnrcFieldArgOutp<Tref>
  : IRefGnrcFieldArgOutp<Tref>
{
  public Tref Asref { get; set; }
}
