﻿//HintName: test_generic-alt-arg+Input_Impl.gen.cs
// Generated from generic-alt-arg+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Input;

public class InputtestGnrcAltArgInp<Ttype>
  : ItestGnrcAltArgInp<Ttype>
{
  public RefGnrcAltArgInp<Ttype> AsRefGnrcAltArgInp { get; set; }
}

public class InputtestRefGnrcAltArgInp<Tref>
  : ItestRefGnrcAltArgInp<Tref>
{
  public Tref Asref { get; set; }
}
