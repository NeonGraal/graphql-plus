﻿//HintName: test_constraint-enum+Dual_Impl.gen.cs
// Generated from constraint-enum+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Dual;

public class testCnstEnumDual
  : ItestCnstEnumDual
{
  public RefCnstEnumDual<EnumCnstEnumDual> AsRefCnstEnumDual { get; set; }
}

public class testRefCnstEnumDual<Ttype>
  : ItestRefCnstEnumDual<Ttype>
{
  public Ttype field { get; set; }
}
