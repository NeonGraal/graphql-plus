﻿//HintName: Model_output-parent-generic.gen.cs
// Generated from output-parent-generic.graphql+

/*
*/

namespace GqlTest.Model_output_parent_generic;

public interface IOutpPrntGnrc
{
  RefOutpPrntGnrc < I@041/0001 EnumOutpPrntGnrc.prnt_outpPrntGnrc > AsRefOutpPrntGnrc { get; }
}
public class OutputOutpPrntGnrc
{
  public RefOutpPrntGnrc < I@041/0001 EnumOutpPrntGnrc.prnt_outpPrntGnrc > AsRefOutpPrntGnrc { get; set; }
}

public interface IRefOutpPrntGnrc
{
  $type field { get; }
}
public class OutputRefOutpPrntGnrc
{
  public $type field { get; set; }
}

public enum EnumOutpPrntGnrc
{
  prnt_outpPrntGnrc = PrntOutpPrntGnrc.prnt_outpPrntGnrc,,
  outpPrntGnrc,
}

public enum PrntOutpPrntGnrc
{
  prnt_outpPrntGnrc,
}
