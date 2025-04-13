//HintName: Model_generic-descr+output.gen.cs
// Generated from generic-descr+output.graphql+

/*
*/

namespace GqlTest.Model_generic_descr_output;

public interface IOutpGnrcDescr<Ttype>
{
  Ttype field { get; }
}
public class OutputOutpGnrcDescr<Ttype>
  : IOutpGnrcDescr<Ttype>
{
  public Ttype field { get; set; }
}
