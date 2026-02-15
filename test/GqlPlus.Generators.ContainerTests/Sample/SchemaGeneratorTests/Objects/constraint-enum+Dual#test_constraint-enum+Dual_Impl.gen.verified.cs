//HintName: test_constraint-enum+Dual_Impl.gen.cs
// Generated from constraint-enum+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Dual;

public class testCnstEnumDual
  : ItestCnstEnumDual
{
}

public class testRefCnstEnumDual<TType>
  : ItestRefCnstEnumDual<TType>
{
  public TType Field { get; set; }
}
