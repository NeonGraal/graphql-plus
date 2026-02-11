//HintName: test_object-constraint+Dual_Intf.gen.cs
// Generated from object-constraint+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_constraint_Dual;

public interface ItestObjCnstDual<TType>
{
  ItestObjCnstDualObject AsObjCnstDual { get; }
}

public interface ItestObjCnstDualObject<TType>
{
  TType Field { get; }
  TType Str { get; }
}
