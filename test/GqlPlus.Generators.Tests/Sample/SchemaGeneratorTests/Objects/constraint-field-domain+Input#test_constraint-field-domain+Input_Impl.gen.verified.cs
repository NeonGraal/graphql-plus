﻿//HintName: test_constraint-field-domain+Input_Impl.gen.cs
// Generated from constraint-field-domain+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Input;

public class InputtestCnstFieldDmnInp
  : InputtestRefCnstFieldDmnInp
  , ItestCnstFieldDmnInp
{
}

public class InputtestRefCnstFieldDmnInp<Tref>
  : ItestRefCnstFieldDmnInp<Tref>
{
  public Tref field { get; set; }
}

public class DomaintestDomCnstFieldDmnInp
  : ItestDomCnstFieldDmnInp
{
}
