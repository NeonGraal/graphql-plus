﻿//HintName: test_generic-alt-arg-descr+Input_Impl.gen.cs
// Generated from generic-alt-arg-descr+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Input;

public class testGnrcAltArgDescrInp<Ttype>
  : ItestGnrcAltArgDescrInp<Ttype>
{
  public RefGnrcAltArgDescrInp<Ttype> AsRefGnrcAltArgDescrInp { get; set; }
}

public class testRefGnrcAltArgDescrInp<Tref>
  : ItestRefGnrcAltArgDescrInp<Tref>
{
  public Tref Asref { get; set; }
}
