//HintName: Model_output-generic-value.gen.cs
// Generated from output-generic-value.graphql+

/*
*/

namespace GqlTest.Model_output_generic_value;

public interface IOutpGnrcValue
{
  RefOutpGnrcValue<outpGnrcValue> AsRefOutpGnrcValue { get; }
}
public class OutputOutpGnrcValue
  : IOutpGnrcValue
{
  public RefOutpGnrcValue<outpGnrcValue> AsRefOutpGnrcValue { get; set; }
}

public interface IRefOutpGnrcValue<Ttype>
{
  Ttype field { get; }
}
public class OutputRefOutpGnrcValue<Ttype>
  : IRefOutpGnrcValue<Ttype>
{
  public Ttype field { get; set; }
}

public enum EnumOutpGnrcValue
{
  outpGnrcValue,
}
