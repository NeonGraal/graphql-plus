﻿//HintName: test_generic-field-arg+Dual_Intf.gen.cs
// Generated from generic-field-arg+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Dual;

public interface ItestGnrcFieldArgDual<Ttype>
{
  RefGnrcFieldArgDual<Ttype> field { get; }
}

public interface ItestRefGnrcFieldArgDual<Tref>
{
  Tref Asref { get; }
}
