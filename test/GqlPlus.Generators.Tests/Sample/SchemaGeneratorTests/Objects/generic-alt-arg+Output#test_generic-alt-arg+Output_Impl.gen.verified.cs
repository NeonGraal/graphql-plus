﻿//HintName: test_generic-alt-arg+Output_Impl.gen.cs
// Generated from generic-alt-arg+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Output;

public class testGnrcAltArgOutp<Ttype>
  : ItestGnrcAltArgOutp<Ttype>
{
  public RefGnrcAltArgOutp<Ttype> AsRefGnrcAltArgOutp { get; set; }
}

public class testRefGnrcAltArgOutp<Tref>
  : ItestRefGnrcAltArgOutp<Tref>
{
  public Tref Asref { get; set; }
}
