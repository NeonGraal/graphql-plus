//HintName: Model_generic-alt+Dual.gen.cs
// Generated from generic-alt+Dual.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_Dual;

public interface IGnrcAltDual<Ttype>
{
  Ttype Astype { get; }
}
public class DualGnrcAltDual<Ttype>
  : IGnrcAltDual<Ttype>
{
  public Ttype Astype { get; set; }
}
