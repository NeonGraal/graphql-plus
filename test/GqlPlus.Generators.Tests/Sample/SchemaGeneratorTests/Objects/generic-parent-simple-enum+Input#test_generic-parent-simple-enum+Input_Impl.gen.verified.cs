﻿//HintName: test_generic-parent-simple-enum+Input_Impl.gen.cs
// Generated from generic-parent-simple-enum+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Input;

public class testGnrcPrntSmplEnumInp
  : testFieldGnrcPrntSmplEnumInp
  , ItestGnrcPrntSmplEnumInp
{
}

public class testFieldGnrcPrntSmplEnumInp<Tref>
  : ItestFieldGnrcPrntSmplEnumInp<Tref>
{
  public Tref field { get; set; }
}
