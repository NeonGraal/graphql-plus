﻿//HintName: Model_output-constraint-dom-enum.gen.cs
// Generated from output-constraint-dom-enum.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_output_constraint_dom_enum;

public interface IOutpCnstDomEnum
{
  RefOutpCnstDomEnum<outpCnstDomEnum> AsRefOutpCnstDomEnum { get; }
}
public class OutputOutpCnstDomEnum
  : IOutpCnstDomEnum
{
  public RefOutpCnstDomEnum<outpCnstDomEnum> AsRefOutpCnstDomEnum { get; set; }
}

public interface IRefOutpCnstDomEnum<Ttype>
{
  Ttype field { get; }
}
public class OutputRefOutpCnstDomEnum<Ttype>
  : IRefOutpCnstDomEnum<Ttype>
{
  public Ttype field { get; set; }
}

public enum EnumOutpCnstDomEnum
{
  outpCnstDomEnum,
  other,
}

public interface IJustOutpCnstDomEnum
{
}
public class DomainJustOutpCnstDomEnum
  : IJustOutpCnstDomEnum
{
}
