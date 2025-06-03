//HintName: Model_generic-field+Output.gen.cs
// Generated from generic-field+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_field_Output;

public interface IOutpGnrcField<Ttype>
{
  Ttype field { get; }
}
public class OutputOutpGnrcField<Ttype>
  : IOutpGnrcField<Ttype>
{
  public Ttype field { get; set; }
}
