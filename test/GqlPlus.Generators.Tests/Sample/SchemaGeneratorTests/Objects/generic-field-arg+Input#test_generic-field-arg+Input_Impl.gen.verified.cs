﻿//HintName: test_generic-field-arg+Input_Impl.gen.cs
// Generated from generic-field-arg+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Input;

public class InputtestGnrcFieldArgInp<Ttype>
  : ItestGnrcFieldArgInp<Ttype>
{
  public RefGnrcFieldArgInp<Ttype> field { get; set; }
}

public class InputtestRefGnrcFieldArgInp<Tref>
  : ItestRefGnrcFieldArgInp<Tref>
{
  public Tref Asref { get; set; }
}
