//HintName: Model_object-constraint+Dual.gen.cs
// Generated from object-constraint+Dual.graphql+

/*
*/

namespace GqlTest.Model_object_constraint_Dual;

public interface IObjCnstDual<Ttype>
{
  Ttype field { get; }
  Ttype str { get; }
}
public class DualObjCnstDual<Ttype>
  : IObjCnstDual<Ttype>
{
  public Ttype field { get; set; }
  public Ttype str { get; set; }
}
