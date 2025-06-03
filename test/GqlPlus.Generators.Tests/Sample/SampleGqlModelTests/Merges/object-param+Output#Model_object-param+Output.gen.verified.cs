//HintName: Model_object-param+Output.gen.cs
// Generated from object-param+Output.graphql+

/*
*/

namespace GqlTest.Model_object_param_Output;

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
