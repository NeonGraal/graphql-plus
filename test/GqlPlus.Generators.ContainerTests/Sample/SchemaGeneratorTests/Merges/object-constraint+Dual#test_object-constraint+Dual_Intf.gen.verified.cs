//HintName: test_object-constraint+Dual_Intf.gen.cs
// Generated from object-constraint+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_constraint_Dual;

public interface ItestObjCnstDual<Ttype>
{
  ItestObjCnstDualObject AsObjCnstDual { get; }
}

public interface ItestObjCnstDualObject<Ttype>
{
  Ttype Field { get; }
  Ttype Str { get; }
}
