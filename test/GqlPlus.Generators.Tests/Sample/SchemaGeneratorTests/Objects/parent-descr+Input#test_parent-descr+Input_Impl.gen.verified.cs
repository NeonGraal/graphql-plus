﻿//HintName: test_parent-descr+Input_Impl.gen.cs
// Generated from parent-descr+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Input;

public class testPrntDescrInp
  : testRefPrntDescrInp
  , ItestPrntDescrInp
{
}

public class testRefPrntDescrInp
  : ItestRefPrntDescrInp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
