//HintName: Model_generic-field+output.gen.cs
// Generated from generic-field+output.graphql+

/*
*/

namespace GqlTest.Model_generic_field_output;

public interface IOutpGnrcField<Ttype>
{
  Ttype field { get; }
}
public class OutputOutpGnrcField<Ttype>
  : IOutpGnrcField<Ttype>
{
  public Ttype field { get; set; }
}
