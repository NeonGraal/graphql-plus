//HintName: Model_output-parent-generic.gen.cs
// Generated from output-parent-generic.graphql+

/*
*/

namespace GqlTest.Model_output_parent_generic;

public interface IOutpPrntGnrc
{
  RefOutpPrntGnrc AsRefOutpPrntGnrc { get; }
}
public class OutputOutpPrntGnrc
  : IOutpPrntGnrc
{
  public RefOutpPrntGnrc AsRefOutpPrntGnrc { get; set; }
}

public interface IRefOutpPrntGnrc<Ttype>
{
  Ttype field { get; }
}
public class OutputRefOutpPrntGnrc<Ttype>
  : IRefOutpPrntGnrc<Ttype>
{
  public Ttype field { get; set; }
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
