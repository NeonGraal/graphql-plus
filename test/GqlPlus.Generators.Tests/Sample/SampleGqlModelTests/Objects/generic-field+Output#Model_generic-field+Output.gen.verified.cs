//HintName: Model_generic-field+Output.gen.cs
// Generated from generic-field+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_field_Output;

public interface IGnrcFieldOutp<Ttype>
{
  Ttype field { get; }
}
public class OutputGnrcFieldOutp<Ttype>
  : IGnrcFieldOutp<Ttype>
{
  public Ttype field { get; set; }
}
