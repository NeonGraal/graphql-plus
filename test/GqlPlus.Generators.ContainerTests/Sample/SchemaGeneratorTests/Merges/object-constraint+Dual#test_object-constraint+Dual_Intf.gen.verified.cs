//HintName: test_object-constraint+Dual_Intf.gen.cs
// Generated from object-constraint+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_constraint_Dual;

public interface ItestObjCnstDual<Ttype>
{
  public ItestObjCnstDualObject AsObjCnstDual { get; set; }
}

public interface ItestObjCnstDualObject<Ttype>
{
  public Ttype Field { get; set; }
  public Ttype Str { get; set; }
}
