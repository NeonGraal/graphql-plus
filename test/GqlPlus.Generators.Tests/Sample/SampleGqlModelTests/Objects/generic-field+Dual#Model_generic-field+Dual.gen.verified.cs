//HintName: Model_generic-field+Dual.gen.cs
// Generated from generic-field+Dual.graphql+

/*
*/

namespace GqlTest.Model_generic_field_Dual;

public interface IGnrcFieldDual<Ttype>
{
  Ttype field { get; }
}
public class DualGnrcFieldDual<Ttype>
  : IGnrcFieldDual<Ttype>
{
  public Ttype field { get; set; }
}
