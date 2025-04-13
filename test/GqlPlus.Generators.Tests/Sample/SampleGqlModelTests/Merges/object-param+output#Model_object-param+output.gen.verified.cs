//HintName: Model_object-param+output.gen.cs
// Generated from object-param+output.graphql+

/*
*/

namespace GqlTest.Model_object_param_output;

public interface IOutpObjParam<Ttest,Ttype>
{
  Ttest test { get; }
  Ttype type { get; }
}
public class OutputOutpObjParam<Ttest,Ttype>
  : IOutpObjParam<Ttest,Ttype>
{
  public Ttest test { get; set; }
  public Ttype type { get; set; }
}
