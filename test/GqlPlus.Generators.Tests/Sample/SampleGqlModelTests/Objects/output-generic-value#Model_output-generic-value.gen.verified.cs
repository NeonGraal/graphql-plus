//HintName: Model_output-generic-value.gen.cs
// Generated from output-generic-value.graphql+

/*
*/

namespace GqlTest.Model_output_generic_value;

public interface IOutpGnrcValue
{
  RefOutpGnrcValue < I@043/0001 outpGnrcValue > AsRefOutpGnrcValue { get; }
}
public class OutputOutpGnrcValue
{
  public RefOutpGnrcValue < I@043/0001 outpGnrcValue > AsRefOutpGnrcValue { get; set; }
}

public interface IRefOutpGnrcValue
{
  $type field { get; }
}
public class OutputRefOutpGnrcValue
{
  public $type field { get; set; }
}

public enum EnumOutpGnrcValue
{
  outpGnrcValue,
}
