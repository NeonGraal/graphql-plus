﻿//HintName: test_constraint-parent-enum+Dual_Impl.gen.cs
// Generated from constraint-parent-enum+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Dual;

public class testCnstPrntEnumDual
  : ItestCnstPrntEnumDual
{
  public RefCnstPrntEnumDual<ParentCnstPrntEnumDual> AsRefCnstPrntEnumDual { get; set; }
}

public class testRefCnstPrntEnumDual<Ttype>
  : ItestRefCnstPrntEnumDual<Ttype>
{
  public Ttype field { get; set; }
}
