//HintName: Model_generic-descr+Output.gen.cs
// Generated from generic-descr+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_descr_Output;

public interface IGnrcDescrOutp<Ttype>
{
  Ttype field { get; }
}
public class OutputGnrcDescrOutp<Ttype>
  : IGnrcDescrOutp<Ttype>
{
  public Ttype field { get; set; }
}
