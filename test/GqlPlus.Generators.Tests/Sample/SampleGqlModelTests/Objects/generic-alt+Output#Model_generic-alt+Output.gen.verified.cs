//HintName: Model_generic-alt+Output.gen.cs
// Generated from generic-alt+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_Output;

public interface IGnrcAltOutp<Ttype>
{
  Ttype Astype { get; }
}
public class OutputGnrcAltOutp<Ttype>
  : IGnrcAltOutp<Ttype>
{
  public Ttype Astype { get; set; }
}
