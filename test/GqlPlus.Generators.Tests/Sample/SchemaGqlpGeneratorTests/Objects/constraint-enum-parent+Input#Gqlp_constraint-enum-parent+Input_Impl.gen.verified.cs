﻿//HintName: Gqlp_constraint-enum-parent+Input_Impl.gen.cs
// Generated from constraint-enum-parent+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_enum_parent_Input;

public class InputCnstEnumPrntInp
  : ICnstEnumPrntInp
{
  public RefCnstEnumPrntInp<EnumCnstEnumPrntInp> AsRefCnstEnumPrntInp { get; set; }
}

public class InputRefCnstEnumPrntInp<Ttype>
  : IRefCnstEnumPrntInp<Ttype>
{
  public Ttype field { get; set; }
}
