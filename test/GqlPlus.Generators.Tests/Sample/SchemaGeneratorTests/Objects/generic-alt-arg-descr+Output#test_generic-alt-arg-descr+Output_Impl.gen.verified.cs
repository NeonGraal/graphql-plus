﻿//HintName: test_generic-alt-arg-descr+Output_Impl.gen.cs
// Generated from generic-alt-arg-descr+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Output;

public class testGnrcAltArgDescrOutp<Ttype>
  : ItestGnrcAltArgDescrOutp<Ttype>
{
  public RefGnrcAltArgDescrOutp<Ttype> AsRefGnrcAltArgDescrOutp { get; set; }
}

public class testRefGnrcAltArgDescrOutp<Tref>
  : ItestRefGnrcAltArgDescrOutp<Tref>
{
  public Tref Asref { get; set; }
}
